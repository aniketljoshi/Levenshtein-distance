using System.Threading.Tasks;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Levenshtein.Distance.Core;

namespace Levenshtein.Distance.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IConfigurationProvider _configurationProvider;

        public AuthenticationService(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public async Task<LoginResponse> SignIn(LoginRequest request)
        {
            request.IsValid();

            var cognitoConfiguration = await _configurationProvider.GetAsync<CognitoConfiguration>(Constants.AppSettings.CognitoSettings);

            var cognito = new AmazonCognitoIdentityProviderClient(Utility.GetRegionEndpoint(cognitoConfiguration.Region));

            var authRequest = new InitiateAuthRequest
            {
                ClientId = cognitoConfiguration.UserPoolClientId,
                AuthFlow = AuthFlowType.USER_PASSWORD_AUTH
            };

            authRequest.AuthParameters.Add("USERNAME", request.UserName);
            authRequest.AuthParameters.Add("PASSWORD", request.Password);

            var response = await cognito.InitiateAuthAsync(authRequest);

            return new LoginResponse() { Token = response.AuthenticationResult.AccessToken };
        }
    }
}