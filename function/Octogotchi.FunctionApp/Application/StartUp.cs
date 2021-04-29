using FluentValidation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Octogotchi.FunctionApp;
using Octogotchi.FunctionApp.Models;
using Octogotchi.FunctionApp.Validators;

[assembly: FunctionsStartup(typeof(StartUp))]
namespace Octogotchi.FunctionApp
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IValidator<GitHubActionInput>, GitHubActionInputValidator>();
        }
    }
}