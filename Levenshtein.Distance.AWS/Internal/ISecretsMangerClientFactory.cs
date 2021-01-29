using Amazon.SecretsManager;
using System.Threading.Tasks;

namespace Levenshtein.Distance.AWS
{
    public interface ISecretsMangerClientFactory
    {
        Task<IAmazonSecretsManager> GetClientAsync(SecretsManagerConfiguration configuration);
    }
}