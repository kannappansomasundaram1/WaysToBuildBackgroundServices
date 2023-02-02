using App.WindowsService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<JokesBackgroundService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.Run();