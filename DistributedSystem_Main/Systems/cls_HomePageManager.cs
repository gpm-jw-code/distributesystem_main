using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_Main.Systems
{
    public class cls_HomePageManager
    {
        public static string NowShowGroupName;
        private static Dictionary<string, cls_GroupObject> Dict_GroupObject = new Dictionary<string, cls_GroupObject>();

        public static DataGridView DGV_DataTable;
        private static User_Control.USC_GroupSwitch GroupSwitch;
        public static List<string> GroupNames { get { return Dict_GroupObject.Keys.ToList(); } }

        public static string GroupParameterPath
        {
            get
            {
                return System.IO.Path.Combine("Parameters", "GroupParameters.json");
            }
        }


        public static void InitialManager(DataGridView MainDataGridView, User_Control.USC_GroupSwitch MainGroupSwitch)
        {
            DGV_DataTable = MainDataGridView;
            GroupSwitch = MainGroupSwitch;
            GroupSwitch.Event_ChangeGroupName += ChangeGroup;
            LoadGroupParameters();
        }

        public static void AddNewGroup(string NewGroupName)
        {
            if (Dict_GroupObject == null)
            {
                Dict_GroupObject = new Dictionary<string, cls_GroupObject>();
            }
            Dict_GroupObject.Add(NewGroupName, new cls_GroupObject(NewGroupName));
        }

        public static void DeleteGroup(string GroupName)
        {
            if (!Dict_GroupObject.ContainsKey(GroupName))
            {
                return;
            }

                NowShowGroupName = "";
            Dict_GroupObject.Remove(GroupName);
        }

        public static void AddSensorToGroup(string GroupName, List<string> List_SensorNames)
        {
            Dict_GroupObject[GroupName].AddNewSensorToGroup(List_SensorNames);
        }

        public static void SetSensorToRow(string GroupName, string RowName, List<string> List_SensorName)
        {
            Dict_GroupObject[GroupName].ResetRowSensor(RowName);
            foreach (var item in List_SensorName)
            {
                Dict_GroupObject[GroupName].SetSensorToRow(RowName, item);
            }
        }

        public static void UpdateSensorData(string SensorName, Dictionary<string, double> Dict_DataValue)
        {
            if (string.IsNullOrEmpty(NowShowGroupName))
            {
                return;
            }
            if (!Dict_GroupObject[NowShowGroupName].List_SensorName.Contains(SensorName))
            {
                return;
            }
            string RowName = Dict_GroupObject[NowShowGroupName].FindRowNameWithSensorName(SensorName);
            var TargetRow = DGV_DataTable.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["RowName"].Value.ToString() == RowName).FirstOrDefault();
            if (TargetRow == default)
            {
                return;
            }

            var ColumnNames = DGV_DataTable.Columns.Cast<DataGridViewColumn>().Select(item => item.Name);

            foreach (var item in Dict_DataValue)
            {
                if (ColumnNames.Contains($"Column_{item.Key}"))
                {
                    TargetRow.Cells[$"Column_{item.Key}"].Value = item.Value;
                }
            }
        }

        public static void ChangeGroup(string NewGroupName)
        {
            NowShowGroupName = NewGroupName;

            DGV_DataTable.Columns.Clear();
            DGV_DataTable.Columns.Add("RowName", "Name");
            if (Dict_GroupObject[NowShowGroupName].List_ShowColumnName == null)
            {
                Dict_GroupObject[NowShowGroupName].List_ShowColumnName = Dict_GroupObject[NowShowGroupName].List_AllColumnName;
            }
            foreach (var item in Dict_GroupObject[NowShowGroupName].List_ShowColumnName)
            {
                DGV_DataTable.Columns.Add($"Column_{item}", item);
            }
            foreach (DataGridViewColumn item in DGV_DataTable.Columns)
            {
                item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                item.ReadOnly = true;
            }

            foreach (var item in Dict_GroupObject[NowShowGroupName].Dict_RowListSensor)
            {
                DGV_DataTable.Rows.Add(item.Key);
            }
            foreach (var item in Dict_GroupObject[NowShowGroupName].List_SensorName)
            {
                if (!Staobj.Dict_SensorProcessObject.ContainsKey(item))
                {
                    continue;
                }
                Staobj.Dict_SensorProcessObject[item].RefreshMainTable();
            }
        }

        internal static void ResetNowGroupName()
        {
            if (GroupNames.Count == 0)
            {
                return;
            }
            GroupSwitch.ChangeSelectGroup(GroupNames[0]);
            ChangeGroup(GroupNames[0]);
        }

        public static List<string> GetNoneSetGroupSensor()
        {
            var AllSensorList = Staobj.Dict_SensorProcessObject.Keys.ToList();
            List<string> List_FreeSensorList = new List<string>();
            foreach (var item in AllSensorList)
            {
                bool IsUsed = Dict_GroupObject.Any(EachGroup => EachGroup.Value.List_SensorName.Contains(item));
                if (!IsUsed)
                {
                    List_FreeSensorList.Add(item);
                }
            }
            return List_FreeSensorList;
        }

        public static List<string> GetNoneSetRowSensor(string GroupName)
        {
            var GroupSensor = GetGroupSensorNames(GroupName);
            List<string> List_NoneSetRowSensor = new List<string>();
            var RowsInfo = GetRowsInfo(GroupName);
            foreach (var item in GroupSensor)
            {
                bool IsSet = RowsInfo.Any(EachRowItem => EachRowItem.Value.Contains(item));
                if (!IsSet)
                {
                    List_NoneSetRowSensor.Add(item);
                }
            }
            return List_NoneSetRowSensor;
        }

        public static List<string> GetGroupSensorNames(string GroupName)
        {
            if (!Dict_GroupObject.ContainsKey(GroupName))
            {
                return new List<string>();
            }
            return Dict_GroupObject[GroupName].List_SensorName;
        }
        public static List<string> GetGroupColumnNames(string GroupName)
        {
            return Dict_GroupObject[GroupName].List_AllColumnName;
        }
        public static List<string> GetGroupShowColumnNames(string GroupName)
        {
            return Dict_GroupObject[GroupName].List_ShowColumnName;
        }
        internal static void SetGroupShowColumnNames(string GroupName, List<string> list_ShowColumnNames)
        {
            Dict_GroupObject[GroupName].List_ShowColumnName = list_ShowColumnNames;
        }

        public static Dictionary<string, List<string>> GetRowsInfo(string GroupName)
        {
            return Dict_GroupObject[GroupName].Dict_RowListSensor;
        }

        public static void SaveGroupParameters()
        {
            using (FileStream FS = new FileStream(GroupParameterPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter SW = new StreamWriter(FS))
                {
                    SW.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(Dict_GroupObject, Newtonsoft.Json.Formatting.Indented));
                }
            }
            GroupSwitch.InitializeGroupButtons(); 
            foreach (var item in Dict_GroupObject.Keys)
            {
                GroupSwitch.AddGroupButton(item);
            }
            ResetNowGroupName();
        }

        public static void LoadGroupParameters()
        {
            GroupSwitch.InitializeGroupButtons();
            using (FileStream FS = new FileStream(GroupParameterPath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Write))
            {
                using (StreamReader SR = new StreamReader(FS))
                {
                    Dict_GroupObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Systems.cls_HomePageManager.cls_GroupObject>>(SR.ReadToEnd());
                }
            }
            if (Dict_GroupObject == null)
            {
                Dict_GroupObject = new Dictionary<string, cls_GroupObject>();
            }
            foreach (var item in Dict_GroupObject.Keys)
            {
                GroupSwitch.AddGroupButton(item);
            }
            ResetNowGroupName();
        }

        public class cls_GroupObject
        {
            public string GroupName;
            public List<string> List_SensorName { get; private set; }
            public List<string> List_AllColumnName { get; private set; }

            public List<string> List_ShowColumnName { get; set; }
            public Dictionary<string, List<string>> Dict_RowListSensor { get; private set; }

            public cls_GroupObject(string GroupName)
            {
                this.GroupName = GroupName;
                List_SensorName = new List<string>();
                List_AllColumnName = new List<string>();
                List_ShowColumnName = new List<string>();
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
                        if (List_AllColumnName.Contains(DataNames))
                        {
                            continue;
                        }
                        List_AllColumnName.Add(DataNames);
                    }
                }
            }
            public void ResetRowSensor(string RowName)
            {
                if (!Dict_RowListSensor.ContainsKey(RowName))
                {
                    return;
                }
                Dict_RowListSensor[RowName].Clear();
            }

            public void SetSensorToRow(string RowName, string SensorName)
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
