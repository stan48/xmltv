﻿using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class Video
    {
        [XmlElement("present")]
        public string Present { get; set; }

        [XmlElement("colour")]
        public string Colour { get; set; }

        [XmlElement("aspect")]
        public string Aspect { get; set; }

        [XmlElement("quality")]
        public string Quality { get; set; }
    }
}