using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Serilog;

namespace Xmltv.Core
{
    public class FileProcessor : ISourceProcessor
    {
        public Stream Open(XmltvSource source)
        {
            if (source.IsFile)
            {
                return OpenFile(source.Path);
            }

            throw new Exception($"Cannot process {source.Path} because it doesn't link to an existing file.");
        }
        
        private static Stream OpenFile(string inputFile)
        {
            var fileToDecompress = new FileInfo(inputFile);

            var processors = new Dictionary<string, Func<Stream, Stream>> {{".gz", ReadGzip}, {".xml", ReadXml}};

            var ext = fileToDecompress.Extension.ToLowerInvariant();

            Func<Stream, Stream> func;
            if (!processors.TryGetValue(ext, out func))
            {
                throw new Exception($"Cannot find processor for extenstion {ext}");
            }

            using (var originalFileStream = fileToDecompress.OpenRead())
            {
                Log.Logger.Information($"Input file {inputFile} was successfully extracted into memory. Stream length is {originalFileStream.Length/1024}KB");
                
                return func(originalFileStream);
            }
        }

        private static Stream ReadXml(Stream inputStream)
        {
            var ms = new MemoryStream();
                    
            try
            {
                inputStream.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                
                return ms;
            }
            catch (Exception)
            {
                ms.Dispose();
                throw;
            }
        }

        private static Stream ReadGzip(Stream inputStream)
        {
            using (GZipStream decompressionStream = new GZipStream(inputStream, CompressionMode.Decompress))
            {
                var ms = new MemoryStream();
                    
                try
                {
                    decompressionStream.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                        
                    return ms;
                }
                catch (Exception)
                {
                    ms.Dispose();
                    throw;
                }
                    
            }
        }
    }
}