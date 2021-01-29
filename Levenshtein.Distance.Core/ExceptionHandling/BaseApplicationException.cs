using System;
using System.Net;

namespace Levenshtein.Distance.Core
{
    [Serializable]
    public class BaseApplicationException : Exception
    {
        public string ErrorCode { get; }
        public string ErrorMessage { get; }
        public HttpStatusCode HttpStatusCode { get; }

        public BaseApplicationException(string errorCode, string errorMessage, HttpStatusCode httpStatusCode) : base(errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            this.HttpStatusCode = httpStatusCode;
        }
    }
}