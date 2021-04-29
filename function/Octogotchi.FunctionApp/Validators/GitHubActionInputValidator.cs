using FluentValidation;
using Octogotchi.FunctionApp.Models;

namespace Octogotchi.FunctionApp.Validators
{
    public class GitHubActionInputValidator : AbstractValidator<GitHubActionInput>
    {
        public GitHubActionInputValidator()
        {
            RuleFor(gitHubActionInput => gitHubActionInput.CommitHash).NotEmpty();
            RuleFor(gitHubActionInput => gitHubActionInput.Repository).NotEmpty();
        }
    }
}