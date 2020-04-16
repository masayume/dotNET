using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// DIR: ~/DATA/E/Temp/demon/unity/dotNET/02-files/
// mono files.exe --file in/data1.txt
// mono files.exe --dir in TEXT


namespace DataProcessor
{
    class FileProgram
    {
        static void Main(string[] args)
        {
            WriteLine("Parsing command line options");

            // Command line validation goes here

            var directoryToWatch = args[0];

            if(!Directory.Exists(directoryToWatch))
            {
                WriteLine($"ERROR: directory {directoryToWatch} does not exists.");
            }
            else
            {
                WriteLine($"Watching directory {directoryToWatch} for changes.");

                using (var inputFileWatcher = new FileSystemWatcher(directoryToWatch))
                {
                    inputFileWatcher.IncludeSubdirectories = false;
                    // inputFileWatcher.InternalBufferSize = 32768; // 32 Kb
                    inputFileWatcher.Filter = "*.*";

                    // inputFileWatcher.NotifyFilter = NotifyFilters.LastWrite; // events only when written
                    inputFileWatcher.NotifyFilter = NotifyFilters.FileName; // events only when written

                    // Events handler methods
                    inputFileWatcher.Created += FileCreated;
                    inputFileWatcher.Changed += FileChanged;
                    inputFileWatcher.Deleted += FileDeleted;
                    inputFileWatcher.Renamed += FileRenamed;
                    inputFileWatcher.Error   += WatcherError;

                    inputFileWatcher.EnableRaisingEvents = true;    // switch ON. OFF by default !

                    WriteLine("Press enter to quit.");
                    ReadLine();
                }
            }
        }

        private static void FileCreated(object sender, FileSystemEventArgs e)
        {
            WriteLine($"* File created: {e.Name} - type: {e.ChangeType}");
        }

        private static void FileChanged(object sender, FileSystemEventArgs e)
        {
            WriteLine($"* File changed: {e.Name} - type: {e.ChangeType}");
        }

        private static void FileDeleted(object sender, FileSystemEventArgs e)
        {
            WriteLine($"* File deleted: {e.Name} - type: {e.ChangeType}");
        }

        private static void FileRenamed(object sender, RenamedEventArgs e)
        {
            WriteLine($"* File renamed: {e.OldName} to {e.Name} - type: {e.ChangeType}");
        }

        private static void WatcherError(object sender, ErrorEventArgs e)
        {
            WriteLine($"ERROR: file system watching may no longer be active: {e.GetException()}");
        }

/*
        private static void ProcessSingleFile(string filePath )
        {
            var fileProcessor = new FileProcessor(filePath);
            fileProcessor.Process();
        }

        private static void ProcessDirectory(string directoryPath, string fileType )
        {
            // var allFiles = Directory.GetFiles(directoryPath); // to get all the files

            switch(fileType)
            {
                case "TEXT":
                    string[] textFiles = Directory.GetFiles(directoryPath, "*.txt");
                    foreach (var textFilePath in textFiles)
                    {
                        var fileProcessor = new FileProcessor(textFilePath);
                        fileProcessor.Process();
                    }
                    break;
                default:
                    WriteLine($"ERROR: {fileType} is not supported");
                    break;
            }
        }
*/


    }

}
