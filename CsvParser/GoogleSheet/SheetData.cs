using CsvParser.GoogleSheet.Interfaces;

namespace CsvParser.GoogleSheet
{
    public class SheetData : ISheet
    {
        public string Title { get; }
        public IList<IList<object>> Values { get; }

        public SheetData(string title, IList<IList<object>> values)
        {
            Title = title;
            Values = values;
        }
    }
}