using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace Octogotchi.FunctionApp.Orchestrators
{
    public class CheckIssuesOrchestrator
    {
        [FunctionName(nameof(CheckIssuesOrchestrator))]
        public async Task Run(
            [OrchestrationTrigger] IDurableOrchestrationContext context,
            ILogger logger)
        {
            // Check if the commit matches with the repo
            
                // If YES
                // Check the state of the last commit and validate if the task has been accomplished.

                    // If YES
                    // Close the linked GitHub Issue (it could be already closed manually)
                    // Set the new state to the entity.
                    // Create a new GitHub Issue
                
                    // If NO
                    // Determine if state needs changing based on time

                        // If YES
                        // Set the new state to the entity.

                    // Update the README based on the new state

                // If NO
                // Don't do anything
        }
    }
}