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
    public partial class Form_EditGroupColumns : Form
    {
        public Form_EditGroupColumns(string GroupName)
        {
            InitializeComponent();
            LoadColumnInfo(GroupName);
        }

        List<CheckBox> List_AllCheckBox = new List<CheckBox>();
        string GroupName = "";

        private void LoadColumnInfo(string GroupName)
        {
            CheckListBox_ColumnNames.Items.Clear();
            this.GroupName = GroupName;
            var List_ColumnNames = Systems.cls_HomePageManager.GetGroupColumnNames(GroupName);
            var List_ShowNames = Systems.cls_HomePageManager.GetGroupShowColumnNames(GroupName);
            if (List_ShowNames.Count == 0)
            {
                List_ShowNames = List_ColumnNames;
            }
            foreach (var item in List_ColumnNames)
            {
                CheckListBox_ColumnNames.Items.Add(item, List_ShowNames.Contains(item));
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            var List_ShowColumnNames = new List<string>();
            foreach (var item in CheckListBox_ColumnNames.CheckedItems)
            {
                List_ShowColumnNames.Add(item.ToString());
            }
            //var List_ShowColumnNames = List_AllCheckBox.Where(item => item.Checked).Select(item => item.Text).ToList();
            if (List_ShowColumnNames.Count == 0)
            {
                MessageBox.Show("須至少選擇一個Column");
                return;
            }
            Systems.cls_HomePageManager.SetGroupShowColumnNames(this.GroupName, List_ShowColumnNames);
            MessageBox.Show($"已加入選取的{List_ShowColumnNames.Count}個Column");
            this.Close();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_MoveUp_Click(object sender, EventArgs e)
        {
            if (CheckListBox_ColumnNames.SelectedIndex < 0)
            {
                return;
            }

            int NewIndex = CheckListBox_ColumnNames.SelectedIndex - 1;
            MoveCheckListItem(CheckListBox_ColumnNames.SelectedIndex, NewIndex);
        }

        private void BTN_MoveDown_Click(object sender, EventArgs e)
        {
            if (CheckListBox_ColumnNames.SelectedIndex < 0)
            {
                return;
            }

            int NewIndex = CheckListBox_ColumnNames.SelectedIndex + 1;
            MoveCheckListItem(CheckListBox_ColumnNames.SelectedIndex, NewIndex);
        }
        private void MoveCheckListItem(int SelectIndex, int NewIndex)
        {
            var checkState = CheckListBox_ColumnNames.GetItemCheckState(SelectIndex);
            var TargetItem = CheckListBox_ColumnNames.SelectedItem;
            CheckListBox_ColumnNames.Items.Remove(TargetItem);
            CheckListBox_ColumnNames.Items.Insert(NewIndex, TargetItem);
            CheckListBox_ColumnNames.SetItemCheckState(NewIndex, checkState);
            CheckListBox_ColumnNames.SelectedIndex = NewIndex;
        }

        private void CheckListBox_ColumnNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            BTN_MoveUp.Enabled = BTN_MoveDown.Enabled = true;
            if (CheckListBox_ColumnNames.SelectedIndex ==0)
            {
                BTN_MoveUp.Enabled = false;
            }
            if (CheckListBox_ColumnNames.SelectedIndex == CheckListBox_ColumnNames.Items.Count-1)
            {
                BTN_MoveDown.Enabled = false;
            }
            
        }

    }
}
