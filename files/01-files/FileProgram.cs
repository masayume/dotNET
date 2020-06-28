using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            var command = args[0];

            if (command == "--file")
            {
                var filePath = args[1];
                WriteLine($"Single File {filePath} selected" );
                ProcessSingleFile(filePath);
            }
            else if (command == "--dir")
            {
                var directoryPath = args[1];
                var fileType = args[2];
                WriteLine($"Directory {directoryPath} selected for {fileType} files" );
                ProcessDirectory(directoryPath, fileType);
            } else {
                WriteLine("Presse enter to quit.");
                ReadLine();
            }

        }

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



    }

}
