using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class Credits
    {
        [XmlElement("director")]
        public string[] Director { get; set; }

        [XmlElement("actor")]
        public Actor[] Actor { get; set; }

        [XmlElement("writer")]
        public string[] Writer { get; set; }

        [XmlElement("adapter")]
        public string[] Adapter { get; set; }

        [XmlElement("producer")]
        public string[] Producer { get; set; }

        [XmlElement("composer")]
        public string[] Composer { get; set; }

        [XmlElement("editor")]
        public string[] Editor { get; set; }

        [XmlElement("presenter")]
        public string[] Presenter { get; set; }

        [XmlElement("commentator")]
        public string[] Commentator { get; set; }

        [XmlElement("guest")]
        public string[] Guest { get; set; }
    }
}