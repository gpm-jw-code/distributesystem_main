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
            var List_ShowNames = Systems.cls_HomePageManager.GetGroupShowColumnNames(Combo_GroupName.Text); 
            foreach (var item in List_ColumnNames)
            {
                Label NewColumnLabel = new Label()
                {
                    Text = item,
                    Dock = DockStyle.Top,
                    ForeColor = List_ShowNames.Contains(item)?Color.Green:default
                };
                Panel_ColumnNames.Controls.Add(NewColumnLabel);
            }
            LoadRowsInfo(Combo_GroupName.Text);
        }

        private void LoadRowsInfo(string GroupName)
        {
            var RowInfo = Systems.cls_HomePageManager.GetRowsInfo(GroupName);
            Combo_Rows.Items.Clear();

            if (RowInfo.Count == 0)
                return;

            foreach (var item in RowInfo)
            {
                Combo_Rows.Items.Add(item.Key);
            }
            Combo_Rows.SelectedIndex = 0;
        }

        private void BTN_AddNewRow_Click(object sender, EventArgs e)
        {
            string GroupName = Combo_GroupName.Text;

            Form_EditGroupRow Form_RowEdit = new Form_EditGroupRow(GroupName);
            if (Systems.cls_HomePageManager.GetNoneSetRowSensor(GroupName).Count == 0)
            {
                MessageBox.Show("Group中的所有Sensor皆已設定");
                return;
            }
            Form_RowEdit.ShowDialog();
            LoadRowsInfo(GroupName);

            Combo_Rows.SelectedIndex = Combo_Rows.Items.Count-1;
            Combo_Rows_SelectedIndexChanged(null, null);
        }

        private void Combo_Rows_SelectedIndexChanged(object sender, EventArgs e)
        {
            string RowName = Combo_Rows.Text;
            Panel_RowSensor.Controls.Clear();
            var Dict_RowInfo = Systems.cls_HomePageManager.GetRowsInfo(Combo_GroupName.Text);
            if (!Dict_RowInfo.ContainsKey(RowName))
            {
                return;
            }
            foreach (var item in Dict_RowInfo[RowName])
            {
                Label NewSensorLabel = new Label()
                {
                    Text = item,
                    Dock = DockStyle.Top
                };
                Panel_RowSensor.Controls.Add(NewSensorLabel);
            }
        }

        private void BTN_EditRowSensor_Click(object sender, EventArgs e)
        { 
            string GroupName = Combo_GroupName.Text;
            string RowName = Combo_Rows.Text;
            Form_EditGroupRow Form_RowEdit = new Form_EditGroupRow(GroupName,RowName);
            Form_RowEdit.ShowDialog();
            LoadRowsInfo(GroupName);


            Combo_Rows.Text = RowName;
            Combo_Rows_SelectedIndexChanged(null, null);
        }

        private void BTN_SaveGroupParameters_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要儲存當前設定","Save Group Parmaeters",MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            Systems.cls_HomePageManager.SaveGroupParameters();
            this.Close();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要取消當前設定", "Cancel Group Parmaeters", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            Systems.cls_HomePageManager.LoadGroupParameters();
            this.Close();
        }

        private void BTN_DeleteGroup_Click(object sender, EventArgs e)
        {
            string GroupName = Combo_GroupName.Text;
            if (string.IsNullOrEmpty(GroupName))
            {
                return;
            }

            if (MessageBox.Show($"是否要刪除Group:{GroupName}", "Delete Group", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            Systems.cls_HomePageManager.DeleteGroup(GroupName);
            Combo_GroupName.Items.RemoveAt(Combo_GroupName.SelectedIndex);
            if (Combo_GroupName.Items.Count == 0)
            {
                return;
            }
            Combo_GroupName.SelectedIndex = 0;
        }

        private void BTN_EditColumnNames_Click(object sender, EventArgs e)
        {
            string GroupName = Combo_GroupName.Text;
            if (string.IsNullOrEmpty(GroupName))
            {
                return;
            }
            Form_EditGroupColumns ColumnEditForm = new Form_EditGroupColumns(GroupName);
            ColumnEditForm.ShowDialog();
            Combo_GroupName_SelectedIndexChanged(null, null);
        }
    }
}
