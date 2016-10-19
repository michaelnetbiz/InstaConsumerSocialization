using InstaConsumerSocialization.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InstaConsumerSocialization.WebAPI.Controllers
{
    public class PostsController : ApiController
    {
        Post[] posts = new Post[]
        {
            new Post { Id = "ad-1", CreationDay = 30, CreationMonth = 8, CreationYear = 2016, Author = "macys", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/img/macys.jpg"), Caption = "The classic Mary Jane is getting an upgrade this fall 😍😍😍 #shoesday", LikesNumber = 2469, CommentsNumber = 17, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/img/ad-1.png")},
            new Post { Id = "ad-3", CreationDay = 10, CreationMonth = 7, CreationYear = 2016, Author = "nike", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/img/nike.jpg"), Caption = "Stand as one. Play as one. Win as one. #justdoit", LikesNumber = 829504, CommentsNumber = 3992, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/img/ad-3.png")},
            new Post { Id = "ad-4", CreationDay = 4, CreationMonth = 8, CreationYear = 2016, Author = "lays", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/img/lays.jpg"), Caption = "Introducing our 4 new Global Flavors, arriving stateside on July 25th! They're only available for a limited time, so be sure to try them all! #PassportToFlavor #Lays", LikesNumber = 2928, CommentsNumber = 96, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/img/ad-4.png")},
            new Post { Id = "ad-5", CreationDay = 26, CreationMonth = 9, CreationYear = 2016, Author = "rockymountainoils", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/img/rockymountainoils.jpg"), Caption = "Do your feet ache at the end of the day? This cooling foot scrub has you covered! Mix one cup granulated sugar, 1/2 cup Fractionated Coconut Oil, 7 drops Peppermint and 5 drops Orange. Apply during your shower or bath and emerge with energized, happy feet!", LikesNumber = 182, CommentsNumber = 2, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/img/ad-5.png")},
            new Post { Id = "ad-6", CreationDay = 3, CreationMonth = 10, CreationYear = 2016, Author = "sephora", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/img/sephora.jpg"), Caption = "The bigger your spotlight, the smaller you want your pores ⚪️ Swipe skin with the new Pore Vanishing Stick by @TheEsteeEdit and get ready for your close up. #LinkInBio", LikesNumber = 45400, CommentsNumber = 206, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/img/ad-6.png")},
            new Post { Id = "ad-7", CreationDay = 22, CreationMonth = 9, CreationYear = 2016, Author = "bestbuy", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/img/bestbuy.jpg"), Caption = "Rock on, old friend. #chromecast #vintagespeakers", LikesNumber = 444, CommentsNumber = 11, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/img/ad-7.png")},
            new Post { Id = "ad-8", CreationDay = 21, CreationMonth = 9, CreationYear = 2016, Author = "target", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/img/target.jpg"), Caption = "Hey there, stud muffin. We’ve whipped up one sweet treat for a deliciously smooth shave. Shop all beard-busters through the link in our bio.", LikesNumber = 13300, CommentsNumber = 170, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/img/ad-8.png")},
            new Post { Id = "ad-9", CreationDay = 14, CreationMonth = 9, CreationYear = 2016, Author = "adidas", AuthorImageUri = new Uri("http://icswebstore.azurewebsites.net/img/adidas.jpg"), Caption = "YEEZY 350 CLEAT by Kanye West. September 15, 2016.", LikesNumber = 122000, CommentsNumber = 4216, PostImageUri = new Uri("http://icswebstore.azurewebsites.net/img/ad-9.png")}
        };
        public IEnumerable<Post> GetAllPosts()
        {
            return posts;
        }
        public IHttpActionResult GetPost(string id)
        {
            var post = posts.FirstOrDefault((p) => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
    }
}
