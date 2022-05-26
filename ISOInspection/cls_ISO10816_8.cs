using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOInspection
{
    public class cls_ISO10816_8:ISObase
    {
        public Enum_CompressorPart CompressorPart;
        public cls_ISO10816_8(Enum_CompressorPart ComprossorPart)
        {
            int GroupNumber = 0;
            switch (ComprossorPart)
            {
                case Enum_CompressorPart.Foundation:
                    GroupNumber = 1;
                    break;
                case Enum_CompressorPart.Frame_Top:
                    GroupNumber = 2;
                    break;
                case Enum_CompressorPart.Clyinder_Lateral:
                    GroupNumber =3;
                    break;
                case Enum_CompressorPart.Clyinder_Rod:
                    GroupNumber = 4;
                    break;
                case Enum_CompressorPart.Dampers:
                    GroupNumber = 5;
                    break;
                case Enum_CompressorPart.Piping:
                    GroupNumber = 6;
                    break;
                default:
                    break;
            }
            this.CompressorPart = ComprossorPart;
            LoadGroupThreshold(Enum_ISOInspectionNumber.ISO10816_8, GroupNumber);
        }
    }
}
