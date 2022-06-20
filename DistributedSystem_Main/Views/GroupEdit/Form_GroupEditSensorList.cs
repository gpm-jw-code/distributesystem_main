using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_Main.Views
{
    public partial class Form_GroupEditSensorList : Form
    {
        List<CheckBox> List_SensorNameComboBox = new List<CheckBox>();
        string GroupName;
        bool IsEditGroup = false;
        bool IsNewGroup = false;

        List<string> List_NoneUsedSensor = new List<string>();
        public Form_GroupEditSensorList(string GroupName)
        {
            InitializeComponent();
            IsEditGroup = true;
            LoadSensorNames(GroupName);
            SetGroupName(GroupName);
        }

        public Form_GroupEditSensorList()
        {
            InitializeComponent();
            IsNewGroup = true;
            LoadSensorNames();
            SetGroupName();
        }

        private void LoadSensorNames(string GroupName = "")
        {
            var GroupSensorNames = Systems.cls_HomePageManager.GetGroupSensorNames(GroupName);
            List_NoneUsedSensor = Systems.cls_HomePageManager.GetNoneSetGroupSensor();
            foreach (var item in Systems.Staobj.Dict_SensorProcessObject.Keys)
            {
                CheckBox NewComboBox = new CheckBox() {
                    Text = item,
                    Dock = DockStyle.Top,
                    Checked = GroupSensorNames.Contains(item),
                    ForeColor = List_NoneUsedSensor.Contains(item) ? Color.Green : Color.Red
                };
                List_SensorNameComboBox.Add(NewComboBox);
                Panel_AllSensorName.Controls.Add(NewComboBox);
            }
        }

        public void SetGroupName(string GroupName = "")
        {
            //TXT_GroupName.Enabled = GroupName == "";
            if (GroupName == "")
            {
                GroupName = $"Group{Systems.cls_HomePageManager.GroupNames.Count}";
            }
            TXT_GroupName.Text = GroupName;
            this.GroupName = GroupName; 
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            var ListSensorNames = List_SensorNameComboBox.Where(item => item.Checked).Select(item => item.Text).ToList();

            if (ListSensorNames.Count == 0)
            {
                MessageBox.Show("未選取任何Sensor");
                return;
            }
            if (MessageBox.Show($"是否要加入選取的{ListSensorNames.Count}個Sensor", "Add Sensor", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            if (IsNewGroup)
            {
                string NewGroupName = TXT_GroupName.Text;
                if (Systems.cls_HomePageManager.GroupNames.Contains(NewGroupName))
                {
                    MessageBox.Show("已存在相同Group名稱");
                    return;
                }
                Systems.cls_HomePageManager.AddNewGroup(NewGroupName);
                this.GroupName = NewGroupName;
            }
            if (IsEditGroup)
            {
                string NewGroupName = TXT_GroupName.Text;
                if (NewGroupName != GroupName)
                {
                    if (MessageBox.Show($"是否要變更Group名稱為:{NewGroupName}","Edit Group Name",MessageBoxButtons.YesNo)!= DialogResult.Yes)
                    {
                        TXT_GroupName.Text = GroupName;
                        return;
                    }
                    if (Systems.cls_HomePageManager.GroupNames.Contains(NewGroupName))
                    {
                        MessageBox.Show("已存在相同Group名稱");
                        return;
                    }
                    Systems.cls_HomePageManager.ChangeGroupName(NewGroupName, GroupName);
                    this.GroupName = NewGroupName;
                }
            }
            
            Systems.cls_HomePageManager.AddSensorToGroup(this.GroupName, ListSensorNames);
            MessageBox.Show($"已加入選取的{ListSensorNames.Count}個Sensor");
            this.Close();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TXT_Filter_TextChanged(object sender, EventArgs e)
        {
            string FilterString = TXT_Filter.Text;
            bool IsOnlyShowNoneSet = CheckBox_ShowNoneSet.Checked;
            foreach (var item in List_SensorNameComboBox)
            {
                item.Visible = item.Text.ToUpper().Contains(FilterString.ToUpper());
                if (IsOnlyShowNoneSet)
                {
                    item.Visible = item.Visible && List_NoneUsedSensor.Contains(item.Text);
                }
            }
        }

        private void CheckBox_ShowNoneSet_CheckedChanged(object sender, EventArgs e)
        {
            string FilterString = TXT_Filter.Text;
            bool IsOnlyShowNoneSet = CheckBox_ShowNoneSet.Checked;
            foreach (var item in List_SensorNameComboBox)
            {
                item.Visible = item.Text.ToUpper().Contains(FilterString.ToUpper());
                if (IsOnlyShowNoneSet)
                {
                    item.Visible = item.Visible && List_NoneUsedSensor.Contains(item.Text);
                }
            }
        }
    }
}
