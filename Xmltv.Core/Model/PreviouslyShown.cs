using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class PreviouslyShown
    {
        /// <remarks />
        [XmlAttribute("start")]
        public string Start { get; set; }

        /// <remarks />
        [XmlAttribute("channel")]
        public string Channel { get; set; }
    }
}