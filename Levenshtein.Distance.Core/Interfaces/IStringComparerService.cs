using System.Threading.Tasks;

namespace Levenshtein.Distance.Core
{
    public interface IStringComparerService
    {
        Task<StringCompareResponse> CompareAsync(StringCompareRequest request);
    }
}