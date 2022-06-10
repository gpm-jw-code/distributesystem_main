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
            var List_NoneUsedSensor = Systems.cls_HomePageManager.GetNoneSetGroupSensor();
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
            if (GroupName == "")
            {
                return;
            }
            TXT_GroupName.Text = GroupName;
            TXT_GroupName.Enabled = false;
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
            
            Systems.cls_HomePageManager.AddSensorToGroup(this.GroupName, ListSensorNames);
            MessageBox.Show($"已加入選取的{ListSensorNames.Count}個Sensor");
            this.Close();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
