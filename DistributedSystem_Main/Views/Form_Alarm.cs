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

        public void InsertNewEventLog(SensorInfo NewSensorInfo,Dictionary<string, OutOfState> Dict_OutOfStatus )
        {
            string EQName = NewSensorInfo.EQName;
            string UnitName = NewSensorInfo.UnitName;
            string SensorName = NewSensorInfo.SensorNameWithOutEdgeName;
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
                Description = $"OOC: {string.Join(", ", List_OOS_Items)}";
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
            DGV_AlarmEvents.Rows.Add(EQName, UnitName, SensorName, Event,Description);
            this.Show();
        }
    }
}
