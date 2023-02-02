using App.WindowsService;

namespace WindowsHostedService;

public sealed class JokesBackgroundService : BackgroundService
{
    private readonly ILogger<JokesBackgroundService> _logger;
    private readonly TimeSpan _delayTimeSpan = TimeSpan.FromSeconds(5);

    public JokesBackgroundService(
        ILogger<JokesBackgroundService> logger) =>
        _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var joke = JokeProvider.GetJoke();
                _logger.LogWarning(joke);

                await Task.Delay(_delayTimeSpan, stoppingToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Message}", ex.Message);
            Environment.Exit(1);
        }
    }
}