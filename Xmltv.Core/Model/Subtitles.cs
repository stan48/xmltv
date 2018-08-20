using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class Subtitles
    {
        [XmlElement("language")]
        public LangValue Language { get; set; }

        [XmlAttribute("type")]
        public SubtitlesType Type { get; set; }
    }
}