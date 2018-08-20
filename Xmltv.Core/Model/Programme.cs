using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Xmltv.Shell.Model
{
    [Serializable]
    public class Programme
    {
        [XmlElement("title")]
        public LangValue[] Title { get; set; }

        [XmlElement("sub-title")]
        public LangValue[] Subtitle { get; set; }

        [XmlElement("desc")]
        public LangValue[] Desc { get; set; }

        [XmlElement("credits")]
        public Credits Credits { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }

        [XmlElement("category")]
        public LangValue[] LangValue { get; set; }

        [XmlElement("keyword")]
        public LangValue[] Keyword { get; set; }

        [XmlElement("language")]
        public LangValue Language { get; set; }

        [XmlElement("orig-language")]
        public LangValue OrigLanguage { get; set; }

        [XmlElement("length")]
        public Length Length { get; set; }

        [XmlElement("icon")]
        public Icon[] Icon { get; set; }

        [XmlElement("url")]
        public string[] Url { get; set; }

        [XmlElement("country")]
        public LangValue[] Country { get; set; }

        [XmlElement("episode-num")]
        public EpisodeNum[] EpisodeNum { get; set; }

        [XmlElement("video")]
        public Video Video { get; set; }

        [XmlElement("audio")]
        public Audio Audio { get; set; }

        [XmlElement("previously-shown")]
        public PreviouslyShown PreviouslyShown { get; set; }

        [XmlElement("premiere")]
        public LangValue Premiere { get; set; }

        [XmlElement("last-chance")]
        public LangValue LastChance { get; set; }

        [XmlElement("new")]
        public object New { get; set; }

        [XmlElement("subtitles")]
        public Subtitles[] Subtitles { get; set; }

        [XmlElement("rating")]
        public Rating[] Rating { get; set; }

        [XmlElement("star-rating")]
        public StarRating[] StarRating { get; set; }

        [XmlElement("review")]
        public Review[] Review { get; set; }

        [XmlAttribute("start")]
        public string Start { get; set; }

        [XmlAttribute("stop")]
        public string Stop { get; set; }

        [XmlAttribute("pdc-start")]
        public string PdcStart { get; set; }

        [XmlAttribute("vps-start")]
        public string VpsStart { get; set; }

        [XmlAttribute("showview")]
        public string Showview { get; set; }

        [XmlAttribute("videoplus")]
        public string Videoplus { get; set; }

        [XmlAttribute("channel")]
        public string Channel { get; set; }

        [XmlAttribute("clumpidx")]
        [DefaultValue("0/1")]
        public string ClumpIdx { get; set; }
    }
}