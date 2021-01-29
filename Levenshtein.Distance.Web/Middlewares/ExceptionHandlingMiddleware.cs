using Levenshtein.Distance.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Levenshtein.Distance.Web
{
    public class ExceptionHandlingMiddleware
    {
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private readonly RequestDelegate _next;

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(exception, httpContext);
            }
        }

        public async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var appEx = exception as BaseApplicationException;
            ErrorInfo errorInfo = null;
            if (appEx != null)
            {
                errorInfo = ToErrorInfo(appEx);
                context.Response.StatusCode = (int)appEx.HttpStatusCode;
            }
            else
            {
                errorInfo = GetInternalServerError(context);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorInfo, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), Converters = new List<JsonConverter> { new ErrorInfoTranslator() } }));
        }

        #region Private Methods

        private ErrorInfo GetInternalServerError(HttpContext context)
        {
            return new ErrorInfo("550", "System error");
        }

        private static ErrorInfo ToErrorInfo(BaseApplicationException exception)
        {
            var errorInfo = new ErrorInfo(exception.ErrorCode, exception.ErrorMessage, exception.HttpStatusCode);
            return errorInfo;
        }

        #endregion Private Methods
    }
}