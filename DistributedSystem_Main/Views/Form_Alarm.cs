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
            PageSwitch_Alarm.Event_PageChange += PageChange;
        }

        private void PageChange(int NewPageNumber)
        {
            DGV_AlarmEvents.Rows.Clear();
            if (List_FilterDataRows.Count == 0)
            {
                List_FilterDataRows = Dict_AllDataRows.Values.ToList();
            }
            for (int i = (PageSwitch_Alarm.NowPageNumber - 1) * ShowRowNumber; i < PageSwitch_Alarm.NowPageNumber * ShowRowNumber; i++)
            {
                if (i>=List_FilterDataRows.Count)
                {
                    break;
                }
                DGV_AlarmEvents.Rows.Add(List_FilterDataRows[i]);
            }
            ResetRowHeight();
        }

        Dictionary<string,DataGridViewRow> Dict_AllDataRows = new Dictionary<string, DataGridViewRow>();
        List<DataGridViewRow> List_FilterDataRows = new List<DataGridViewRow>();
        int ShowRowNumber = 10;

        public void InsertNewEventLog(SensorInfo NewSensorInfo, Dictionary<string, OutOfState> Dict_OutOfStatus)
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

            if (Dict_AllDataRows.ContainsKey(SensorName))
            {
                Dict_AllDataRows[SensorName].Cells[3].Value = Event;
                Dict_AllDataRows[SensorName].Cells[4].Value = Description;
                return;
            }
            if (DGV_AlarmEvents.Rows.Count>ShowRowNumber)
            {
                DataGridViewRow row = (DataGridViewRow)DGV_AlarmEvents.Rows[0].Clone();
                row.SetValues(EQName, UnitName, SensorName, Event, Description, "Reset");
                Dict_AllDataRows.Add(SensorName,row);
                PageSwitch_Alarm.SetMaximumPageNumber((int)Math.Ceiling(Dict_AllDataRows.Count / (double)ShowRowNumber));
            }
            else
            {
                DGV_AlarmEvents.Rows.Add(EQName, UnitName, SensorName, Event, Description, "Reset");
                Dict_AllDataRows.Add(SensorName, DGV_AlarmEvents.Rows[DGV_AlarmEvents.Rows.Count - 1]);
            }
            ResetRowHeight();
            this.Show();
        }

        private void BTN_ResetAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要將所有Sensor異常事件Reset","Reset All",MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            foreach (var item in Dict_AllDataRows)
            {
                string SensorName = item.Key;
                foreach (var statesItem in Systems.Staobj.Dict_SensorProcessObject[SensorName].Dict_OutOfItemStates)
                {
                    statesItem.Value.RESET();
                }
            }
            PageSwitch_Alarm.SetMaximumPageNumber(1);
            DGV_AlarmEvents.Rows.Clear();
            Dict_AllDataRows.Clear();
            List_FilterDataRows.Clear();
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

        private void ResetRowHeight()
        {
            int EachHeight = DGV_AlarmEvents.Height / (ShowRowNumber+1);
            foreach (var item in DGV_AlarmEvents.Rows.Cast<DataGridViewRow>())
            {
                item.Height = EachHeight;
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
            List_FilterDataRows= new List<DataGridViewRow>();
            foreach (var item in Dict_AllDataRows.Values)
            {
                if (item.Cells.Cast<DataGridViewCell>().Any(cellitem => cellitem.Value.ToString().ToUpper().Contains(FilterString.ToUpper())))
                {
                    List_FilterDataRows.Add(item);
                }
            }
            PageSwitch_Alarm.SetMaximumPageNumber((int)Math.Ceiling(List_FilterDataRows.Count / (double)ShowRowNumber));
            PageChange(PageSwitch_Alarm.NowPageNumber);
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

        private void Form_Alarm_SizeChanged(object sender, EventArgs e)
        {
            ResetRowHeight();
        }
    }
}
