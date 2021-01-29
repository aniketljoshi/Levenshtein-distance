using System.Net;

namespace Levenshtein.Distance.Core
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public void IsValid()
        {
            if (string.IsNullOrEmpty(this.UserName))
            {
                throw new BadRequestException(nameof(ErrorCodes.InvalidRequest), string.Format(ErrorCodes.InvalidRequest, nameof(this.UserName)), HttpStatusCode.BadRequest);
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                throw new BadRequestException(nameof(ErrorCodes.InvalidRequest), string.Format(ErrorCodes.InvalidRequest, nameof(this.Password)), HttpStatusCode.BadRequest);
            }
        }
    }
}