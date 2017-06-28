using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using LiduinaAzureFunctionModels;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Liduina.UserFunctions
{
    public class StoreOauthKey
    {
        public static void Run(HttpRequestMessage req, ICollector<OauthKey> outTable, TraceWriter log)
        {
            
            
        }

        private static string getRsaPublicKey()
        {
            var adClientId = ConfigurationManager.AppSettings["LiduinaADClientID"];
            var adKey = ConfigurationManager.AppSettings["LiduinaADKey"];

            // Create a Key Vault client with an Active Directory authentication callback
            KeyVaultClient.AuthenticationCallback callback = (authority, resource, scope) => GetTokenFromClientSecret(authority, resource, adClientId, adKey);
            var keyVault = new KeyVaultClient(callback);

            var publicKeyRsaUrl = ConfigurationManager.AppSettings["PublicRsaKeyUrl"];
            var apiKey = keyVault.GetSecretAsync(publicKeyRsaUrl).Result.Value;
            return apiKey;
        }

        private static async Task<string> GetTokenFromClientSecret(string authority, string resource, string clientId, string clientSecret)
        {
            var authContext = new AuthenticationContext(authority);
            var clientCred = new ClientCredential(clientId, clientSecret);
            var result = await authContext.AcquireTokenAsync(resource, clientCred);
            return result.AccessToken;
        }
    }
}