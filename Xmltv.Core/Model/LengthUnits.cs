using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    [XmlType]
    public enum LengthUnits
    {
        [XmlEnum(Name="seconds")]
        Seconds,
        
        [XmlEnum(Name="minutes")]
        Minutes,
        
        [XmlEnum(Name="hours")]
        Hours
    }
}