using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class Review
    {
        [XmlAttribute("type")]
        public ReviewType Type { get; set; }

        [XmlAttribute("source")]
        public string Source { get; set; }

        [XmlAttribute("reviewer")]
        public string Reviewer { get; set; }

        [XmlAttribute("lang")]
        public string Lang { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}