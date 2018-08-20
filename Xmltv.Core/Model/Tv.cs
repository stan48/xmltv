using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    [XmlRoot(IsNullable = false, ElementName = "tv")]
    public class Tv
    {
        [XmlElement("channel")]
        public Channel[] Channel  { get; set; }

        [XmlElement("programme")]
        public Programme[] Programme  { get; set; }

        [XmlAttribute("date")]
        public string Date  { get; set; }

        [XmlAttribute("source-info-url")]
        public string SourceInfoUrl  { get; set; }

        [XmlAttribute("source-info-name")]
        public string SourceInfoName { get; set; }

        [XmlAttribute("source-data-url")]
        public string SourceDataUrl  { get; set; }

        [XmlAttribute("generator-info-name")]
        public string GeneratorInfoName  { get; set; }

        [XmlAttribute("generator-info-url")]
        public string GeneratorInfoUrl  { get; set; }
    }
}