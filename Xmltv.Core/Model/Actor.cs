using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class Actor
    {
        [XmlAttribute("role")]
        public string Role { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}