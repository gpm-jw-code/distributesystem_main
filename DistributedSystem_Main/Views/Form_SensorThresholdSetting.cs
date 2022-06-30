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
        Dictionary<string, double> Dict_Threshold;
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

        public void ImportThresholdSettings(Dictionary<string, double> Dict_Threshold)
        {
            Combo_DataName.Items.Clear();
            this.Dict_Threshold = new Dictionary<string, double>();
            foreach (var item in Dict_Threshold)
            {
                this.Dict_Threshold.Add(item.Key, item.Value);
                string DataName = item.Key.Replace("_OOC", "");
                DataName = DataName.Replace("_OOS", "");
                if (Combo_DataName.Items.Contains(DataName))
                {
                    continue;
                }
                Combo_DataName.Items.Add(DataName);
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存並應用設定", "Save", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            List<string> List_TargetSensor = new List<string>();
            if (CheckBox_ApplyToAll.Checked)
            {
                List_TargetSensor = Systems.Staobj.Dict_SensorProcessObject.Where(item => item.Value.SensorInfo.SensorType == this.SensorType).Select(item => item.Key).ToList();
            }
            else
                List_TargetSensor.Add(SensorName);


            foreach (var TargetSensorName in List_TargetSensor)
            {
                foreach (var item in Dict_Threshold)
                {
                    Systems.Staobj.Dict_SensorProcessObject[TargetSensorName].Dict_DataThreshold[item.Key] = Convert.ToDouble(item.Value);
                }
                Systems.Staobj.Dict_SensorProcessObject[TargetSensorName].RefreshThreshold();
                Systems.Staobj.SensorParam.SaveThresholdToFile(Systems.Staobj.Dict_SensorProcessObject[TargetSensorName].Dict_DataThreshold, TargetSensorName);
            }

            this.Close();
        }

        private void Combo_DataName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_DataName.Text == "")
            {
                return;
            }
            string DataName = Combo_DataName.Text;
            NUM_OOC.Value = (decimal)Dict_Threshold[DataName + "_OOC"];
            NUM_OOS.Value = (decimal)Dict_Threshold[DataName + "_OOS"];
        }

        private void BTN_ApplyThresholdSetting_Click(object sender, EventArgs e)
        {
            string DataName = Combo_DataName.Text;
            Dict_Threshold[DataName + "_OOC"] = (double)NUM_OOC.Value;
            Dict_Threshold[DataName + "_OOS"] = (double)NUM_OOS.Value;
        }

        private void BTN_CancelThresholdSetting_Click(object sender, EventArgs e)
        {
            string DataName = Combo_DataName.Text;
            NUM_OOC.Value = (decimal)Dict_Threshold[DataName + "_OOC"];
            NUM_OOS.Value = (decimal)Dict_Threshold[DataName + "_OOS"];
        }

        private void NUM_OOC_ValueChanged(object sender, EventArgs e)
        {
            if (Combo_DataName.Text == "")
            {
                return;
            }

            string DataName = Combo_DataName.Text;
            try
            {
                Dict_Threshold[DataName + "_OOC"] = (double)NUM_OOC.Value;
            }
            catch (Exception)
            {

            }
        }

        private void NUM_OOS_ValueChanged(object sender, EventArgs e)
        {
            if (Combo_DataName.Text == "")
            {
                return;
            }

            string DataName = Combo_DataName.Text;
            try
            {
                Dict_Threshold[DataName + "_OOS"] = (double)NUM_OOS.Value;
            }
            catch (Exception)
            {

            }
        }

        private void BTN_AutoSetThreshold_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否自動設定此Sensor所有閥值", "AutoSet", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            bool IsAllReplace = MessageBox.Show("是否覆蓋原有設定，若存在的話?", "Replace Setting", MessageBoxButtons.YesNo) == DialogResult.Yes;

            BTN_AutoSetThreshold.Text = "自動設定中...";
            BTN_SaveToFile.Enabled = BTN_AutoSetThreshold.Enabled = NUM_OOC.Enabled = NUM_OOS.Enabled = false;
            Task.Run(() =>
            {
                Dict_Threshold = Systems.Staobj.Dict_SensorProcessObject[SensorName].CreateThresholdByTemData(IsAllReplace);
                this.Invoke((MethodInvoker)delegate
                {
                    Combo_DataName_SelectedIndexChanged(null, null);
                    MessageBox.Show("設定完成");
                    BTN_AutoSetThreshold.Text = "自動設定";
                    BTN_SaveToFile.Enabled = BTN_AutoSetThreshold.Enabled = NUM_OOC.Enabled = NUM_OOS.Enabled = true;
                });
            });
        }

        private void BTN_AutoSetAllSensorThreshold_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否自動設定並儲存所有Sensor", "AutoSet", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            bool IsAllReplace = MessageBox.Show("是否覆蓋原有設定，若存在的話?", "Replace Setting", MessageBoxButtons.YesNo) == DialogResult.Yes;
            BTN_AutoSetAllSensorThreshold.Text = "自動設定中...";
            BTN_AutoSetAllSensorThreshold.Enabled = false;
            Panel_ThresholdSetting.Enabled = false;
            CheckBox_ApplyToAll.Enabled = false;
            BTN_SaveToFile.Enabled = false;

            Task.Run(() =>
            {
                foreach (var item in Systems.Staobj.Dict_SensorProcessObject)
                {
                    var Dict_Threshold = item.Value.CreateThresholdByTemData(IsAllReplace);
                    foreach (var DataThreshold in Dict_Threshold)
                    {
                        Systems.Staobj.Dict_SensorProcessObject[item.Key].Dict_DataThreshold[DataThreshold.Key] = Convert.ToDouble(DataThreshold.Value);
                    }
                    Systems.Staobj.Dict_SensorProcessObject[item.Key].RefreshThreshold();
                    Systems.Staobj.SensorParam.SaveThresholdToFile(Systems.Staobj.Dict_SensorProcessObject[item.Key].Dict_DataThreshold, item.Key);
                }
                Invoke((MethodInvoker)delegate
                {
                    Combo_DataName_SelectedIndexChanged(null, null);
                    MessageBox.Show("設定完成");
                    BTN_AutoSetAllSensorThreshold.Text = "自動設定所有Sensor閥值";
                    BTN_SaveToFile.Enabled = BTN_AutoSetThreshold.Enabled = NUM_OOC.Enabled = NUM_OOS.Enabled = true;
                    Panel_ThresholdSetting.Enabled = true;
                });
            });

        }
    }
}
