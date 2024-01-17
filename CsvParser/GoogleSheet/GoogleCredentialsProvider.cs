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
            
            
            
            using (var stream = new FileStream(SheetConstants.GetKeyPath(), FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromJson("{\"type\": \"service_account\",\"project_id\": \"high-ground-409611\",\"private_key_id\": \"cf68a539f6061f608ebabaca3ff951fcc377c41e\",\"private_key\": \"-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDANJpyzxV9xlTf\nxIZjeACCkMwbYW4lKfjXNbJ2RJ0PwTQotvLlFjcCwssmr4EkPyw3yT7dTvw0uhDf\nWMCIeAfjbo3yQjhr3D0q0BDZGgEYfsat9adw5a4CAzTlLj9+k60cTXn7/MosiaM4\napgxDVninaadTeQmKpPU65gWn3gTj2BNntzK82osigebdhJ9gxpJTdk7LrPFdIJi\n42inPIPz+W56rV34BmaJ0+UvpqGhTTcWrOnj1kzeesSnpaRxzZbBcFF/YNrYw47O\n03XGDa3jTu1ymt/B1V23gmvivBFJKhdR7bKEqgYXAevkgcCXIDJJAAzLleY7S6GR\nEZgKr3itAgMBAAECggEAL2Oo4v7A90JTwdpEIjk/svF9iZCzphEbrAAu0K8pJG3H\n7PPynl4kURdzHEYwap3yyoxhZhJn554qs86/pcYmd8JV2DHQlHN4V1p2lPiu5Xm4\nhcKoNpNCnHdq7sjA2fYSPAS0O1eAB4wmBK5veMSocVHadzVxt6FO0rQFyyolYnjN\nUnAIBSkqWQeTW7h2/QcmWSW0MqwPWJBZPnYpMPCsNPt/6DcSCmW2Ii4Pv6KMIV4u\n9xMOY4Rg+wC86sPlaF0k0pF/+Lj4mI6SOCSVlnQiZaPjfQbNC6QKMKSy3ZJKQCZw\n+Ce1dk0CoRwaqoAeUwA6QYB6zI70Z2wcd/+uWZ/iBwKBgQDnsAbWFm6X30GSB/3z\nGA2t1KdA/Mqqh+9hn5J0P/p9mfaJOqN5/+uLrRNoV56b6ycRob6WvfojGP/Kp6F6\nPDS1is77uF+gXTqGCZGdMBOQTvtAJwaY58UtHzlTHqqxwFFDxOOeXWR793Wlp3MQ\nHWMH/oK7cPsIlFiQR49LiJMSxwKBgQDUX/FjvY3qTxciOp3DLpN+6Hp/fav4oH0P\nGdg2XUNaca97y53GAKXy05+LDU6NJ7cIoFEbWPUhwbbVOGme/gjnLMlcplRUAVnb\ncK6i+vL/F8/QKsmUX2/IFVARSqbzRaE5KKmyFbG3jyiX6mxlWIwCD9OucnXnkmST\nqnNEJWzk6wKBgApndjcg9MBvLyOepkHHX73hoc0iTPuRdSd+IfaEdPw08MRC1NqC\nqpIwKIH0BVRdH/kDuWpNh7ERy1LPaknx8DAC1r6pDepGpX0latuTMB233kKIPhyZ\ns9oN3+Yip2mqCDwx2ELhUMTcXPUeauVbXHocbMR8E1nUR5HbFM1AidI7AoGBAMCe\n2IC/XyUiYPgRtB9gcjTLxLc3k6+oWGVG6py8UCeLLz+X+VyqH9mzaWQkSJesas1v\nIsEsGQFqAls3lEy5Wffa3jOjRJ8ArrBibnKyK42E2l6TQEvLl8Yg1oMoc234PHds\nUyWLmanENWw8Gd59xlbkZfk2JYxIceKg2XT4gODLAoGAey35uukxZ7UQGuA06F4n\nWKd7js+TJ94yUshb00/+6Q/jklT+wJvsW0W2m+yLKkaqhce27JIppsuJtUrCQnd5\nBytqPzWyCzZd4p2DdYOBPu79aR7FSl4d6Wcn9UAB/3pbLLV1jDACja+gjcjMThtt\ndSbiPhZShqcAgbg3mcvJap8=\n-----END PRIVATE KEY-----\n\",\"client_email\": \"scv-to-json@high-ground-409611.iam.gserviceaccount.com\",\"client_id\": \"117688350706920264402\",\"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\"token_uri\": \"https://oauth2.googleapis.com/token\",\"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/scv-to-json%40high-ground-409611.iam.gserviceaccount.com\",\"universe_domain\": \"googleapis.com\"}");
                //credential = await GoogleCredential.FromStreamAsync(stream, cancellationToken);
            }

            return credential;
        }
    }
}