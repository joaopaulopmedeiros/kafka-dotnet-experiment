using IHost host = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices(services => services.AddConsumerServices())
    .Build();

await host.RunAsync();