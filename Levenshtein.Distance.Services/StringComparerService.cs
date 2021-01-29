using Levenshtein.Distance.Core;
using System.Threading.Tasks;

namespace Levenshtein.Distance.Services
{
    public class StringComparerService : IStringComparerService
    {
        private readonly IComparerProvider _comparerProvider;

        public StringComparerService(IComparerProvider comparerProvider)
        {
            _comparerProvider = comparerProvider;
        }

        public async Task<StringCompareResponse> CompareAsync(StringCompareRequest request)
        {
            request.IsValid();

            var response = await _comparerProvider.CompareAsync(request.FirstString, request.SecondString);

            return new StringCompareResponse()
            {
                OutPut = response
            };
        }
    }
}