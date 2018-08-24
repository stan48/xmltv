using System;
using System.IO;

namespace Xmltv.Core
{
    public class SourceProcessor : ISourceProcessor
    {
        private FileProcessor _fileProcessor;

        private UrlProcessor _urlProcessor;
        
        public SourceProcessor()
        {
            _fileProcessor = new FileProcessor();
            _urlProcessor = new UrlProcessor(_fileProcessor);
        }


        public Stream Open(XmltvSource source)
        {
            if (source.IsFile)
            {
                return _fileProcessor.Open(source);
            }

            if (source.IsUrl)
            {
                return _urlProcessor.Open(source);
            }

            throw new Exception($"Cannot process source {source.Path} because it doesn't look as a file or URL");
        }
    }
}