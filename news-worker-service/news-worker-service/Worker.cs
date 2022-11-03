namespace news_worker_service;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly LatestNews _latestNews;
    public Worker(ILogger<Worker> logger, LatestNews latestNews)
    {
        _logger = logger;
        _latestNews = latestNews;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {


            _latestNews.SetLatestNewsInDb();
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(3600000, stoppingToken);


        }
    }
}
