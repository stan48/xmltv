using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class Audio
    {
        [XmlElement("present")]
        public string Present { get; set; }
        
        [XmlElement("stereo")]
        public string Stereo { get; set; }
    }
}