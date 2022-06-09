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
    public partial class Form_HomeGroupSetting : Form
    {
        Dictionary<string,CheckBox> Dict_RowSensorCheckBox = new Dictionary<string, CheckBox>();

        public Form_HomeGroupSetting()
        {
            InitializeComponent();
            LoadGroupInfo();
        }

        public void LoadGroupInfo()
        {
            Combo_GroupName.Items.Clear();
            Combo_GroupName.Items.AddRange(Systems.cls_HomePageManager.GroupNames.ToArray());
        }


        private void BTN_EditSensorList_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Combo_GroupName.Text))
            {
                return;
            }
            Form_GroupEditSensorList EditSensorForm = new Form_GroupEditSensorList(Combo_GroupName.Text);
            EditSensorForm.ShowDialog();
            Combo_GroupName_SelectedIndexChanged(null, null);
        }

        private void BTN_AddNewGroup_Click(object sender, EventArgs e)
        {
            string NewGroupName = Combo_GroupName.Text;
            if (Systems.cls_HomePageManager.GroupNames.Contains(NewGroupName))
            {
                MessageBox.Show("已存在相同名稱");
                return;
            }
            Systems.cls_HomePageManager.AddNewGroup(NewGroupName);
            Combo_GroupName.Items.Add(NewGroupName);
            MessageBox.Show("Add Success");
        }

        private void Combo_GroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var List_SensorNames = Systems.cls_HomePageManager.GetGroupSensorNames(Combo_GroupName.Text);
            Panel_CustomSensorList.Controls.Clear();
            Panel_ColumnNames.Controls.Clear();
            foreach (var item in List_SensorNames)
            {
                Label NewSensorLabel = new Label()
                {
                    Text = item,
                    Dock = DockStyle.Top
                };
                Panel_CustomSensorList.Controls.Add(NewSensorLabel);

                CheckBox NewSensorCheckBox = new CheckBox()
                {
                    Text = item,
                    Dock = DockStyle.Top
                };
                Panel_RowSensor.Controls.Add(NewSensorCheckBox);
                Dict_RowSensorCheckBox.Add(item,NewSensorCheckBox);
            }
            var List_ColumnNames = Systems.cls_HomePageManager.GetGroupColumnNames(Combo_GroupName.Text);
            foreach (var item in List_ColumnNames)
            {
                Label NewColumnLabel = new Label()
                {
                    Text = item,
                    Dock = DockStyle.Top
                };
                Panel_ColumnNames.Controls.Add(NewColumnLabel);
            }

            var RowInfo = Systems.cls_HomePageManager.GetRowsInfo(Combo_GroupName.Text);
            Combo_Rows.Items.Clear();
            foreach (var item in RowInfo)
            {
                Combo_Rows.Items.Add(item.Key);
            }
        }

        private void BTN_AddNewRow_Click(object sender, EventArgs e)
        {
            string NewRowName = Combo_Rows.Text;
            string GroupName = Combo_GroupName.Text;
            var Dict_RowInfo = Systems.cls_HomePageManager.GetRowsInfo(Combo_GroupName.Text);

            if (Dict_RowInfo.ContainsKey(NewRowName))
            {
                MessageBox.Show("已存在相同名稱");
                return;
            }
            if (Combo_Rows.Items.Contains(NewRowName))
            {
                MessageBox.Show("已存在相同名稱");
                return;
            }
            Combo_Rows.Items.Add(NewRowName);
            MessageBox.Show("Add Success");
        }

        private void BTN_SaveRowSensor_Click(object sender, EventArgs e)
        {
            string GroupName = Combo_GroupName.Text;
            string RowName = Combo_Rows.Text;

            List<string> CheckSensor = Dict_RowSensorCheckBox.Where(item => item.Value.Checked).Select(item => item.Key).ToList();
            Systems.cls_HomePageManager.SetSensorToRow(GroupName,RowName,CheckSensor);
        }

        private void Combo_Rows_SelectedIndexChanged(object sender, EventArgs e)
        {
            string RowName = Combo_Rows.Text;

            foreach (var item in Dict_RowSensorCheckBox)
            {
                item.Value.Checked = false;
            }
            var Dict_RowInfo = Systems.cls_HomePageManager.GetRowsInfo(Combo_GroupName.Text);
            foreach (var item in Dict_RowInfo[RowName])
            {
                Dict_RowSensorCheckBox[item].Checked = true;
            }
        }
    }
}
