using System.Collections.Generic;
using System.IO;

namespace MusicManager.Libraries
{
    public class MusicManagerService : IMusicManagerService
    {
        private readonly IFileExplorer _fileExplorer;
        private readonly IAlbumManager _albumManager;

        public MusicManagerService() : this(new FileExplorer(), new AlbumManager())
        {
        }

        public MusicManagerService(IFileExplorer fileExplorer, IAlbumManager albumManager)
        {
            _fileExplorer = fileExplorer;
            _albumManager = albumManager;
        }

        public void Run(string musicFolderpath)
        {
            var musicFiles = _fileExplorer.GetFiles(musicFolderpath, new List<string> {".mp3", ".mp4", ".wav"});
            foreach (var musicFile in musicFiles)
            {
                var albumName = Path.GetFileName(Path.GetDirectoryName(musicFile));
                _albumManager.SetAlbumName(musicFile, albumName);
            }
        }
    }
}
