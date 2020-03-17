using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Blockchain.Api.Filters
{
    public class ApplicationExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public ApplicationExceptionFilter(
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(typeof(ApplicationExceptionFilter).Name);
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Application throwed exception: ");

            var response = new
            {
                ErrorMessage = JsonSerializer.Serialize(context.Exception),
                IsSuccess = false
            };

            context.Result = new JsonResult(response);
        }
    }
}