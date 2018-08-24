using System.Diagnostics;

namespace Xmltv.Shell
{
    [DebuggerDisplay("{Lang}:{Name} -> {List}")]
    public class ChannelInfo
    {
        public string Name { get; set; }
        
        public string List { get; set; }
        
        public string Lang { get; set; }
    }
}