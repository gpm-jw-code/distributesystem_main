using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Systems.cls_MQTTModule.BuildServer("127.0.0.1", 1883);
        }


        #region SideBar
        private void BTN_RawData_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_Signal;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_Log;
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_SensorInfo;
        }
        #endregion

        #region Chart

        #endregion

    }
}
