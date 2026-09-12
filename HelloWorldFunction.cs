using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;

public class HelloWorldFunction
{
    private readonly IConfiguration _configuration;

    public HelloWorldFunction(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [Function("HelloWorld")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        Console.WriteLine("HelloWorld function hit");
        var greetingName = _configuration["GREETING_NAME"] ?? "World";

        Console.WriteLine("greeting name from config: " + greetingName);

        var message = "Hello, " + greetingName + "!";

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        response.WriteString(message);

        Console.WriteLine("done, sent response");

        return response;
    }
}
