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
            Form_GroupEditSensorList EditSensorForm = new Form_GroupEditSensorList();
            EditSensorForm.ShowDialog();
            LoadGroupInfo();
            Combo_GroupName.SelectedIndex = Combo_GroupName.Items.Count - 1;
            Combo_GroupName_SelectedIndexChanged(null, null);
        }

        private void Combo_GroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var List_SensorNames = Systems.cls_HomePageManager.GetGroupSensorNames(Combo_GroupName.Text);
            Panel_CustomSensorList.Controls.Clear();
            Panel_ColumnNames.Controls.Clear();
            Panel_RowSensor.Controls.Clear();
            foreach (var item in List_SensorNames)
            {
                Label NewSensorLabel = new Label()
                {
                    Text = item,
                    Dock = DockStyle.Top
                };
                Panel_CustomSensorList.Controls.Add(NewSensorLabel);
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

            LoadRowsInfo(Combo_GroupName.Text);
        }

        private void LoadRowsInfo(string GroupName)
        {
            var RowInfo = Systems.cls_HomePageManager.GetRowsInfo(GroupName);
            Combo_Rows.Items.Clear();
            foreach (var item in RowInfo)
            {
                Combo_Rows.Items.Add(item.Key);
            }
        }

        private void BTN_AddNewRow_Click(object sender, EventArgs e)
        {
            string GroupName = Combo_GroupName.Text;

            Form_EditGroupRow Form_RowEdit = new Form_EditGroupRow(GroupName);
            Form_RowEdit.ShowDialog();
            LoadRowsInfo(GroupName);
        }

        private void Combo_Rows_SelectedIndexChanged(object sender, EventArgs e)
        {
            string RowName = Combo_Rows.Text;
            Panel_RowSensor.Controls.Clear();
            var Dict_RowInfo = Systems.cls_HomePageManager.GetRowsInfo(Combo_GroupName.Text);
            foreach (var item in Dict_RowInfo[RowName])
            {
                Label NewSensorLabel = new Label()
                {
                    Text = item,
                    Dock = DockStyle.Top
                };
                Panel_RowSensor.Controls.Add(NewSensorLabel);
            }
            if (!Dict_RowInfo.ContainsKey(RowName))
            {
                return;
            }
        }

        private void BTN_EditRowSensor_Click(object sender, EventArgs e)
        {
            string GroupName = Combo_GroupName.Text;
            string RowName = Combo_Rows.Text;
            Form_EditGroupRow Form_RowEdit = new Form_EditGroupRow(GroupName,RowName);
            Form_RowEdit.ShowDialog();
            LoadRowsInfo(GroupName);
        }
    }
}
