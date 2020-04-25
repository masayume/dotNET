using CsvHelper.TypeConversion;
using CsvHelper.Configuration;
using System;

/*
The non-generic type 'ITypeConverter' cannot be used with type arguments [05-files]

CvsHelper version too new ?
*/

namespace DataProcessor
{
    class RomanTypeConverter : ITypeConverter<>
    {

        // with interface ITypeConverter must implement 2 methods: ConvertFromString, ConvertToString

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text == "I") return 1;
            if (text == "II") return 2;
            if (text == "v") return 5;

            throw new ArgumentOutOfRangeException(nameof(text));
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            throw new System.NotImplementedException();
        }

    }
}