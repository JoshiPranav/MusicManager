using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicManager.Libraries
{
    public class FileExplorer : IFileExplorer
    {
        public List<string> GetFiles(string path, List<string> filterExtensions)
        {
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                .Where(s => filterExtensions.Any(e => s.ToLower().EndsWith(e.ToLower())));

            return files.ToList();
        }
    }
}
