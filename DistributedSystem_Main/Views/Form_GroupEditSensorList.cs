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
        public Form_GroupEditSensorList(string GroupName)
        {
            InitializeComponent();
            LoadSensorNames(GroupName);
            SetGroupName(GroupName);
        }

        private void LoadSensorNames(string GroupName)
        {
            var GroupSensorNames = Systems.cls_HomePageManager.GetGroupSensorNames(GroupName);
            foreach (var item in Systems.Staobj.Dict_SensorProcessObject.Keys)
            {
                CheckBox NewComboBox = new CheckBox() {
                    Text = item,
                    Dock = DockStyle.Top,
                    Checked = GroupSensorNames.Contains(item)
                };
                List_SensorNameComboBox.Add(NewComboBox);
                Panel_AllSensorName.Controls.Add(NewComboBox);
            }
        }

        public void SetGroupName(string GroupName)
        {
            LAB_GroupName.Text = GroupName;
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
            if (MessageBox.Show($"是否要加入選取的{ListSensorNames.Count}個Sensor","Add Sensor",MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
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
