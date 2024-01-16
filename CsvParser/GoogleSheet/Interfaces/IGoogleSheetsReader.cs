namespace CsvParser.GoogleSheet.Interfaces
{
    public interface IGoogleSheetsReader
    {
        Task<IReadOnlyCollection<SheetData>> GetAsync(
            string spreadsheetId, 
            CancellationToken cancellationToken = default);
    }
}