using InstaConsumerSocialization.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Newtonsoft.Json;

namespace InstaConsumerSocialization
{
    public static class PostRepository
    {
        public static List<Post> AllPostsCache { get; private set; }

        public static async Task<List<Post>> GetAllStimuliAsync()
        {
            if (AllPostsCache != null)
                return AllPostsCache;
            HttpClient http = new System.Net.Http.HttpClient();
            http.DefaultRequestHeaders.Add("accept", "Application/JSON");
            string result = await http.GetStringAsync("http://beta.json-generator.com/api/json/get/N14ZKoR9b");
            //var stream = await client.GetStreamAsync("http://beta.json-generator.com/api/json/get/N14ZKoR9b");
            //var firstDegreeTypes = new[]
            //{
            //    typeof(List<Post>),
            //    typeof(Post)
            //};
            var secondDegreeTypes = new[]
            {
                typeof(DateTime),
                typeof(Caption),
                typeof(Comment),
                typeof(Identifier),
                typeof(Image),
                typeof(Incrementer),
                typeof(Like),
                typeof(Location),
                typeof(Tag),
                typeof(User),
                typeof(UserInfo)
            };
            //List<Post> posts = new JavaScriptSerializer().Deserialize<Posts>(stream);
            AllPostsCache = JsonConvert.DeserializeObject<List<Post>>(result);
            //var serializer = new DataContractJsonSerializer(typeof(List<Post>), secondDegreeTypes);
            //AllPostsCache = (List<Post>)serializer.ReadObject(stream);
            return AllPostsCache;
        }
    }

}