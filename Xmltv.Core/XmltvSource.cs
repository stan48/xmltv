using System;
using System.IO;
using Xmltv.Shell;

namespace Xmltv.Core
{
    public class XmltvSource
    {
        public XmltvSource(string path, int priority)
        {
            Path = path;
            Priority = priority;
        }

        public string Path { get; }

        public bool IsUrl
        {
            get
            {
                if (Path.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
                {
                    return System.Uri.IsWellFormedUriString(Path, UriKind.RelativeOrAbsolute);
                }

                return false;
            }
        }
        
        

        public bool IsFile
        {
            get
            {
                 var x = new FileInfo(Path);


                return x.Exists;

            }
        }

        public int Priority { get; }

        public XmltvExtension Extension
        {
            get { return null; }
        }


    }
}