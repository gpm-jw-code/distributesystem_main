using cls_PostgreSQL_Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataProcess
{
    public class cls_PostgreSQLHandler
    {
        public static string ServerIP = "127.0.0.1";
        public static string Port = "5432";
        public static string Username = "postgres";
        public static string Password = "changeme";
        public static string Database = "distrubute";
        public static bool Enable = true;

        private string EdgeName = "";
        private string SensorName = "";
        private string SchemaName
        {
            get { return $"{EdgeName}_{SensorName}".ToLower(); }
        }
        private SQL_controller SQL_ProcessItem;

        public cls_PostgreSQLHandler(string EdgeName, string SensorName)
        {
            if (!Enable)
            {
                return;
            }
            this.EdgeName = EdgeName;
            this.SensorName = SensorName.Replace('.', '_');
            SQL_ProcessItem = new SQL_controller(ServerIP, Username, Password, Database, Port);
            SQL_ProcessItem.Create_Schema(SchemaName);
        }

        public void InsertRawData(Dictionary<string, double> Dict_RawData, DateTime TimeLog)
        {
            if (!Enable)
            {
                return;
            }
            List<string> List_ColumnName = new List<string>();
            List<object> list_Value = new List<object>();

            foreach (var item in Dict_RawData)
            {
                string ItemForSqlColumnName = item.Key.Replace('.', '_').Replace(' ', '_');
                List_ColumnName.Add(ItemForSqlColumnName);
                list_Value.Add(item.Value);
            }
            if (!SQL_ProcessItem.CheckTableExist(SchemaName, "rawdata"))
            {
                CreateRawDataTable(Dict_RawData.Keys.ToList());
            }

            List_ColumnName.Add("TimeLog");
            list_Value.Add($"{TimeLog:yyyy-MM-dd HH:mm:ss.fff}");

            SQL_ProcessItem.insert_row(SchemaName, "rawdata", List_ColumnName, list_Value);
        }

        private void CreateRawDataTable(List<string> List_DataName)
        {
            Dictionary<string, string> Dict_ColumnNameType = new Dictionary<string, string>();
            Dict_ColumnNameType.Add("TimeLog", StaString.DataTypeToSQLString(StaString.CShartDataType.DateTime));
            foreach (var item in List_DataName)
            {
                string ItemForSqlColumnName = item.Replace('.', '_').Replace(' ', '_');
                Dict_ColumnNameType.Add(ItemForSqlColumnName, StaString.DataTypeToSQLString(StaString.CShartDataType.DoubleData));
            }
            SQL_ProcessItem.Create_Table(SchemaName, "rawdata", Dict_ColumnNameType);
        }

        public cls_QueryReturn GetIntervalRawData(DateTime StartTime, DateTime EndTime, string timeColumnName = "datetime")
        {
            cls_QueryReturn OutputData = new cls_QueryReturn();

            string Condition = $"{timeColumnName} > '{StartTime:yyyy-MM-dd HH:mm:ss}' AND  {timeColumnName} < '{EndTime:yyyy-MM-dd HH:mm:ss}' order by {timeColumnName} asc";
            DataTable RawDataTable = SQL_ProcessItem.Select_to_Datatable(SchemaName, "rawdata", Condition);
            var AllColumnName = RawDataTable.Columns.Cast<DataColumn>().Select(item => item.ColumnName).ToList();
            foreach (var item in AllColumnName)
            {
                OutputData.Dict_DataList.Add(item, new List<double>());
            }
            foreach (var EachRow in RawDataTable.Rows.Cast<DataRow>())
            {
                foreach (var ColumnName in AllColumnName)
                {
                    if (ColumnName == "timelog")
                    {
                        OutputData.List_TimeLog.Add((DateTime)EachRow[ColumnName]);
                    }
                    else
                    {
                        OutputData.Dict_DataList[ColumnName].Add((double)EachRow[ColumnName]);
                    }
                }
            }
            return OutputData;
        }
    }

    public class cls_QueryReturn
    {
        public List<DateTime> List_TimeLog = new List<DateTime>();
        public Dictionary<string, List<double>> Dict_DataList = new Dictionary<string, List<double>>();
        public string DataUnit;
    }
}
