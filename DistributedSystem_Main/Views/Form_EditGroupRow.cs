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
    public partial class Form_EditGroupRow : Form
    {
        bool IsNewRow = false;
        string NowGroupName = "";
        List<CheckBox> List_AllSensorComboBox = new List<CheckBox>();
        public Form_EditGroupRow(string GroupName, string RowName = "")
        {
            InitializeComponent();

            IsNewRow = RowName == "";
            NowGroupName = GroupName;
            LoadRowSensor(RowName);
            SetRowInfo(RowName);
        }

        private void LoadRowSensor(string RowName)
        {
            var RowInfos = Systems.cls_HomePageManager.GetRowsInfo(NowGroupName);
            var NoneSetSensor = Systems.cls_HomePageManager.GetNoneSetRowSensor(NowGroupName);
            var AllSensors = Systems.cls_HomePageManager.GetGroupSensorNames(NowGroupName);

            List<string> List_RowSensors = new List<string>();
            if (RowInfos.ContainsKey(RowName))
            {
                List_RowSensors = RowInfos[RowName];
            }

            foreach (var item in AllSensors)
            {
                CheckBox NewSensorCheckBox = new CheckBox()
                {
                    Text = item,
                    Checked = List_RowSensors.Contains(item),
                    ForeColor = NoneSetSensor.Contains(item) ? Color.Green : Color.Red,
                    Dock = DockStyle.Top
                };
                Panel_AllSensorName.Controls.Add(NewSensorCheckBox);
                List_AllSensorComboBox.Add(NewSensorCheckBox);
            }
        }

        private void SetRowInfo(string RowName)
        {
            TXT_RowName.Text = RowName;
            TXT_RowName.Enabled = RowName == "";
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            var NewRowName = TXT_RowName.Text;
            if (IsNewRow)
            {
                var Dict_RowInfo = Systems.cls_HomePageManager.GetRowsInfo(NowGroupName);
                if (Dict_RowInfo.ContainsKey(NewRowName))
                {
                    MessageBox.Show("已存在相同名稱");
                    return;
                }
            }

            List<string> CheckSensor = List_AllSensorComboBox.Where(item => item.Checked).Select(item => item.Text).ToList();
            if (MessageBox.Show($"是否要加入選取的{CheckSensor.Count}個Sensor", "Add Sensor", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            Systems.cls_HomePageManager.SetSensorToRow(NowGroupName, NewRowName, CheckSensor);
            MessageBox.Show($"已加入選取的{CheckSensor.Count}個Sensor");
            this.Close();
        }
    }
}
