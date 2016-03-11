using System.Collections.Generic;
using System.IO;

namespace MusicManager.Libraries
{
    public class MusicManagerService : IMusicManagerService
    {
        private readonly IFileExplorer _fileExplorer;
        private readonly IAlbumManager _albumManager;
        private readonly IAlbumArtistManager _albumArtistManager;

        public List<string> MusicFileExtensions {
            get
            {
                return new List<string> { ".mp3", ".mp4", ".wav" };
            }
        }
        
        public MusicManagerService() : this(new FileExplorer(), new AlbumManager(), new AlbumArtistManager())
        {
        }

        public MusicManagerService(IFileExplorer fileExplorer, IAlbumManager albumManager, IAlbumArtistManager albumArtistManager)
        {
            _fileExplorer = fileExplorer;
            _albumManager = albumManager;
            _albumArtistManager = albumArtistManager;
        }

        public void Run(string musicFolderpath)
        {
            var musicFiles = _fileExplorer.GetFiles(musicFolderpath, MusicFileExtensions);
            foreach (var musicFile in musicFiles)
            {
                var directoryPath = Path.GetDirectoryName(musicFile);
                var directoryName = Path.GetFileName(directoryPath);
                _albumManager.SetAlbumName(musicFile, directoryName);

                var musicFilesInThisAlbum = _fileExplorer.GetFiles(directoryPath, MusicFileExtensions);
                var albumArtists = new List<string>();
                foreach (var musicFileInThisAlbum in musicFilesInThisAlbum)
                {
                    var artists = _albumArtistManager.GetAlbumArtists(musicFileInThisAlbum);
                    foreach (var artist in artists)
                    {
                        if (!albumArtists.Contains(artist))
                        {
                            albumArtists.Add(artist);
                        }
                    }
                }
                _albumArtistManager.SetAlbumArtists(musicFile, albumArtists);
            }
        }
    }
}
