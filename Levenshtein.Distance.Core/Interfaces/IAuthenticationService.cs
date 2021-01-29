using System.Threading.Tasks;

namespace Levenshtein.Distance.Core
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> SignIn(LoginRequest loginRequest);
    }
}