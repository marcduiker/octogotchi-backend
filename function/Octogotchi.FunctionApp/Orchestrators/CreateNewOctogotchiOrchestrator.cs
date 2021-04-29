using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Octogotchi.FunctionApp.Models;

namespace Octogotchi.FunctionApp.Orchestrators
{
    public class CreateNewOctogotchiOrchestrator
    {
        [FunctionName(nameof(CreateNewOctogotchiOrchestrator))]
        public async Task Run(
            [OrchestrationTrigger] IDurableOrchestrationContext context,
            ILogger logger)
        {
            var input = context.GetInput<GitHubActionInput>();

            // Check if the commit matches with the repo
            
                // If YES
                // Create new Entity and set DateOfBirth and initial status.
                // Create new Issue with the first task
                // Update README with new Octogotchi link

                // If NO
                // Log warning
        }
    }
}