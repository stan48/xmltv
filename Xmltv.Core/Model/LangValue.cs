using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class LangValue
    {
        [XmlAttribute("lang")]
        public string Lang { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}