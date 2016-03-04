using System;
using MusicManager.Libraries;

namespace MusicManagerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please provide path for Music folder: ");
            var path = Console.ReadLine();
            var musicManagerService = new MusicManagerService();
            musicManagerService.Run(path);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
