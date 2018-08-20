using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [XmlRoot("episode-num")]
    [Serializable]
    public class EpisodeNum
    {
        public EpisodeNum()
        {
            System = "onscreen";
        }
        
        [XmlAttribute("system")]
        [DefaultValue("onscreen")]
        public string System { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}