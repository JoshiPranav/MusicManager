using System.Collections.Generic;
using System.Linq;
using TagLib;

namespace MusicManager.Libraries
{
    public class AlbumArtistManager : IAlbumArtistManager
    {
        public List<string> GetAlbumArtists(string filePath)
        {
            var tagFile = File.Create(filePath);
            return tagFile.Tag.Performers.ToList();
        }

        public void SetAlbumArtists(string filePath, List<string> artists)
        {
            var tagFile = File.Create(filePath);
            tagFile.Tag.AlbumArtists = artists.ToArray();
            tagFile.Tag.Performers = artists.ToArray();
            tagFile.Save();
        }
    }
}
