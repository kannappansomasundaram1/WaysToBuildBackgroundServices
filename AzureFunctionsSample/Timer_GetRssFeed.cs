using System;
using System.Xml;
using App.WindowsService;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Griffin
{
    public class Timer_GetRssFeed
    {
        
        [Function("Timer_GetRssFeed")]
        [BlobOutput("output/joke.txt")]
        public async Task<string> Run([TimerTrigger("*/10 * * * * *")] TimerInfo myTimer)
        {
            return JokeProvider.GetJoke();
        }
    }
}
