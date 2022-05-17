using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cls_PostgreSQL_Tool
{
    public static class StaString
    {
        public enum CShartDataType
        {
            IntData, DoubleData, StringData, DateTime, DoubleDataArray, JSONString, booleandata
        }


        public static string DataTypeToSQLString(CShartDataType TargetDataType)
        {
            switch (TargetDataType)
            {
                case CShartDataType.IntData:
                    return "integer";
                case CShartDataType.DoubleData:
                    return "double precision";
                case CShartDataType.StringData:
                    return "varchar";
                case CShartDataType.DateTime:
                    return "timestamp(3)";
                case CShartDataType.DoubleDataArray:
                    return "double precision[]";
                case CShartDataType.JSONString:
                    return "json";
                case CShartDataType.booleandata:
                    return "boolean";
                default:
                    break;
            }
            return "text";
        }
    }
}
