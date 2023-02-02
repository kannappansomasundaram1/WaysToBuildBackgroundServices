namespace App.WindowsService;

public sealed class JokesBackgroundService : BackgroundService
{
    private readonly ILogger<JokesBackgroundService> _logger;

    public JokesBackgroundService(
        ILogger<JokesBackgroundService> logger) =>
        (_logger) = (logger);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
            while (!stoppingToken.IsCancellationRequested)
            {
                var joke = JokeProvider.GetJoke();
                _logger.LogInformation(joke);

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
    }
}