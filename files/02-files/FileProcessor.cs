using static System.Console;
using System.IO;
using System;

namespace DataProcessor
{
    internal class FileProcessor
    {
        private static readonly string BackupDirectoryName = "backup";
        private static readonly string InProgressDirectoryName = "processing";
        private static readonly string CompletedDirectoryName = "complete";

        public string InputFilePath { get; }

        public FileProcessor(string filePath)
        {
            InputFilePath = filePath;
        }

        public void Process()
        {
            WriteLine($"Begin process of {InputFilePath}");

            // class: File class: http://bit.ly/psfileclass
            if (!File.Exists(InputFilePath))
            {
                WriteLine($"Error: file {InputFilePath} does not exist.");
                return;
            }

            // directory: find parent
            string rootDirectoryPath = new DirectoryInfo(InputFilePath).Parent.FullName;
            WriteLine($"Root data path is {rootDirectoryPath}");

            // directory: check directory exists
            // class: Path class: http://bit.ly/pspathclass
            string inputFileDirectoryPath = Path.GetDirectoryName(InputFilePath);            
            string backupDirectoryPath = Path.Combine(rootDirectoryPath, BackupDirectoryName);

            if(!Directory.Exists(backupDirectoryPath))
            {
                WriteLine($"Creating {backupDirectoryPath}");
                Directory.CreateDirectory(backupDirectoryPath);
            }

            // file: copying
            string inputFileName = Path.GetFileName(InputFilePath);
            string backupFilePath = Path.Combine(backupDirectoryPath, inputFileName);
            WriteLine($"Copying {inputFileName} to {backupFilePath}");
            File.Copy(InputFilePath, backupFilePath, true); // overwrite true

            // file: moving
            Directory.CreateDirectory(Path.Combine(rootDirectoryPath, InProgressDirectoryName));
            string inProgressFilePath = 
                Path.Combine(rootDirectoryPath, InProgressDirectoryName, inputFileName);

            if (File.Exists(inProgressFilePath))
            {
                WriteLine($"ERROR: a file with name {inProgressFilePath} is already being processed");
                return;
            }            
            WriteLine($"Moving {InputFilePath} to {inProgressFilePath}");
            File.Move(InputFilePath, inProgressFilePath);

            // file: extension -> how to process, determine type of file
            string extension = Path.GetExtension(InputFilePath);
            switch(extension)
            {
                case ".txt":
                    ProcessTextFile(inProgressFilePath);
                    break;
                default:
                    WriteLine($"{extension} is an unsupported file type.");
                    break; 
                
            }

            string completedDirectoryPath = Path.Combine(rootDirectoryPath, CompletedDirectoryName);
            Directory.CreateDirectory(completedDirectoryPath);
            WriteLine($"Moving {inProgressFilePath} to {completedDirectoryPath}");
            // File.Move(inProgressFilePath, Path.Combine(completedDirectoryPath, inputFileName));

            var completedFileName = 
                $"{Path.GetFileNameWithoutExtension(InputFilePath)}-{Guid.NewGuid()}{extension}";
            completedFileName = Path.ChangeExtension(completedFileName, ".complete");

            var completedFilePath = Path.Combine(completedDirectoryPath, completedFileName);
            File.Move(inProgressFilePath, completedFilePath);

            // directory: delete 
            // string inProgressDirectoryPath = Path.GetDirectoryName(inProgressFilePath);
            // Directory.Delete(inProgressDirectoryPath, true); // delete contents of directory too
        }

        private void ProcessTextFile(string inProgressFilePath)
        {
            WriteLine($"Processing text file  {inProgressFilePath}");
            // Read in and process
        }
    }

}
