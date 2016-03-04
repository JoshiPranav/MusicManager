using TagLib;

namespace MusicManager.Libraries
{
    public class AlbumManager : IAlbumManager
    {
        public void SetAlbumName(string filePath, string albumName)
        {
            var tagFile = File.Create(filePath);
            tagFile.Tag.Album = albumName;
            tagFile.Save();
        }
    }
}
