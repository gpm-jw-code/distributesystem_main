﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataProcess
{
    public class StaticParameters
    {
        public static int TemDataNumber = 1000;
        private static string _DataSaveRootPath = "";
        public static string DataSaveRootPath
        {
            set { _DataSaveRootPath = value; }
        }

        public static string RawDataSaveRootPath
        {
            get { return Path.Combine(_DataSaveRootPath, "RawData"); }
        }

        public static string LogDataSaveRootPath
        {
            get { return Path.Combine(_DataSaveRootPath, "Log"); }
        }
    }

    public class cls_SensorDataProcess
    {
        private Dictionary<string, Queue<double>> Dict_SensorDataSeries = new Dictionary<string, Queue<double>>();
        private Queue<DateTime> Queue_TimeLog = new Queue<DateTime>();
        public SensorInfo SensorInfo = new SensorInfo();
        public SensorStatus Status = new SensorStatus();

        public Action<Queue<DateTime>, Dictionary<string, Queue<double>>> Event_SensorDataUpdate;

        public cls_SensorDataProcess(string IP, int Port, string EQName = null, string UnitName = null)
        {
            if (IP == "127.0.0.1")
                this.SensorInfo.SensorName = $"{IP}_{Port}";
            SensorInfo.IP = IP;
            SensorInfo.Port = Port;
            SensorInfo.EQName = EQName ?? "";
            SensorInfo.UnitName = UnitName ?? "";
        }

        public void ImportNewSensorData(Dictionary<string,double> Dict_NewData,DateTime TimeLog)
        {
            Queue_TimeLog.Enqueue(TimeLog);
            foreach (var item in Dict_NewData)
            {
                string DataName = item.Key;
                if (!Dict_SensorDataSeries.ContainsKey(DataName))
                {
                    Dict_SensorDataSeries.Add(DataName, new Queue<double>());
                }
                Dict_SensorDataSeries[DataName].Enqueue(item.Value);
            }
            while (Queue_TimeLog.Count>StaticParameters.TemDataNumber)
            {
                Queue_TimeLog.Dequeue();
                foreach (var item in Dict_SensorDataSeries)
                {
                    item.Value.Dequeue();
                }
            }
            Event_SensorDataUpdate?.Invoke(Queue_TimeLog, Dict_SensorDataSeries);
        }

    }

    public class SensorInfo
    {
        public string IP;
        public int Port;
        public string SensorName;
        public string EQName;
        public string SensorType;
        public string UnitName;
    }

    public class SensorStatus
    {
        public DateTime LastUpdateTime;
        public bool ConnecStatus;
    }
}
