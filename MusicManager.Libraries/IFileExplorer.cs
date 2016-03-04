using System.Collections.Generic;

namespace MusicManager.Libraries
{
    public interface IFileExplorer
    {
        List<string> GetFiles(string path, List<string> filterExtensions);
    }
}
