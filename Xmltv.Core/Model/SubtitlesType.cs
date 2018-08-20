using System;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public enum SubtitlesType
    {
        [XmlEnum("teletext")]
        Teletext,

        [XmlEnum("onscreen")]
        OnScreen,

        [XmlEnum("deaf-signed")]
        DeafSigned
    }
}