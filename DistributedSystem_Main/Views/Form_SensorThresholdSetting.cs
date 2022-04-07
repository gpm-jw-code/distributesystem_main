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
    public partial class Form_SensorThresholdSetting : Form
    {

        string SensorName = "";
        string SensorType = "";

        public Form_SensorThresholdSetting(SensorDataProcess.SensorInfo SensorInfo)
        {
            InitializeComponent();
            this.LAB_SensorIP.Text = SensorInfo.SensorName;
            this.LAB_EQName.Text = SensorInfo.EQName;
            this.LAB_UnitName.Text = SensorInfo.UnitName;
            this.LAB_SensorType.Text = SensorInfo.SensorType;
            this.SensorType = SensorInfo.SensorType;
            this.SensorName = SensorInfo.SensorName;
        }

        public void ImportThresholdSettings(Dictionary<string,double> Dict_Threshold)
        {
            DGV_ThresholdSetting.Rows.Clear();
            foreach (var item in Dict_Threshold)
            {
                DGV_ThresholdSetting.Rows.Add(item.Key,item.Value);
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            List<string> List_TargetSensor = new List<string>();
            if (CheckBox_ApplyToAll.Checked)
            {
                List_TargetSensor = Systems.Staobj.Dict_SensorProcessObject.Where(item => item.Value.SensorInfo.SensorType == this.SensorType).Select(item=>item.Key).ToList();
            }
            else
                List_TargetSensor.Add(SensorName);


            foreach (var TargetSensorName in List_TargetSensor)
            {
                foreach (var item in DGV_ThresholdSetting.Rows.Cast<DataGridViewRow>())
                {
                    string DataName = item.Cells[0].Value.ToString();
                    Systems.Staobj.Dict_SensorProcessObject[TargetSensorName].Dict_DataThreshold[DataName] = Convert.ToDouble(item.Cells[1].Value);
                    Systems.Staobj.SensorParam.SaveThresholdToFile(Systems.Staobj.Dict_SensorProcessObject[TargetSensorName].Dict_DataThreshold, TargetSensorName);
                }
            }

            this.Close();
        }
    }
}
