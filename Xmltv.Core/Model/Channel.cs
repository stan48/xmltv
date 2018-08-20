using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class Channel
    {
        [XmlElement("display-name")]
        public LangValue[] DisplayName { get; set; }

        [XmlElement("icon")]
        public Icon[] Icon  { get; set; }

        [XmlElement("url")]
        public string[] Url  { get; set; }

        [XmlAttribute("id")]
        public string Id  { get; set; }
    }
}