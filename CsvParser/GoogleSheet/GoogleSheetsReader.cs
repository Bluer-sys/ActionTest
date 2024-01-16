using CsvParser.GoogleSheet.Interfaces;
using CsvParser.Utilities;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Microsoft.Extensions.Logging;

namespace CsvParser.GoogleSheet
{
    public class GoogleSheetsReader : IGoogleSheetsReader
    {
        public const string ApplicationName = "Console Parser";

        private readonly IGoogleCredentialsProvider _credentialsProvider;
        private readonly ILogger<GoogleSheetsReader> _logger;

        public GoogleSheetsReader(
            IGoogleCredentialsProvider credentialsProvider,
            ILoggerFactory loggerFactory)
        {
            _credentialsProvider = credentialsProvider;
            _logger = loggerFactory.CreateLogger<GoogleSheetsReader>();
        }

        public async Task<IReadOnlyCollection<SheetData>> GetAsync(
            string spreadsheetId, 
            CancellationToken cancellationToken = default)
        {
            //var credentials = await _credentialsProvider.GetUserCredentialAsync(cancellationToken);
            var credentials = await _credentialsProvider.GetServerCredentialAsync(cancellationToken);
            
            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credentials,
                ApplicationName = ApplicationName,
            });
            
            // Get spreadsheet response
            _logger.LogInformation($"Get response for spreadsheet with id='{spreadsheetId}'");
            var spreadsheetResponse = await service.Spreadsheets
                .Get(spreadsheetId)
                .ExecuteDelayedAsync(cancellationToken);

            var sheets = new List<SheetData>(spreadsheetResponse.Sheets.Count);
            for (var i = 0; i < spreadsheetResponse.Sheets.Count; i++)
            {
                var sheet = spreadsheetResponse.Sheets[i];
                var sheetTitle = sheet.Properties.Title;

                _logger.LogInformation($"[{i+1}/{spreadsheetResponse.Sheets.Count}] Get response for sheet with title='{sheetTitle}'");
                var sheetResponse = await service.Spreadsheets.Values
                    .Get(spreadsheetId, sheetTitle)
                    .ExecuteDelayedAsync(cancellationToken);

                sheets.Add(new SheetData(
                    sheetTitle,
                    sheetResponse.Values));
            }

            _logger.LogInformation("Done");
            return sheets;
        }
    }
}