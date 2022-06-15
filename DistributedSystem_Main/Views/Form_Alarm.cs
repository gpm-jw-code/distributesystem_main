using SensorDataProcess;
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
    public partial class Form_Alarm : Form
    {
        public Form_Alarm()
        {
            InitializeComponent();
        }

        List<DataGridViewRow> List_AllDataRows = new List<DataGridViewRow>();

        public void InsertNewEventLog(SensorInfo NewSensorInfo,Dictionary<string, OutOfState> Dict_OutOfStatus )
        {
            string EQName = NewSensorInfo.EQName;
            string UnitName = NewSensorInfo.UnitName;
            string SensorName = NewSensorInfo.SensorName;
            string Event = "";
            string Description = "";
            List<string> List_OOC_Items = new List<string>();
            List<string> List_OOS_Items = new List<string>();
            foreach (var EachItem in Dict_OutOfStatus)
            {
                string DataName = EachItem.Key;
                if (EachItem.Value.isOutofSPEC)
                {
                    List_OOS_Items.Add(DataName);
                    continue;
                }
                if (EachItem.Value.isOutofControl)
                {
                    List_OOC_Items.Add(DataName);
                    continue;
                }
            }
            if (List_OOC_Items.Count > 0)
            {
                Event = "OOC";
                Description = $"OOC: {string.Join(", ", List_OOC_Items)}";
            }
            if (List_OOS_Items.Count > 0)
            {
                Event = "OOS";
                Description = $"OOS: {string.Join(", ", List_OOS_Items)}; {Description}";
            }
            var TargetRow = DGV_AlarmEvents.Rows.Cast<DataGridViewRow>().Where(item => item.Cells[2].Value.ToString() == SensorName).ToList();
            if (TargetRow.Count > 0)
            {
                TargetRow[0].Cells[3].Value = Event;
                TargetRow[0].Cells[4].Value = Description;
                return;
            }
            DGV_AlarmEvents.Rows.Add(EQName, UnitName, SensorName, Event,Description,"Reset");
            List_AllDataRows.Add(DGV_AlarmEvents.Rows[DGV_AlarmEvents.Rows.Count - 1]);
            this.Show();
        }

        private void BTN_ResetAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要將所有Sensor異常事件Reset","Reset All",MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            foreach (DataGridViewRow item in DGV_AlarmEvents.Rows)
            {
                string SensorName = item.Cells[2].Value.ToString();
                foreach (var statesItem in Systems.Staobj.Dict_SensorProcessObject[SensorName].Dict_OutOfItemStates)
                {
                    statesItem.Value.RESET();
                }
            }
            DGV_AlarmEvents.Rows.Clear();
        }

        private void DGV_AlarmEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex!=5)
            {
                return;
            }
            string SensorName = DGV_AlarmEvents.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (MessageBox.Show($"是否要將{SensorName} Reset","Reset",MessageBoxButtons.YesNo)!= DialogResult.Yes)
            {
                return;
            }
            DGV_AlarmEvents.Rows.RemoveAt(e.RowIndex);
            foreach (var item in Systems.Staobj.Dict_SensorProcessObject[SensorName].Dict_OutOfItemStates)
            {
                item.Value.RESET();
            }
        }

        private void Form_Alarm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) //進行重啟的時候的時候
            {
                Application.Exit();
                return;
            }   
            e.Cancel = true;
            this.Hide();
        }

        private void BTN_Filter_Click(object sender, EventArgs e)
        {
            string FilterString = TXT_Filter.Text;
            List<DataGridViewRow> List_FilterRows = new List<DataGridViewRow>();
            foreach (var item in List_AllDataRows)
            {
                if (item.Cells.Cast<DataGridViewCell>().Any(cellitem => cellitem.Value.ToString().ToUpper().Contains(FilterString.ToUpper())))
                {
                    List_FilterRows.Add(item);
                }
            }
            DGV_AlarmEvents.Rows.Clear();
            DGV_AlarmEvents.Rows.AddRange(List_FilterRows.ToArray());
        }


        private void TXT_Filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (TXT_Filter.Text == "")
            {
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                TXT_Filter.Text = "";
                BTN_Filter_Click(null, null);
            }
        }
    }
}
