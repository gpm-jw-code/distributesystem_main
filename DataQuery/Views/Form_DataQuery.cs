using DataQuery.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataQuery
{
    public partial class Form_DataQuery : Form
    {
        public Form_DataQuery()
        {
            InitializeComponent();
            Functions.staobj.SystemParameters.LoadSystemParam();
            cls_SensorParametersProcess.LoadAllSensorInfos();
            RefreshSensorInfoToTreeView_SensorList();
        }

        #region TreeView (Sensor List)
        private void RefreshSensorInfoToTreeView_SensorList()
        {
            TreeView_SensorList.Nodes.Clear();

            foreach (var Dict_EdgeInfo in staobj.Dict_EdgeName_SensroInfo)
            {
                TreeView_SensorList.Nodes.Add(Dict_EdgeInfo.Key, Dict_EdgeInfo.Key);
                List<string> List_EQName = new List<string>();
                foreach (var EachSensorInfo in Dict_EdgeInfo.Value.Values)
                {
                    string EQNodeName = $"{Dict_EdgeInfo.Key}_{EachSensorInfo.EQName}";
                    if (!List_EQName.Contains(EachSensorInfo.EQName))
                    {
                        List_EQName.Add(EachSensorInfo.EQName);
                        TreeView_SensorList.Nodes[Dict_EdgeInfo.Key].Nodes.Add(EQNodeName,EachSensorInfo.EQName);
                    }
                    string SensorNodeName = $"{Dict_EdgeInfo.Key}-{EachSensorInfo.EQName}-{EachSensorInfo.SensorName}";
                    string SensorText = $"{EachSensorInfo.UnitName} || {EachSensorInfo.SensorName}";
                    TreeView_SensorList.Nodes[Dict_EdgeInfo.Key].Nodes[EQNodeName].Nodes.Add(SensorNodeName, SensorText);
                }
            }
        }

        private void TreeView_SensorList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var TargetNode = TreeView_SensorList.SelectedNode;
            if (TargetNode.Nodes.Count != 0) //選到EdgeName或EQName
            {
                return;
            }
            string EdgeName= TargetNode.FullPath.Split('\\')[0];
            string[] SensorNameArray = TargetNode.Name.Split('_');
            var TargetSensorInfo = staobj.Dict_EdgeName_SensroInfo[EdgeName][TargetNode.Name.Split('-').Last()];

            var IntervalRawData =  cls_txtQuery.QueryIntervalRawData(DateTime.Now.AddDays(-1), DateTime.Now,TargetSensorInfo);
            IntervalRawData.Downsampling(2000);
            staobj.Form_MainQueryChart.ImportSensorInfo(TargetSensorInfo);
            staobj.Form_MainQueryChart.ImportSensorDataSeries(IntervalRawData.List_DownSampleTimeLog, IntervalRawData.Dict_DownSampleData);
            staobj.Form_MainQueryChart.MdiParent = this;
            staobj.Form_MainQueryChart.Parent = SplitContainer_Sensor_Chart.Panel2;
            staobj.Form_MainQueryChart.Show();

        }
        #endregion

    }
}
