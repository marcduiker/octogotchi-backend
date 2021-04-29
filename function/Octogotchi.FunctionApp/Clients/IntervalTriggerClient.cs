using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Octogotchi.FunctionApp.Models;
using Octogotchi.FunctionApp.Orchestrators;

namespace Octogotchi.FunctionApp
{
    public static class IntervalTriggerClient
    {
        [FunctionName(nameof(IntervalTriggerClient))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethod.Post), Route = null)]HttpRequestMessage message,
            [DurableClient]IDurableClient client,
            ILogger log)
        {
            var input = message.Content.ReadAsAsync<GitHubActionInput>();
            await client.StartNewAsync(nameof(CheckIssuesOrchestrator), input);

            return new AcceptedResult();
        }
    }
}
