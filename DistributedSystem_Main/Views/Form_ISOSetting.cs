using DistributedSystem_Main.Systems;
using ISOInspection;
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
    public partial class Form_ISOSetting : Form
    {
        private string SensorName = null;

        private string SensorType = null;

        public Form_ISOSetting(SensorDataProcess.SensorInfo SensorInfo)
        {
            InitializeComponent();
            COMBO_ISONumber.Items.Add(Enum_ISOInspectionNumber.ISO10816_1);
            COMBO_ISONumber.Items.Add(Enum_ISOInspectionNumber.ISO10816_3);
            COMBO_ISONumber.Items.Add(Enum_ISOInspectionNumber.ISO10816_8);

            this.LAB_SensorIP.Text = SensorInfo.SensorName;
            this.LAB_EQName.Text = SensorInfo.EQName;
            this.LAB_UnitName.Text = SensorInfo.UnitName;
            this.LAB_SensorType.Text = SensorInfo.SensorType;
            this.SensorName = SensorInfo.SensorName;
            this.SensorType = SensorInfo.SensorType;
        }

        private void COMBO_ISONumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            COMBO_Condition1.Items.Clear();
            COMBO_Condition2.Items.Clear();
            switch ((Enum_ISOInspectionNumber)COMBO_ISONumber.SelectedItem)
            {
                case Enum_ISOInspectionNumber.ISO10816_1:
                    LAB_Condition1.Text = "Power Type :";
                    LAB_Condition2.Text = "Base Type :";
                    COMBO_Condition1.Items.Add(Enum_Power.Up_to_15K);
                    COMBO_Condition1.Items.Add(Enum_Power.Up_to_75K);
                    COMBO_Condition1.Items.Add(Enum_Power.More_than_75K);
                    COMBO_Condition2.Items.Add(Enum_BaseType.Flexible);
                    COMBO_Condition2.Items.Add(Enum_BaseType.Rigid);
                    break;
                case Enum_ISOInspectionNumber.ISO10816_3:
                    LAB_Condition1.Text = "Base Type :";
                    LAB_Condition2.Text = "EQ Type :";
                    COMBO_Condition1.Items.Add(Enum_BaseType.Flexible);
                    COMBO_Condition1.Items.Add(Enum_BaseType.Rigid);
                    COMBO_Condition2.Items.Add(Enum_EQType.HugeMotor);
                    COMBO_Condition2.Items.Add(Enum_EQType.MediumMotor);
                    COMBO_Condition2.Items.Add(Enum_EQType.PumpExternal);
                    COMBO_Condition2.Items.Add(Enum_EQType.Pump_Integrated);
                    break;
                case Enum_ISOInspectionNumber.ISO10816_8:
                    LAB_Condition1.Text = "Comprossor Part :";
                    LAB_Condition2.Text = "None :";
                    COMBO_Condition1.Items.Add(Enum_CompressorPart.Clyinder_Lateral);
                    COMBO_Condition1.Items.Add(Enum_CompressorPart.Clyinder_Rod);
                    COMBO_Condition1.Items.Add(Enum_CompressorPart.Dampers);
                    COMBO_Condition1.Items.Add(Enum_CompressorPart.Foundation);
                    COMBO_Condition1.Items.Add(Enum_CompressorPart.Frame_Top);
                    COMBO_Condition1.Items.Add(Enum_CompressorPart.Piping);
                    break;
                default:
                    break;
            }
        }

        private void BTN_SaveISOParameters_Click(object sender, EventArgs e)
        {
            List<string> List_SensorName = new List<string>();
            if (CheckBox_SaveThresholdToAllSensor.Checked)
            {
                List_SensorName = Staobj.Dict_SensorProcessObject.Keys.ToList();
            }
            else if (CheckBox_SetThresholdToFilterSensor.Checked)
            {
                //List_SensorName = (from item in Systems.Staobj.Dict_SensorProcessObject
                //                   where Staobj.ISOPageParameters.List_FilterSensorName.Contains(item.Key)
                //                         select item.Key).ToList();
            }
            else
            {
                List_SensorName.Add(SensorName);
            }
            foreach (var EachSensorName in List_SensorName)
            {
                switch ((Enum_ISOInspectionNumber)COMBO_ISONumber.SelectedItem)
                {
                    case Enum_ISOInspectionNumber.ISO10816_1:
                        var ISO_1Info = new cls_ISO10816_1((Enum_Power)COMBO_Condition1.SelectedItem, (Enum_BaseType)COMBO_Condition2.SelectedItem);
                        Staobj.Dict_SensorProcessObject[EachSensorName].ISOCheckObject = ISO_1Info;
                        Staobj.SensorParam.SaveISOParameters(EachSensorName, ISO_1Info);
                        break;
                    case Enum_ISOInspectionNumber.ISO10816_3:
                        var ISO_3Info = new cls_ISO10816_3((Enum_BaseType)COMBO_Condition1.SelectedItem, (Enum_EQType)COMBO_Condition2.SelectedItem);
                        Staobj.Dict_SensorProcessObject[EachSensorName].ISOCheckObject = ISO_3Info;
                        Staobj.SensorParam.SaveISOParameters(EachSensorName, ISO_3Info);
                        break;
                    case Enum_ISOInspectionNumber.ISO10816_8:
                        var ISO_8Info = new cls_ISO10816_8((Enum_CompressorPart)COMBO_Condition1.SelectedItem);
                        Staobj.Dict_SensorProcessObject[EachSensorName].ISOCheckObject = ISO_8Info;
                        Staobj.SensorParam.SaveISOParameters(EachSensorName, ISO_8Info);
                        break;
                    default:
                        break;
                }
                if (Staobj.Dict_SensorProcessObject[EachSensorName].List_DataNames.Count == 1)
                {
                    Staobj.Dict_SensorProcessObject[EachSensorName].ISOCheckDataName = Staobj.Dict_SensorProcessObject[EachSensorName].List_DataNames[0];
                }
                Staobj.Dict_SensorProcessObject[EachSensorName].SensorInfo.ISONumber = (Enum_ISOInspectionNumber)COMBO_ISONumber.SelectedItem;
                Staobj.Dict_SensorProcessObject[EachSensorName].RefreshISOChart();
                Staobj.SensorParam.SaveSensorInfoToFile(Staobj.Dict_SensorProcessObject[EachSensorName].SensorInfo);
            }
            if (MessageBox.Show("已儲存並套用設定，是否要關閉視窗","Exit",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form_ISOSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
