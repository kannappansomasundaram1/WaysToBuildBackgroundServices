using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(s =>
     {
         s.AddLogging();
     })
    .ConfigureLogging((context, builder) =>
    {
        builder.AddConsole();
    })
    .Build();

host.Run();
