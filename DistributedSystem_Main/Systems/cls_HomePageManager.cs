using System;
using System.Collections.Generic;
using System.Drawing;
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
        private static Dictionary<string, cls_GroupObject> _Dict_GroupObject = new Dictionary<string, cls_GroupObject>();

        private static int ShowRowNumber = 20;

        public static DataGridView DGV_DataTable;
        private static User_Control.USC_GroupSwitch GroupSwitch;
        private static User_Control.PageSwitch USC_PageSwitch;
        private static Panel Panel_PageSwitch;
        public static List<string> GroupNames { get { return _Dict_GroupObject.Keys.ToList(); } }
        public static Dictionary<string, cls_GroupObject> Dict_GroupObject { get { return _Dict_GroupObject; } }

        public static Action<Dictionary<string, cls_GroupObject>> Event_GroupSettingChange;

        public static string GroupParameterPath
        {
            get
            {
                return System.IO.Path.Combine(Staobj.SystemParam.ParmSaveFolderName, "GroupParameters.json");
            }
        }


        public static void InitialManager(DataGridView MainDataGridView, User_Control.USC_GroupSwitch MainGroupSwitch, User_Control.PageSwitch MainPageSwitch, Panel MainPageSwitchPanel)
        {
            DGV_DataTable = MainDataGridView;
            GroupSwitch = MainGroupSwitch;
            USC_PageSwitch = MainPageSwitch;
            Panel_PageSwitch = MainPageSwitchPanel;
            GroupSwitch.Event_ChangeGroupName += ChangeGroup;
            USC_PageSwitch.Event_PageChange += ChangeShowPage;
            LoadGroupParameters();
        }


        public static void AddNewGroup(string NewGroupName)
        {
            if (_Dict_GroupObject == null)
            {
                _Dict_GroupObject = new Dictionary<string, cls_GroupObject>();
            }
            _Dict_GroupObject.Add(NewGroupName, new cls_GroupObject(NewGroupName));
        }

        public static bool ChangeGroupName(string NewGroupName, string OriginGroupName)
        {
            if (!_Dict_GroupObject.ContainsKey(OriginGroupName))
            {
                return false;
            }
            var OriginGroupItem = _Dict_GroupObject[OriginGroupName];
            OriginGroupItem.GroupName = NewGroupName;
            _Dict_GroupObject.Remove(OriginGroupName);
            _Dict_GroupObject.Add(NewGroupName, OriginGroupItem);
            ChangeGroup("");
            return true;
        }

        public static void DeleteGroup(string GroupName)
        {
            if (!_Dict_GroupObject.ContainsKey(GroupName))
            {
                return;
            }

            NowShowGroupName = "";
            _Dict_GroupObject.Remove(GroupName);
        }

        public static void AutoSetGroupsBySensorType()
        {
            NowShowGroupName = "";
            Dictionary<string, cls_GroupObject> Dict_SensorTypeGroup = new Dictionary<string, cls_GroupObject>();
            foreach (var item in Staobj.Dict_SensorProcessObject)
            {
                string GroupName = item.Value.SensorInfo.SensorType;
                if (!Dict_SensorTypeGroup.ContainsKey(GroupName))
                {
                    Dict_SensorTypeGroup.Add(GroupName, new cls_GroupObject(GroupName));
                }
                Dict_SensorTypeGroup[GroupName].AddNewSensorToGroup(new List<string>() { item.Key });
                Dict_SensorTypeGroup[GroupName].SetSensorToRow(item.Key, item.Key);
            }
            _Dict_GroupObject = Dict_SensorTypeGroup;
            ChangeGroup(_Dict_GroupObject.Keys.First());
        }

        public static void AddSensorToGroup(string GroupName, List<string> List_SensorNames)
        {
            _Dict_GroupObject[GroupName].AddNewSensorToGroup(List_SensorNames);
        }

        public static bool ChangeRowName(string GroupName, string OriginRowName, string NewRowName)
        {
            return _Dict_GroupObject[GroupName].ChangeRowName(OriginRowName, NewRowName);
        }

        public static void DeleteRowFromGroup(string GroupName, string RowName)
        {
            _Dict_GroupObject[GroupName].DeleteRow(RowName);
        }

        public static void ResetRowSensor(string GroupName, string RowName, List<string> List_SensorName)
        {
            _Dict_GroupObject[GroupName].ResetRowSensor(RowName);
            foreach (var item in List_SensorName)
            {
                _Dict_GroupObject[GroupName].SetSensorToRow(RowName, item);
            }
        }

        internal static void ResetAlarm()
        {
            foreach (var item in DGV_DataTable.Rows.Cast<DataGridViewRow>())
            {
                foreach (var Cells in item.Cells.Cast<DataGridViewCell>())
                {
                    Cells.Style.BackColor = default;
                }
            }
        }

        public static void UpdateSensorData(string SensorName, Dictionary<string, double> Dict_DataValue, Dictionary<string, Color> Dict_BackColor)
        {
            if (string.IsNullOrEmpty(NowShowGroupName))
            {
                return;
            }
            if (!_Dict_GroupObject.ContainsKey(NowShowGroupName))
            {
                ResetNowGroupName();
                return;
            }
            if (!_Dict_GroupObject[NowShowGroupName].List_SensorName.Contains(SensorName))
            {
                return;
            }
            string RowName = _Dict_GroupObject[NowShowGroupName].FindRowNameWithSensorName(SensorName);
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
                if (Dict_BackColor[item.Key] != default)
                {
                    TargetRow.Cells[$"Column_{item.Key}"].Style.BackColor = Dict_BackColor[item.Key];
                }
            }
        }

        public static void ChangeGroup(string NewGroupName)
        {
            NowShowGroupName = NewGroupName;
            DGV_DataTable.Columns.Clear();
            if (NowShowGroupName == "")
            {
                return;
            }

            DGV_DataTable.Columns.Add("RowName", "Name");
            var NowShowGroup = _Dict_GroupObject[NowShowGroupName];
            if (NowShowGroup.List_ShowColumnName == null || NowShowGroup.List_ShowColumnName.Count == 0)
            {
                NowShowGroup.List_ShowColumnName = NowShowGroup.List_AllColumnName;
            }
            foreach (var item in NowShowGroup.List_ShowColumnName)
            {
                DGV_DataTable.Columns.Add($"Column_{item}", item);
            }
            foreach (DataGridViewColumn item in DGV_DataTable.Columns)
            {
                item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                item.ReadOnly = true;
            }

            Panel_PageSwitch.Visible = NowShowGroup.Dict_RowListSensor.Count > ShowRowNumber;

            USC_PageSwitch.SetMaximumPageNumber((int)Math.Ceiling(NowShowGroup.Dict_RowListSensor.Count / (double)ShowRowNumber));
            USC_PageSwitch.NowPageNumber = 1;
            ChangeShowPage(1);
        }

        private static void ChangeShowPage(int NewPageNumber)
        {
            DGV_DataTable.Rows.Clear();
            var SensorNamesArray = _Dict_GroupObject[NowShowGroupName].Dict_RowListSensor.Keys.ToArray();
            for (int i = (USC_PageSwitch.NowPageNumber - 1) * ShowRowNumber; i < USC_PageSwitch.NowPageNumber * ShowRowNumber; i++)
            {
                if (i == SensorNamesArray.Length)
                {
                    break;
                }
                DGV_DataTable.Rows.Add(SensorNamesArray[i]);
            }
            foreach (var item in _Dict_GroupObject[NowShowGroupName].List_SensorName)
            {
                if (!Staobj.Dict_SensorProcessObject.ContainsKey(item))
                {
                    continue;
                }
                Staobj.Dict_SensorProcessObject[item].RefreshMainTable();
            }
            ResetRowHeight();
        }

        public static void ResetRowHeight()
        {
            var TotalHeight = DGV_DataTable.Height;
            int EachItemHeight = TotalHeight / 21;
            DGV_DataTable.ColumnHeadersHeight = EachItemHeight;
            foreach (var item in DGV_DataTable.Rows.Cast<DataGridViewRow>())
            {
                item.Height = EachItemHeight;
            }
        }

        internal static void ResetNowGroupName()
        {
            if (GroupNames.Count == 0)
            {
                ChangeGroup("");
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
                bool IsUsed = _Dict_GroupObject.Any(EachGroup => EachGroup.Value.List_SensorName.Contains(item));
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
            if (!_Dict_GroupObject.ContainsKey(GroupName))
            {
                return new List<string>();
            }
            return _Dict_GroupObject[GroupName].List_SensorName;
        }

        public static List<string> GetGroupColumnNames(string GroupName)
        {
            return _Dict_GroupObject[GroupName].List_AllColumnName;
        }

        public static List<string> GetGroupShowColumnNames(string GroupName)
        {
            return _Dict_GroupObject[GroupName].List_ShowColumnName;
        }

        internal static void SetGroupShowColumnNames(string GroupName, List<string> list_ShowColumnNames)
        {
            _Dict_GroupObject[GroupName].List_ShowColumnName = list_ShowColumnNames;
        }

        public static Dictionary<string, List<string>> GetRowsInfo(string GroupName)
        {
            return _Dict_GroupObject[GroupName].Dict_RowListSensor;
        }

        public static void SaveGroupParameters()
        {
            using (FileStream FS = new FileStream(GroupParameterPath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter SW = new StreamWriter(FS))
                {
                    SW.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(_Dict_GroupObject, Newtonsoft.Json.Formatting.Indented));
                }
            }
            GroupSwitch.InitializeGroupButtons();
            foreach (var item in _Dict_GroupObject.Keys)
            {
                GroupSwitch.AddGroupButton(item);
            }
            ResetNowGroupName();
            Event_GroupSettingChange?.Invoke(Dict_GroupObject);
        }

        public static void LoadGroupParameters()
        {
            GroupSwitch.InitializeGroupButtons();
            if (!File.Exists(GroupParameterPath))
            {
                File.WriteAllText(GroupParameterPath, Newtonsoft.Json.JsonConvert.SerializeObject(Dict_GroupObject, Newtonsoft.Json.Formatting.Indented));
                return;
            }
            using (FileStream FS = new FileStream(GroupParameterPath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Write))
            {
                using (StreamReader SR = new StreamReader(FS))
                {
                    _Dict_GroupObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Systems.cls_HomePageManager.cls_GroupObject>>(SR.ReadToEnd());
                }
            }
            if (_Dict_GroupObject == null)
            {
                _Dict_GroupObject = new Dictionary<string, cls_GroupObject>();
            }
            foreach (var item in _Dict_GroupObject.Keys)
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

            public bool ChangeRowName(string OriginRowName, string NewRowName)
            {
                if (!Dict_RowListSensor.ContainsKey(OriginRowName))
                {
                    return false;
                }
                var TargetRowObject = Dict_RowListSensor[OriginRowName];
                Dict_RowListSensor.Remove(OriginRowName);
                Dict_RowListSensor.Add(NewRowName, TargetRowObject);
                return true;
            }

            public void DeleteRow(string RowName)
            {
                if (!Dict_RowListSensor.ContainsKey(RowName))
                {
                    return;
                }
                Dict_RowListSensor.Remove(RowName);
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

            public List<string> GetSensorNameByRowColumnName(string RowName, string ColumnName)
            {
                var RowSensorList = Dict_RowListSensor[RowName];
                var List_OutputSensorNames = RowSensorList.Where(item => Staobj.Dict_SensorProcessObject[item].List_DataNames.Contains(ColumnName)).Select(item => item).ToList();
                return List_OutputSensorNames;
            }
        }
    }
}
