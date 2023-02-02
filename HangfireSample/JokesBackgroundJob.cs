using App.WindowsService;

public class JokesBackgroundJob
{
    private readonly ILogger<JokesBackgroundJob> _logger;

    public JokesBackgroundJob(ILogger<JokesBackgroundJob> logger)
    {
        _logger = logger;
    }

    public void Execute()
    {
        _logger.LogInformation($"{JokeProvider.GetJoke()}");
    }
}