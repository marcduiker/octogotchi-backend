namespace Octogotchi.FunctionApp.Models
{
    public class GitHubActionInput
    {
        public string Repository { get; set; }
        public string CommitHash { get; set; }
    }
}