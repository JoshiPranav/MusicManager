using System.Collections.Generic;

namespace MusicManager.Libraries
{
    public interface IAlbumArtistManager
    {
        List<string> GetAlbumArtists(string filePath); 
        void SetAlbumArtists(string filePath, List<string> artists);
    }
}
