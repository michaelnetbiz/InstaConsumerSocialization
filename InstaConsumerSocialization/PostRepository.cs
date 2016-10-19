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
        private static Random rng = new Random();
        public static void ShufflePosts()
        {
            int n = allPostsCache.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = allPostsCache[k];
                allPostsCache[k] = allPostsCache[n];
                allPostsCache[n] = value;
            }
        }

        //public static async void postSequenceToServer()
        //{
        //    var httpClient = new HttpClient();
        //    var lol = allPostsCache;
        //    var postingStream = await httpClient.PostAsync("http://icswebservice20161010034859.azurewebsites.net/api/posts", lol);
        //    var postingSerializer = new DataContractJsonSerializer(typeof(List<Post>));
        //}

        public static List<Post> allPostsCache { get; private set; }

        public static async Task<List<Post>> GetAllPostsAsync()
        {
            if (allPostsCache != null)
                return allPostsCache;
            var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync("http://icswebservice20161010034859.azurewebsites.net/api/posts");
            var serializer = new DataContractJsonSerializer(typeof(List<Post>));
            allPostsCache = (List<Post>)serializer.ReadObject(stream);
            ShufflePosts();
            //postSequenceToServer();
            return allPostsCache;
        }
    }

}