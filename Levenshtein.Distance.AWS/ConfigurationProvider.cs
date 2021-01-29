using Levenshtein.Distance.Core;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Levenshtein.Distance.AWS
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private ISecretsMangerClientFactory _clientFactory;
        private SecretsManagerConfiguration _settings;

        public ConfigurationProvider(ISecretsMangerClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _settings = new SecretsManagerConfiguration() { Region = "useast1" };
        }

        public async Task<string> GetAsStringAsync(string key)
        {
            var client = await _clientFactory.GetClientAsync(_settings);
            var response = await client.GetSecretValueAsync(new Amazon.SecretsManager.Model.GetSecretValueRequest() { SecretId = key });
            return response.SecretString;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var client = await _clientFactory.GetClientAsync(_settings);
            var response = await client.GetSecretValueAsync(new Amazon.SecretsManager.Model.GetSecretValueRequest() { SecretId = key });
            return JsonConvert.DeserializeObject<T>(response.SecretString);
        }
    }
}