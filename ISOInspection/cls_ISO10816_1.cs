using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOInspection
{
    public class cls_ISO10816_1:ISObase
    {
        public Enum_Power PowerType;
        public Enum_BaseType BaseType;
        public cls_ISO10816_1(Enum_Power PowerType,Enum_BaseType BaseType)
        {
            int GroupNumber = 0;
            switch (PowerType)
            {
                case Enum_Power.Up_to_15K:
                    GroupNumber = 1;
                    break;
                case Enum_Power.Up_to_75K:
                    GroupNumber = 2;
                    break;
                case Enum_Power.More_than_75K:
                    GroupNumber = 3;
                    break;
                default:
                    break;
            }
            switch (BaseType)
            {
                case Enum_BaseType.Rigid:
                    GroupNumber += 0;
                    break;
                case Enum_BaseType.Flexible:
                    GroupNumber += 1;
                    break;
                default:
                    break;
            }
            this.BaseType = BaseType;
            this.PowerType = PowerType;
            LoadGroupThreshold(Enum_ISOInspectionNumber.ISO10816_1, GroupNumber);
        }
    }
}
