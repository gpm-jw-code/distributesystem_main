﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem_Main.Systems
{
    public class cls_SensorInfo_Mqtt
    {
        public string SensorName = "";
        public string IP = "";
        public int Port = 0;
        public string SensorType = "";
        public string DataUnit = "";
    }
     
    public class cls_SensorStatus_Mqtt
    {
        public string SensorName = "";
        public bool ConnecStatus = false;
        public DateTime LastUpdateTime;

    }

    public class cls_SensorData_Mqtt
    {
        public string SensorName = "";
        public DateTime TimeLog ;
        public Dictionary<string, double> Dict_RawData = new Dictionary<string, double>();
    }
}