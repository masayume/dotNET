using CsvHelper.Configuration;


namespace DataProcessor
{
    class ProcessedOrderMap : ClassMap<ProcessedOrder>
    {
        public ProcessedOrderMap()
        {
            AutoMap(System.Globalization.CultureInfo.CreateSpecificCulture("enUS"));

            // override mapping
            Map(m => m.Customer).Name("CustomerNumber");
            Map(m => m.Amount).Name("Quantity");            

        }
    }

}
