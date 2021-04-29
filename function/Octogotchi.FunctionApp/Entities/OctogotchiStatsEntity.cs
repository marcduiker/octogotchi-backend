using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Newtonsoft.Json;

namespace Octogotchi.FunctionApp.Entities
{
    
    [JsonObject(MemberSerialization.OptIn)]
    public class OctogotchiStatsEntity
    {
        public int Count { get; set; }

        public void Increment() => Count += 1;

        public void Decrement() => Count -= 1;

        [FunctionName(nameof(OctogotchiStatsEntity))]
        public static System.Threading.Tasks.Task Run(
            [EntityTrigger] IDurableEntityContext context)
            => context.DispatchAsync<OctogotchiStatsEntity>();
    }
}