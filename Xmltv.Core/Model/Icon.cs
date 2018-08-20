using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class Icon
    {
        [XmlAttribute("src")]
        public string Src { get; set; }

        [XmlAttribute("width")]
        public string Width { get; set; }

        [XmlAttribute("height")]
        public string Height { get; set; }
    }
}