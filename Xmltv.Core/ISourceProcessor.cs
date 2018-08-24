using System.IO;

namespace Xmltv.Core
{
    public interface ISourceProcessor
    {
        Stream Open(XmltvSource source);
    }
}