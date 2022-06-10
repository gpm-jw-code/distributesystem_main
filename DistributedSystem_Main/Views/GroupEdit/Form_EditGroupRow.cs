﻿using System;
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

            List<string> List_RowSensors = new List<string>();
            if (RowInfos.ContainsKey(RowName))
            {
                List_RowSensors = RowInfos[RowName];
            }

            foreach (var item in NoneSetSensor)
            {
                CheckBox NewSensorCheckBox = new CheckBox()
                {
                    Text = item,
                    Checked = List_RowSensors.Contains(item),
                    Dock = DockStyle.Top
                };
                Panel_AllSensorName.Controls.Add(NewSensorCheckBox);
                List_AllSensorComboBox.Add(NewSensorCheckBox);
            }
        }

        private void SetRowInfo(string RowName)
        {
            if (RowName == "")
            {
                RowName = $"Row{Systems.cls_HomePageManager.GetRowsInfo(NowGroupName).Count}";
            }
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
            if (CheckSensor.Count == 0)
            {
                MessageBox.Show("未選取任何Sensor");
                return;
            }
            if (MessageBox.Show($"是否要加入選取的{CheckSensor.Count}個Sensor", "Add Sensor", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            Systems.cls_HomePageManager.SetSensorToRow(NowGroupName, NewRowName, CheckSensor);
            MessageBox.Show($"已加入選取的{CheckSensor.Count}個Sensor");
            this.Close();
        }

        private void TXT_Filter_TextChanged(object sender, EventArgs e)
        {
            string FilterString = TXT_Filter.Text;
            foreach (var item in List_AllSensorComboBox)
            {
                item.Visible = item.Text.ToUpper().Contains(FilterString.ToUpper());
            }
        }
    }
}
