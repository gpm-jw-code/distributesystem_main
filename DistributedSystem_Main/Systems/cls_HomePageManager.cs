using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_Main.Systems
{
    public class cls_HomePageManager
    {
        public static string NowShowGroupName;
        private static Dictionary<string, cls_GroupObject> Dict_GroupObject = new Dictionary<string, cls_GroupObject>() ;

        public static DataGridView DGV_DataTable;
        public static List<string> GroupNames { get { return Dict_GroupObject.Keys.ToList(); } }

        public static void AddNewGroup(string NewGroupName)
        {
            if (Dict_GroupObject == null)
            {
                Dict_GroupObject = new Dictionary<string, cls_GroupObject>();
            }
            Dict_GroupObject.Add(NewGroupName, new cls_GroupObject(NewGroupName));
        }

        public static void AddSensorToGroup(string GroupName,List<string> List_SensorNames)
        {
            Dict_GroupObject[GroupName].AddNewSensorToGroup(List_SensorNames);
        }

        public static void SetSensorToRow(string GroupName,string RowName,List<string> List_SensorName)
        {
            foreach (var item in List_SensorName)
            {
                Dict_GroupObject[GroupName].SetSensorToRow(RowName, item);
            }
        }

        public static void UpdateSensorData(string SensorName,Dictionary<string,double> Dict_DataValue)
        {
            if (!Dict_GroupObject[NowShowGroupName].List_SensorName.Contains(SensorName))
            {
                return;
            }
            string RowName = Dict_GroupObject[NowShowGroupName].FindRowNameWithSensorName(SensorName);
            var TargetRow = DGV_DataTable.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["RowName"].Value.ToString() == RowName).First();

            foreach (var item in Dict_DataValue)
            {
                TargetRow.Cells[$"Column_{item}"].Value = item.Value;
            }
        }

        public static void ChangeGroup(string NewGroupName)
        {
            NowShowGroupName = NewGroupName;

            DGV_DataTable.Columns.Clear();
            DGV_DataTable.Columns.Add("RowName", "Name");
            foreach (var item in Dict_GroupObject[NowShowGroupName].List_ColumnName)
            {
                DGV_DataTable.Columns.Add($"Column_{item}",item);
            }
            foreach (var item in Dict_GroupObject[NowShowGroupName].List_SensorName)
            {
                Staobj.Dict_SensorProcessObject[item].RefreshMainTable();
            }
        }

        public static List<string> GetGroupSensorNames(string GroupName)
        {
            return Dict_GroupObject[GroupName].List_SensorName;
        }
        public static List<string> GetGroupColumnNames(string GroupName)
        {
            return Dict_GroupObject[GroupName].List_ColumnName;
        }
        public static Dictionary<string,List<string>> GetRowsInfo(string GroupName)
        {
            return Dict_GroupObject[GroupName].Dict_RowListSensor;
        }

        public class cls_GroupObject
        {
            public string GroupName;
            public List<string> List_SensorName { get; private set; }
            public List<string> List_ColumnName { get; private set; }
            public Dictionary<string, List<string>> Dict_RowListSensor { get; private set; }

            public cls_GroupObject(string GroupName)
            {
                this.GroupName = GroupName;
                List_SensorName = new List<string>();
                List_ColumnName = new List<string>();
                Dict_RowListSensor = new Dictionary<string, List<string>>();
            }

            public void AddNewSensorToGroup(List<string> List_NewSensor)
            {
                foreach (var item in List_NewSensor)
                {
                    if (!this.List_SensorName.Contains(item))
                    {
                        this.List_SensorName.Add(item);
                    }
                    foreach (var DataNames in Staobj.Dict_SensorProcessObject[item].List_DataNames)
                    {
                        if (List_ColumnName.Contains(DataNames))
                        {
                            continue;
                        }
                        List_ColumnName.Add(DataNames);
                    }
                }
            }

            public void SetSensorToRow(string RowName,string SensorName)
            {
                if (!Dict_RowListSensor.ContainsKey(RowName))
                {
                    Dict_RowListSensor.Add(RowName, new List<string>());
                }
                if (!Dict_RowListSensor[RowName].Contains(SensorName))
                {
                    Dict_RowListSensor[RowName].Add(SensorName);
                }
            }

            public string FindRowNameWithSensorName(string SensorName)
            {
                var List_RowNames = Dict_RowListSensor.Where(item => item.Value.Contains(SensorName)).Select(item => item.Key).ToList();
                if (List_RowNames.Count == 0)
                {
                    return "";
                }
                else
                {
                    return List_RowNames[0];
                }
            }
        }

    }
}
