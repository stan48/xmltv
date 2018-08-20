using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class Rating
    {
        [XmlElement("value")]
        public string Value { get; set; }
       
        [XmlElement("icon")]
        public Icon[] Icon { get; set; }

        [XmlAttribute("system")]
        public string System { get; set; }
    }
}