using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Serialization;
using Serilog;
using Xmltv.Shell.Model;

namespace Xmltv.Shell
{
     [DebuggerDisplay("{Lang}:{Name} -> {List}")]
    public class ChannelInfo
    {
        public string Name { get; set; }
        
        public string List { get; set; }
        
        public string Lang { get; set; }
    }

    internal class Program
    {
        private const string Other = "_OTHER_";

        public static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            var chars = new List<string>();

            foreach (var c in alphabet)
            {
                chars.Add(c.ToString());
            }

            chars.Add(Other);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .MinimumLevel.Debug()
                .CreateLogger();

            string[] files = new[] {"d:\\xmltv-ru.xml.gz"};

            var d = new Dictionary<string, IList<ChannelInfo>>();

            foreach (var c in chars)
            {
                d.Add(c, new List<ChannelInfo>());
            }

            foreach (var file in files)
            {
                Log.Logger.Information($"The input file {file} is going to be processed");

                Tv tv;

                using (var stream = OpenFile(file))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Tv));

                    tv = (Tv) serializer.Deserialize(stream);

                    var names = tv.Channel.SelectMany(channel => channel.DisplayName
                            .Select(s => new ChannelInfo {Name = s.Value, List = file, Lang = s.Lang }))
                        .ToList();

                    foreach (var info in names)
                    {
                        var key = info.Name.ToLowerInvariant()[0].ToString();

                        if (!chars.Contains(key))
                        {
                            d[Other].Add(info);
                        }
                        else
                        {
                            d[key].Add(info);
                        }
                    }
                }

            }
            
            
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