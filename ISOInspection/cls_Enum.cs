using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOInspection
{
    public enum Enum_ISOInspectionNumber
    {
        None,ISO10816_1, ISO10816_3, ISO10816_8
    }
    public enum Enum_EQType
    {
        Pump_Integrated,PumpExternal,MediumMotor,HugeMotor
    }

    public enum Enum_Power
    {
        Up_to_15K,Up_to_75K,More_than_75K
    }

    public enum Enum_BaseType
    {
        Rigid,Flexible
    }

    public enum Enum_CompressorPart
    {
        Foundation,Frame_Top,Clyinder_Lateral,Clyinder_Rod,Dampers,Piping
    }


    public enum ResultLevel
    {
        A,B,C,D
    }

}
