using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaConsumerSocialization.Models;

namespace InstaConsumerSocialization
{
    public static class AuthorRepository
    {
        public static List<Author> allAuthorsCache { get; private set; }

        public static async Task<List<Author>> GetAllAuthorsAsync()
        {
            if (allAuthorsCache != null)
                return allAuthorsCache;
            var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync("http://icswebservice20161010034859.azurewebsites.net/api/authors");
            var serializer = new DataContractJsonSerializer(typeof(List<Author>));
            allAuthorsCache = (List<Author>)serializer.ReadObject(stream);
            return allAuthorsCache;
        }
    }
}
