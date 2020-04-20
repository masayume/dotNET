using System.IO;

namespace DataProcessor
{
    public class TextFileProcessor
    {
        public string InputFilePath { get; }
        public string OutputFilePath { get; }

        public TextFileProcessor(string inputFilePath, string outputFilePath)
        {
            InputFilePath = inputFilePath;
            OutputFilePath = outputFilePath;
        }

        public void Process()
        {
            /*
                using (var inputFileStream = new FileStream(InputFilePath, FileMode.Open))
                using (var inputStreamReader = new StreamReader(inputFileStream))
                // using (var inputStreamReader = File.OpenText(InputFilePath))
                using (var outputFileStream = new FileStream(OutputFilePath, FileMode.Create))
                using (var outputStreamWriter = new StreamWriter(outputFileStream))
            */
            using (var inputStreamReader = new StreamReader(InputFilePath))
            using (var outputStreamWriter = new StreamWriter(OutputFilePath))
            {

                /*
                // PROCESS ALL FILE

                while (!inputStreamReader.EndOfStream)
                {
                        // 1st version with explicit inputstreams
                        // string line = inputStreamReader.ReadLine();
                        // string processedLine = line.ToUpperInvariant();
                        // outputStreamWriter.WriteLine(processedLine);

                        // 2nd version - more compact
                        string line = inputStreamReader.ReadLine();
                        string processedLine = line.ToUpperInvariant();

                        bool isLastLine = inputStreamReader.EndOfStream;

                        if (isLastLine) 
                        {
                            outputStreamWriter.Write(processedLine);
                        }
                        else 
                        {
                            outputStreamWriter.WriteLine(processedLine);
                        }
                }
                */ 

                // PROCESS ONLY SECOND LINE
                var currentLineNumber = 1;
                while (!inputStreamReader.EndOfStream) 
                {
                    string line = inputStreamReader.ReadLine();

                    if (currentLineNumber == 2)
                    {
                        Write(line.ToUpperInvariant());
                    }
                    else 
                    {
                        Write(line);
                    }
                }

                currentLineNumber++;

                void Write(string content)
                {
                    bool isLastLine = inputStreamReader.EndOfStream;

                    if (isLastLine)
                    {
                        outputStreamWriter.Write(content);
                    }
                    else 
                    {
                        outputStreamWriter.WriteLine(content);
                    }
                }

            }

        }
    }

}