using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [XmlRoot("length")]
    [Serializable]
    public class Length
    {
        [XmlAttribute("units")]
        public LengthUnits Units { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}