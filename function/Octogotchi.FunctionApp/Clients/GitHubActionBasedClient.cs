using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Octogotchi.FunctionApp.Entities;
using Octogotchi.FunctionApp.Models;
using Octogotchi.FunctionApp.Orchestrators;

namespace Octogotchi.FunctionApp
{
    public class GitHubActionBasedClient
    {
        private IValidator<GitHubActionInput> _validator;
        
        public GitHubActionBasedClient(IValidator<GitHubActionInput> validator)
        {
            _validator = validator;
        }

        [FunctionName(nameof(GitHubActionBasedClient))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethod.Post), Route = null)]HttpRequestMessage message,
            [DurableClient]IDurableClient client,
            ILogger log)
        {
            var input = await message.Content.ReadAsAsync<GitHubActionInput>();
            _validator.ValidateAndThrow(input);

            var entityId = new EntityId(nameof(OctogotchiEntity), input.Repository);
            var entityStateResult = await client.ReadEntityStateAsync<OctogotchiEntity>(entityId);
            if (entityStateResult.EntityExists)
            {
                if (!entityStateResult.EntityState.LastCommitHash.Equals(input.CommitHash, StringComparison.OrdinalIgnoreCase))
                {
                    // Octogotchi exists for this repo and this is a new commit, check it's status.
                    await client.StartNewAsync(nameof(CheckIssuesOrchestrator), input);
                }
            }
            else
            {
                // Octogotchi doesn't exist for this repo, create one.
                await client.StartNewAsync(nameof(CreateNewOctogotchiOrchestrator), input);
            }

            return new AcceptedResult();
        }
    }
}
