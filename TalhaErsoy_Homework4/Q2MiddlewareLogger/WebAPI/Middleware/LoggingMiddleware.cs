using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;

namespace WebAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();

        }

        public async Task Invoke(HttpContext context)
        {
            await LogRequest(context);
            await LogResponse(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();
            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);
            string requestBody;
            requestStream.Position = 0;
            using (StreamReader streamReader = new StreamReader(requestStream))
            {
                requestBody = streamReader.ReadToEnd();
            }

            using (StreamWriter w = File.AppendText("Request.txt"))
            {
                w.Write($"Request Information: " +"  "+
                        
                        $"Time : {DateTime.Now}" +"     "+
                        $"Request Body : {requestBody}{Environment.NewLine} ");
            }

            ;

            context.Request.Body.Position = 0;
        }

        private async Task LogResponse(HttpContext context)
        {
            var bodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;


            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            using (StreamWriter w = File.AppendText("Response.txt"))
            {
                w.Write($"Http Response Information:"+"    " +
                        $"Time : {DateTime.Now}"+"   "+
                        $"Response Body: {text}{Environment.NewLine}");
            }
               
           
            await responseBody.CopyToAsync(bodyStream);
        }
    }
}
