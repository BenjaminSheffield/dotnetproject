using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class HelloWorldFunction
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<HelloWorldFunction> _logger;

    public HelloWorldFunction(IConfiguration configuration, ILogger<HelloWorldFunction> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    [Function("HelloWorld")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("HelloWorld function hit");
        var greetingName = _configuration["GREETING_NAME"] ?? "World";

        _logger.LogInformation("Greeting name from config: {GreetingName}", greetingName);

        var message = "Hello, " + greetingName + "!";

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        response.WriteString(message);

        _logger.LogInformation("Done, sent response");

        return response;
    }
}
