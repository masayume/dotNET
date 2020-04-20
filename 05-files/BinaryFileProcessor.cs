using System;
using System.IO;
using System.Linq;

namespace DataProcessor
{
    public class BinaryFileProcessor
    {
        public string InputFilePath { get;  }
        public string OutputFilePath { get;  }

        public BinaryFileProcessor(string inputFilePath, string outputFilePath)
        {
            InputFilePath = inputFilePath;
            OutputFilePath = outputFilePath;
        }

        public void Process()
        {

            // fileStream.Position specifies the position in the fileStream: 05 0F FF 5E 2A 00
            // fileStream.Position = 2;
            // int thirdByte = fileStream.ReadByte(); // FF

            // fileStream.Seek(2, SeekOrigin.Begin); // 2 is the offset; there is SeekOrigin.Current, 
            // thirdByte = fileStream.ReadByte(); // FF
            // fileStream.Seek(-3, SeekOrigin.End); // -3 is the offset; there is SeekOrigin.End as well
            // threeFromEnd = fileStream.ReadByte(); // 5E

            // Stream.CanSeek to know if the Stream supports random access. Not all do.

            using (FileStream inputFileStream = File.Open(InputFilePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader binaryStreamReader = new BinaryReader(inputFileStream))
            using (FileStream outputFileStream = File.Create(OutputFilePath))
            using (BinaryWriter binaryStreamWriter = new BinaryWriter(outputFileStream))
            {
                byte largest = 0;

                while (binaryStreamReader.BaseStream.Position < binaryStreamReader.BaseStream.Length)
                {
                    byte currentByte = binaryStreamReader.ReadByte();
                    binaryStreamWriter.Write(currentByte);

                    if (currentByte > largest)
                    {
                        largest = currentByte;
                    }
                }

                binaryStreamWriter.Write(largest);

            }

        }

        // MemoryStream overview
        // using (var MemoryStream = new MemoryStream())
        // using (var MemoryStreamWriter = new StreamWriter(memoryStream))
        // using (var fileStream = new FileStream(@"C:\data.txt", FileMode.Create))
        // {
        //      memoryStreamWriter.WriteLine("Line 1");       
        //      memoryStreamWriter.WriteLine("Line 2");       
        //      
        //      // Ensure everything is written to memory srtream
        //      memoryStreamWriter.Flush();   
        //      memoryStream.WriteTo(fileStream);   
        // }


    }
}