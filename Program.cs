using DotNetProject;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureAppConfiguration((_, configuration) => configuration
        .AddJsonFile("local.settings.json", optional: true)
        .AddEnvironmentVariables())
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => services.AddSingleton<InvocationState>())
    .Build();

host.Run();
