using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Newtonsoft.Json;

namespace Octogotchi.FunctionApp.Entities
{
    /// The Entity key is the repository name.
    [JsonObject(MemberSerialization.OptIn)]
    public class OctogotchiEntity
    {
        public DateTime DateOfBirth { get; set; }

        public string LastCommitHash { get; set; }

        public int State { get; set; }

        public void SetCommitHash(string commitHash) => LastCommitHash = commitHash;

        public void SetDateOfBirth() => DateOfBirth = DateTime.UtcNow;

        [FunctionName(nameof(OctogotchiEntity))]
        public static Task Run(
            [EntityTrigger] IDurableEntityContext context)
            => context.DispatchAsync<OctogotchiEntity>();
    }
}