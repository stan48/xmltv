using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Serilog;

namespace Xmltv.Core
{
    public class UrlProcessor : ISourceProcessor
    {
        private const ushort GzipLeadBytes = 0x8b1f;
        
        private readonly ISourceProcessor _processor;

        public UrlProcessor(FileProcessor fileProcessor)
        {
            _processor = fileProcessor;
        }

        public Stream Open(XmltvSource source)
        {
            if (!source.IsUrl)
            {
                throw new Exception($"Cannot process source {source.Path} because it doesn't look as URL.");
            }
            
            var uri = new Uri(source.Path);
            
            var tempPath = Path.GetTempFileName();

            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
            
            var r = HttpWebRequest.CreateHttp(uri);

            string responseType;

            using (var resp = r.GetResponse())
            {
                responseType = resp.ContentType;

                var length = resp.ContentLength;
                
                Log.Logger.Information($"Stream '{uri}' is ready for download. \nContent type: {responseType}\nLength: {length/1024}Kb");

                using (var stream = resp.GetResponseStream())
                {
                    if (stream == null)
                    {
                      Log.Logger.Error("Cannot read response stream from the server");
                    }
                    else
                    {
                        using (var dest = new FileStream(tempPath, FileMode.Create))
                        {
                            int counter = 0;
                            var buffer = new byte[4096];

                            long percentage = 0;
                            
                            while (counter < length)
                            {
                                var readBytes = stream.Read(buffer, 0, buffer.Length);
                                
                                dest.Write(buffer, 0, readBytes);
                                
                                counter += readBytes;

                                int z = (int)(counter / (length / 100));

                                if (percentage != z)
                                {
                                    Log.Information($"Counter: {counter/1024} of {length/1024} ({z}%)");
                                    percentage = z;
                                }
                            }
                        }
                       
                    }
                }
            }
            
            var fileName = uri.AbsoluteUri.Split('/').LastOrDefault();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = tempPath + DetermineFileExtension(tempPath, responseType);
            }
            
            File.Move(tempPath, fileName);
         
            return _processor.Open(new XmltvSource(fileName, source.Priority));
        }

        private string DetermineFileExtension(string path, string contentType)
        {
            if (contentType?.ToLowerInvariant().Contains("xml") == true)
            {
                return ".xml";
            }


            using (var data = File.OpenRead(path))
            {
                var buffer = new byte[2];

                data.Read(buffer, 0, 2);

                if (BitConverter.ToUInt16(buffer, 0) == GzipLeadBytes)
                {
                    return ".gz";
                }
            }

            return null;
        }


    }
}