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
            //  read file into ONE string with File.ReadAllText()
            // string originalText = File.ReadAllText(InputFilePath);      // read all text
            // string processedText = originalText.ToUpperInvariant();     // processing
            // File.WriteAllText(OutputFilePath, processedText);           // write file

            //  read file into an array of rows and process 2nd line with File.ReadAllLines()
            string[] lines = File.ReadAllLines(InputFilePath);
            lines[1] = lines[1].ToUpperInvariant();
            File.WriteAllLines(OutputFilePath, lines);

            // specify text encoding (Encoding.UTF8 default); Must be:     using System.Text
            // AppendAllText(filename, string); 1: opens/creates filename, 2: appends string, 3: closes file

            // IEnumerable<string> lines = new string[] {"line1", "line2"};
            // AppendAllLines(filename, lines); 1: opens/creates filename, 2: appends lines, 3: closes file



        }
    }

}