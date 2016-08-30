using InstaConsumerSocialization.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace InstaConsumerSocialization
{
    public static class StimulusRepository
    {
        private static List<Stimulus> allStimuliCache;
        public static async Task<List<Stimulus>> GetAllStimuliAsync()
        {
            if (allStimuliCache != null)
                return allStimuliCache;

            var client = new HttpClient();
            var stream = await client.GetStreamAsync("https://msu.edu/~nelso663/assets/posts.json");
            var serializer = new DataContractJsonSerializer(typeof(List<Stimulus>));
            return allStimuliCache;
        }
    }

}