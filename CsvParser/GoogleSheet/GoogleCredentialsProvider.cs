using CsvParser.GoogleSheet.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Logging;

namespace CsvParser.GoogleSheet
{
    public class GoogleCredentialsProvider : IGoogleCredentialsProvider
    {
        private static readonly string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        
        private readonly ILogger<GoogleCredentialsProvider> _logger;

        public GoogleCredentialsProvider(
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GoogleCredentialsProvider>();
        }
        
        public async Task<UserCredential> GetUserCredentialAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = new FileStream(SheetConstants.CredentialCachePath, FileMode.Open, FileAccess.Read);
            
            // The file token.json stores the user's access and refresh tokens, and is created
            // automatically when the authorization flow completes for the first time.
            
            _logger.LogInformation("Google Authorization");
            
            return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                (await GoogleClientSecrets.FromStreamAsync(stream, cancellationToken )).Secrets,
                Scopes,
                "user",
                cancellationToken, 
                new FileDataStore(SheetConstants.TokenFolder, true));
        }

        public async Task<ICredential> GetServerCredentialAsync(CancellationToken cancellationToken = default)
        {
            ICredential credential;
            
            using (var stream = new FileStream(SheetConstants.ServerKeyPath, FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleCredential.FromStreamAsync(stream, cancellationToken);
            }

            return credential;
        }
    }
}