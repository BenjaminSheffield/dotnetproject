using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;

public static class HelloWorldFunction
{
    [Function("HelloWorld")]
    public static HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        Console.WriteLine("HelloWorld function hit");

        // just build the config right here, who needs IOptions
        var config = new ConfigurationBuilder()
            .AddJsonFile("local.settings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var greetingName = config["GREETING_NAME"] ?? "World";

        Console.WriteLine("greeting name from config: " + greetingName);

        var message = "Hello, " + greetingName + "!";

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        response.WriteString(message);

        Console.WriteLine("done, sent response");

        return response;
    }
}
