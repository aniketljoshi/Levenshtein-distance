using Amazon.SecretsManager;
using Levenshtein.Distance.Core;
using System.Threading.Tasks;

namespace Levenshtein.Distance.AWS
{
    public class SecretsMangerClientFactory : ISecretsMangerClientFactory
    {
        private static IAmazonSecretsManager _client;

        public async Task<IAmazonSecretsManager> GetClientAsync(SecretsManagerConfiguration configuration)
        {
            if (_client != null)
                return _client;
            else
            {
                if (_client != null)
                    return _client;

                _client = CreateClient(configuration);
                return _client;
            }
        }

        private AmazonSecretsManagerClient CreateClient(SecretsManagerConfiguration configuration)
        {
            return new AmazonSecretsManagerClient(Utility.GetRegionEndpoint(configuration.Region));
        }
    }
}