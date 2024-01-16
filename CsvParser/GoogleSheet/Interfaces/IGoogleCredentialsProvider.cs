using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;

namespace CsvParser.GoogleSheet.Interfaces
{
    public interface IGoogleCredentialsProvider
    {
        Task<UserCredential> GetUserCredentialAsync(CancellationToken cancellationToken = default);
        Task<ICredential> GetServerCredentialAsync(CancellationToken cancellationToken = default);
    }
}