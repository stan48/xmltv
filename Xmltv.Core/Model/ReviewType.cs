using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public enum ReviewType
    {
        [XmlEnum("text")] 
        Text,

        [XmlEnum("url")] 
        Url
    }
}