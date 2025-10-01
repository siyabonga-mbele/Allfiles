using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace func
{
    public class FileParser
    {
        private readonly ILogger _logger;

        public FileParser(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FileParser>();
        }

        [Function("FileParser")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");
            response.WriteString(connectionString);

            return response;
        }
    }
}
