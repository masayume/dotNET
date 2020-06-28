using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Caching;

// to install System.Runtime.Caching 
// 1 - install Nuget Package Manager
//   CTRL+P -> ext install jmrog.vscode-nuget-package-manager
// 2 - press F1, search: nuget package manager: add package
//   enter System.Runtime.Caching and proceed
// 3 - restore from terminal
// dotnet restore
// 4 - add reference at build time: -reference:System.Runtime.Caching.dll
// csc -t:exe -define:DEBUG -reference:System.Runtime.Caching.dll -out:files.exe FileProgram.cs FileProcessor.cs

// DIR: ~/DATA/E/Temp/demon/unity/dotNET/02-files/
// mono files.exe <DIRECTORY>
// mono files.exe in


namespace DataProcessor
{
    class FileProgram
    {
        // avoid duplicate file systemevents
        // private static ConcurrentDictionary<string, string> FilesToProcess = new ConcurrentDictionary<string, string>();
        
        private static MemoryCache filesToProcess = MemoryCache.Default;

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

                ProcessExistingFiles(directoryToWatch);

                using (var inputFileWatcher = new FileSystemWatcher(directoryToWatch))

                {
                    inputFileWatcher.IncludeSubdirectories = false;
                    // inputFileWatcher.InternalBufferSize = 32768; // 32 Kb
                    inputFileWatcher.Filter = "*.*";

                    // inputFileWatcher.NotifyFilter = NotifyFilters.LastWrite; // events only when written
                    inputFileWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite; // catch certain events

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

        private static void ProcessExistingFiles(string inputDirectory)
        {
            WriteLine($"Checking {inputDirectory} for existing files");

            foreach(var filePath in Directory.EnumerateFiles(inputDirectory))
            {
                WriteLine($"  - Found {filePath}");
                AddToCache(filePath);

            }
        }

        private static void FileCreated(object sender, FileSystemEventArgs e)
        {
            WriteLine($"* File created: {e.Name} - type: {e.ChangeType}");

            // these cause duplicate events
            // var fileProcessor = new FileProcessor(e.FullPath);
            // fileProcessor.Process();

            AddToCache(e.FullPath);
        }

        private static void FileChanged(object sender, FileSystemEventArgs e)
        {
            WriteLine($"* File changed: {e.Name} - type: {e.ChangeType}");

            // these cause duplicate events
            // var fileProcessor = new FileProcessor(e.FullPath);
            // fileProcessor.Process();

            AddToCache(e.FullPath);
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


        private static void AddToCache(string fullPath)
        {
            var item = new CacheItem(fullPath, fullPath);

            var policy = new CacheItemPolicy
            {
                RemovedCallback = ProcessFile,
                SlidingExpiration = TimeSpan.FromSeconds(2),
            };

            filesToProcess.Add(item, policy);
        }

        private static void ProcessFile(CacheEntryRemovedArguments args)
        {
            WriteLine($"* Cache item removed: {args.CacheItem.Key} because {args.RemovedReason}");

            // check in object is expired
            if (args.RemovedReason == CacheEntryRemovedReason.Expired)
            {
                var fileProcessor = new FileProcessor(args.CacheItem.Key);
                fileProcessor.Process();
            }
            else
            {
                WriteLine($"WARNING: {args.CacheItem.Key} was removed unexpectedly and may not be available");
            }

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
