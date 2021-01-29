using System;
using System.Net;

namespace Levenshtein.Distance.Core
{
    [Serializable]
    public partial class BadRequestException : BaseApplicationException
    {
        public BadRequestException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode)
        {
        }
    }
}