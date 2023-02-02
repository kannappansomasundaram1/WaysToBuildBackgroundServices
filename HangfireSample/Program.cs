using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage("Server=(localdb)\\MSSQLLocalDB;Database=HangfireDemo;Trusted_Connection=True;");

    const string cronEvery15Seconds = "*/5 * * * * *";
    RecurringJob.AddOrUpdate<JokesBackgroundJob>(job => job.Execute(), cronEvery15Seconds);
});

builder.Services.AddHangfireServer();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseHangfireDashboard();
app.MapHangfireDashboard();
app.Run();