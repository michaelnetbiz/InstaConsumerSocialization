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
        public static List<Post> allPostsCache { get; private set; }

        public static async Task<List<Post>> GetAllStimuliAsync()
        {
            if (allPostsCache != null)
                return allPostsCache;
            var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync("http://icswebservice20161010034859.azurewebsites.net/api/posts");
            var serializer = new DataContractJsonSerializer(typeof(List<Post>));
            allPostsCache = (List<Post>)serializer.ReadObject(stream);
            return allPostsCache;
        }
    }

}