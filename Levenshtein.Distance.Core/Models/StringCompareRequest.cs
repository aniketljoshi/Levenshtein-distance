using System.Net;

namespace Levenshtein.Distance.Core
{
    public class StringCompareRequest
    {
        public string FirstString { get; set; }
        public string SecondString { get; set; }

        public void IsValid()
        {
            if (string.IsNullOrEmpty(this.FirstString))
            {
                throw new BadRequestException(nameof(ErrorCodes.InvalidRequest), string.Format(ErrorCodes.InvalidRequest, nameof(this.FirstString)), HttpStatusCode.BadRequest);
            }

            if (string.IsNullOrEmpty(this.SecondString))
            {
                throw new BadRequestException(nameof(ErrorCodes.InvalidRequest), string.Format(ErrorCodes.InvalidRequest, nameof(this.SecondString)), HttpStatusCode.BadRequest);
            }
        }
    }
}