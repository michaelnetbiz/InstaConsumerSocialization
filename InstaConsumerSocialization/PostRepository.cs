using InstaConsumerSocialization.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace InstaConsumerSocialization
{
    public static class PostRepository
    {
        private static List<Post> allStimuliCache;
        public static async Task<List<Post>> GetAllStimuliAsync()
        {
            if (allStimuliCache != null)
                return allStimuliCache;

            var client = new HttpClient();
            var stream = await client.GetStreamAsync("http://beta.json-generator.com/api/json/get/N14ZKoR9b");
            var serializer = new DataContractJsonSerializer(typeof(List<Post>));
            return allStimuliCache;
        }
    }

}