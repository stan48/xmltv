using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Serilog;
using Xmltv.Core;
using Xmltv.Shell.Model;

namespace Xmltv.Shell
{
    internal class Program
    {
        private const string Other = "_OTHER_";


        static Program()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .MinimumLevel.Debug()
                .CreateLogger();
        }

        public static void Main(string[] args)
        {
            var sources = new[]
            {
                new XmltvSource(@"http://epg.iptvlive.org", 10),
                new XmltvSource(@"http://epg.it999.ru/edem.xml.gz", 100),
                new XmltvSource(@"http://programtv.ru/xmltv.xml.gz", 30)
            };
            
            string alphabet = "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            var chars = new List<string>();

            foreach (var c in alphabet)
            {
                chars.Add(c.ToString());
            }

            chars.Add(Other);
            
            var dict = new Dictionary<string, IList<ChannelInfo>>();
            
        
            foreach (var c in chars)
            {
                dict.Add(c, new List<ChannelInfo>());
            }
            
            var processor = new SourceProcessor();

            foreach (var file in sources)
            {
                Log.Logger.Information($"The input file {file} is going to be processed");

                Tv tv;

                using (var stream = processor.Open(file))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Tv));

                    tv = (Tv) serializer.Deserialize(stream);

                    var names = tv.Channel.SelectMany(channel => channel.DisplayName
                            .Select(s => new ChannelInfo { Name = s.Value, List = file.Path, Lang = s.Lang }))
                        .ToList();

                    foreach (var info in names)
                    {
                        var key = info.Name.ToLowerInvariant()[0].ToString();

                        if (!chars.Contains(key))
                        {
                            dict[Other].Add(info);
                        }
                        else
                        {
                            dict[key].Add(info);
                        }
                    }
                }
            }
            
            var sb = new StringBuilder();

            foreach (var p in dict)
            {
                sb.AppendLine(p.Key);
                
                foreach (var channelInfo in p.Value.OrderBy(info => info.Name))
                {
                    sb.AppendLine($"{channelInfo.Name} -> {channelInfo.List}");
                }

                sb.AppendLine("----------------------------------");
            }
            
           
            File.WriteAllText("d:\\output.txt",sb.ToString());
            
            Log.Logger.Information("Parsing has been completed succseefully");
        }

     

    }
}