using Quartz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(configure => configure.AddConsole());

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();

    // base QuartzSample scheduler, job and trigger configuration
    var jobKey = new JobKey("CleanUpTempFolderJob");
    q.AddJob<JokesBackgroundJob>(jobKey, job => job
        .StoreDurably()
        .DisallowConcurrentExecution()
        .WithDescription("Cleans up the temp folder"));

    var cronExpression = "0/5 * * ? * *";
    q.AddTrigger(trigger => trigger
        .ForJob(jobKey)
        .WithCronSchedule(cronExpression));
});

builder.Services.AddQuartzServer(options =>
{
    options.WaitForJobsToComplete = true;
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();