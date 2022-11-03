using news_worker_service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<LatestNews>();
        services.AddSingleton<Repository>();
    })
    .Build();

await host.RunAsync();
