using InstaConsumerSocialization.UWP.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Newtonsoft.Json;

namespace InstaConsumerSocialization.UWP
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

        public static List<Post> GetAllPosts()
        {
            if (allPostsCache != null)
                return allPostsCache;
            //var httpClient = new HttpClient();
            //var stream = await httpClient.GetStreamAsync("http://instaconsumersocializationwebapi.azurewebsites.net/api/posts");
            //var serializer = new DataContractJsonSerializer(typeof(List<Post>));
            //allPostsCache = (List<Post>)serializer.ReadObject(stream);
            allPostsCache = new List<Post>
            {
                new Post { Id = "ad-3", CreationDay = 10, CreationMonth = 7, CreationYear = 2016, Author = "nike", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/nike.jpg"), Caption = "Stand as one. Play as one. Win as one. #justdoit", LikesNumber = 829504, CommentsNumber = 3992, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/ad-3.png")},
                new Post { Id = "ad-5", CreationDay = 26, CreationMonth = 9, CreationYear = 2016, Author = "rockymountainoils", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/rockymountainoils.jpg"), Caption = "Do your feet ache at the end of the day? This cooling foot scrub has you covered! Mix one cup granulated sugar, 1/2 cup Fractionated Coconut Oil, 7 drops Peppermint and 5 drops Orange. Apply during your shower or bath and emerge with energized, happy feet!", LikesNumber = 182, CommentsNumber = 2, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/ad-5.png")},
                new Post { Id = "ad-12", CreationDay = 1, CreationMonth = 10, CreationYear = 2016, Author = "steaknshake", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/steaknshake.jpg"), Caption = "Have you conquered our #7x7 Steakburger? Picture or it didn't happen!", LikesNumber = 947, CommentsNumber = 13, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/ad-12.png")},
                new Post { Id = "ad-14", CreationDay = 15, CreationMonth = 2, CreationYear = 2016, Author = "conradsgrill", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/conradsgrill.jpg"), Caption = "Did you hear? Conrad's Abbot is serving $5 Wraps and $4 Mac Bites until Midnight! #CustomerAppreciationDay *Excludes Giant Wraps*", LikesNumber = 17, CommentsNumber = 0, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/ad-14.png")},
                new Post { Id = "ad-15", CreationDay = 19, CreationMonth = 9, CreationYear = 2016, Author = "nutella", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/nutella.jpg"), Caption = "Ahoy, matey! Celebrate #TalkLikeAPirateDay like any smart scallywag would...with Nutella®.", LikesNumber = 34527, CommentsNumber = 243, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/ad-15.png")},
                new Post { Id = "ad-16", CreationDay = 23, CreationMonth = 9, CreationYear = 2016, Author = "cocacola", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/cocacola.jpg"), Caption = "Plate your crispy white cheddar grilled cheese and open a chilled Coca-Cola to create the perfect pairing.", LikesNumber = 25556, CommentsNumber = 148, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/ad-16.png")},
                new Post { Id = "pp-5", CreationDay = 2, CreationMonth = 10, CreationYear = 2016, Author = "champstudio", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/champstudio.jpg"), Caption = "I am a vampire and I lured Becky here to kill her. #popcorn #soda #bloodiswhatsfordinner", LikesNumber = 11, CommentsNumber = 0, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/pp-5.png")},
                new Post { Id = "pp-6", CreationDay = 2, CreationMonth = 10, CreationYear = 2016, Author = "fashioncoveted", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/fashioncoveted.jpg"), Caption = "Yes or No?? 💙 Comment & Tag Your Friends !! Shop Now From Link In My Bio.", LikesNumber = 29170, CommentsNumber = 93, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/pp-6.png")},
                new Post { Id = "pp-7", CreationDay = 2, CreationMonth = 10, CreationYear = 2016, Author = "jesswhoamamma", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/jesswhoamamma.jpg"), Caption = "Naughty hamburgers for lunch in the park with my baby brother today. We even swung on the swings! Weeeeeee! #nevergrowup#andrewshamburgers #andrewsburgers#albertpark #lunch #hamburgers#foodie #naughty #bigkids#lunchinthepark #melbourneeats#instalunch #instaburger #instafoodie#yum #streetfood #burgers#melbournefoodie", LikesNumber = 83, CommentsNumber = 10, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/pp-7.png")},
                new Post { Id = "pp-16", CreationDay = 2, CreationMonth = 10, CreationYear = 2016, Author = "stanislava_titi", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/stanislava_titi.jpg"), Caption = "🔝place-Jamba Juice 🔝juice-Berried Peanut Butter 💜💜💜 #bestjuice #bestbreakfast #lunch #dinner #healthyfood #jambajuice #kitebeach #berries #peanutbutter #jambajuicedubai #dubaifood #beachday #dubailife #instafood #instadaily #instalifestyle #instahub #bulgariangirl #dubai", LikesNumber = 66, CommentsNumber = 1, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/pp-16.png")},
                new Post { Id = "pp-17", CreationDay = 2, CreationMonth = 10, CreationYear = 2016, Author = "surfandskatewarehouse", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/surfandskatewarehouse.jpg"), Caption = "Thule back packs available and ready to ship. #Thule #backpacks #travel #mountains #skiing #snow #snowboarding", LikesNumber = 66, CommentsNumber = 3, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/pp-17.png")},
                new Post { Id = "pp-20", CreationDay = 2, CreationMonth = 10, CreationYear = 2016, Author = "emmacristy", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/profiles/surfandskatewarehouse.jpg"), Caption = "Fall is here you guys. And this post is for all the Autumn dreaming, pumpkin obsessed lovers out there! I've been snacking on these Graze Pumpkin Spice Flapjacks and it's basically Autumn in a snack pack 😆 You can use the code 'pumpkin48' for a 30% discount on any order $100 or more under the Graze shop site! Check out @grazeusa Instagram to find out how you can get a free box of Graze! #sponsored #pumpkinspice", LikesNumber = 3216, CommentsNumber = 169, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/images/pp-20.png")}
            };
            ShufflePosts();
            //postSequenceToServer();
            return allPostsCache;
        }
    }

}