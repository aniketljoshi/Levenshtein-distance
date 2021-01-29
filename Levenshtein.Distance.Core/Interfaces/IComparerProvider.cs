using System.Threading.Tasks;

namespace Levenshtein.Distance.Core
{
    public interface IComparerProvider
    {
        Task<int> CompareAsync(string firstString, string secondString);
    }
}