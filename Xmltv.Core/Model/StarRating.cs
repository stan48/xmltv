using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class StarRating
    {
        [XmlElement("value")]
        public string Value { get; set; }

        [XmlElement("icon")]
        public Icon[] Icon { get; set; }

        [XmlAttribute("system")]
        public string System { get; set; }
    }
}