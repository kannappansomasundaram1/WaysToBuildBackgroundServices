using App.WindowsService;
using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionsExample
{
    public class Timer_JokesFeed
    {
        
        [Function("Timer_JokesFeed")]
        [BlobOutput("output/joke.txt")]
        public async Task<string> Run([TimerTrigger("*/10 * * * * *")] TimerInfo myTimer)
        {
            return JokeProvider.GetJoke();
        }
    }
}
