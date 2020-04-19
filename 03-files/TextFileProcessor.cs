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
            // read all text
            string originalText = File.ReadAllText(InputFilePath);

            // processing
            string processedText = originalText.ToUpperInvariant();

            File.WriteAllText(OutputFilePath, processedText);

        }
    }

}