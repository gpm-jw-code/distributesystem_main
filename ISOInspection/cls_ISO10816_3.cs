using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOInspection
{
    public class cls_ISO10816_3:ISObase
    {
        public Enum_BaseType BaseType;
        public Enum_EQType EQType;
        public cls_ISO10816_3(Enum_BaseType BaseType,Enum_EQType EQType)
        {
            int GroupNumber = 1;
            switch (EQType)
            {
                case Enum_EQType.Pump_Integrated:
                    break;
                case Enum_EQType.PumpExternal:
                    GroupNumber += 1;
                    break;
                case Enum_EQType.MediumMotor:
                    break;
                case Enum_EQType.HugeMotor:
                    GroupNumber += 1;
                    break;
                default:
                    break;
            }
            switch (BaseType)
            {
                case Enum_BaseType.Rigid:
                    break;
                case Enum_BaseType.Flexible:
                    GroupNumber += 1;
                    break;
                default:
                    break;
            }
            this.EQType = EQType;
            this.BaseType = BaseType;
            LoadGroupThreshold(Enum_ISOInspectionNumber.ISO10816_3, GroupNumber);
        }
    }
}
