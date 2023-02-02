using App.WindowsService;
using Quartz;

public class JokesBackgroundJob : IJob
{
    private readonly ILogger<JokesBackgroundJob> _logger;

    public JokesBackgroundJob(ILogger<JokesBackgroundJob> logger)
    {
        _logger = logger;
    }
    
    public Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation($"{JokeProvider.GetJoke()}");
        return Task.CompletedTask;
    }
}