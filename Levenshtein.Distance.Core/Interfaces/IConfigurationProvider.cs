using System.Threading.Tasks;

namespace Levenshtein.Distance.Core
{
    public interface IConfigurationProvider
    {
        Task<T> GetAsync<T>(string key);
    }
}