using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureAppConfiguration((_, configuration) => configuration
        .AddJsonFile("local.settings.json", optional: true)
        .AddEnvironmentVariables())
    .ConfigureFunctionsWorkerDefaults()
    .Build();

Console.WriteLine("host starting up...");

host.Run();
