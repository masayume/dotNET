using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;

namespace DataProcessor
{
    class CsvFileProcessor
    {
        public string InputFilePath { get; }
        public string OutputFilePath { get; }

        public CsvFileProcessor(string inputFilePath, string outputFilePath)
        {
            InputFilePath = inputFilePath;
            OutputFilePath  = outputFilePath;

        }

        public void Process()
        {
            using (StreamReader input = File.OpenText(InputFilePath))
            using (CsvReader csvReader = new CsvReader(input, System.Globalization.CultureInfo.CreateSpecificCulture("enUS")))
            {
                // generic, dynamic
                // IEnumerable<dynamic> records =csvReader.GetRecords<dynamic>(); // EX: each item in this IEnumerable is a line

                // parse into entity class Order
                IEnumerable<Order> records =csvReader.GetRecords<Order>(); // EX: each item in this IEnumerable is a line
                
                // handle a blank line in CSV file
                csvReader.Configuration.TrimOptions = TrimOptions.Trim;
                csvReader.Configuration.Comment = '@';   // Default comment char is '#'
                csvReader.Configuration.AllowComments = true;
                // csvReader.Configuration.IgnoreBlankLines = false;    // BLANK lines
                // csvReader.Configuration.Delimiter = ';';             // DELIMITER  ;
                // csvReader.Configuration.HasHeaderRecord = false;     // for files with NO HEADER

                // foreach (var record in records) // var is for dynamic (generic)
                foreach (Order record in records)
                {
                        Console.WriteLine(record.OrderNumber);
                        Console.WriteLine(record.CustomerNumber);
                        Console.WriteLine(record.Description);
                        Console.WriteLine(record.Quantity);

                    /*
                        Console.WriteLine(record.Field1);
                        Console.WriteLine(record.Field2);
                        Console.WriteLine(record.Field3);
                        Console.WriteLine(record.Field4);
                    */
                }
            }

        }
    }
}