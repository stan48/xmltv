using System;

namespace Xmltv.Shell
{
    public class XmltvExtension
    {
        public static readonly XmltvExtension Xml = new XmltvExtension("xml");
        
        public static readonly XmltvExtension Gz = new XmltvExtension("gz");
            
        private XmltvExtension(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static bool IsSupported(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            var normalized = value.ToLowerInvariant().Trim('.');
            
            return string.Compare(normalized, Xml.Value,StringComparison.InvariantCultureIgnoreCase) == 0 || 
                   string.Compare(normalized, Gz.Value ,StringComparison.InvariantCultureIgnoreCase)== 0;
        }
    }
}