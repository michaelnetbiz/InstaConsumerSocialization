using InstaConsumerSocialization.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConsumerSocialization
{
    public class MainPageData : INotifyPropertyChanged
    {
        private List<Post> _allPosts = new List<Post>();

        public ObservableCollection<Post> Posts { get; set; }
        public MainPageData()
        {
            Posts = new ObservableCollection<Post>();
            LoadData();
        }

        private async void LoadData()
        {
            _allPosts = await PostRepository.GetAllPostsAsync();
            PerformFiltering();
        }

        private void PerformFiltering()
        {
            if (_filter == null)
                _filter = "";

            var lowerCaseFilter = Filter.ToLowerInvariant().Trim();

            var result =
                _allPosts.Where(d => d.NamesAsString.ToLowerInvariant()
                .Contains(lowerCaseFilter))
                .ToList();

            var toRemove = Posts.Except(result).ToList();

            foreach (var x in toRemove)
                Posts.Remove(x);

            var resultCount = result.Count;
            for (int i = 0; i < resultCount; i++)
            {
                var resultItem = result[i];
                if (i + 1 > Posts.Count || !Posts[i].Equals(resultItem))
                    Posts.Insert(i, resultItem);
            }
        }
        private string _greeting = "Hello world";
        public string Greeting
        {
            get { return _greeting; }
            set
            {
                if (value == _greeting)
                    return;
                _greeting = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Greeting)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private Post _selectedPost;
        public Post SelectedPost
        {
            get { return _selectedPost; }
            set
            {
                _selectedPost = value;
                if (value == null)
                    Greeting = "fuck off the value is null";
                else
                    Greeting = "Hello " + value.NamesAsString;

            }
        }
        private string _filter;
        public string Filter
        {
            get { return _filter; }
            set
            {
                if (value == _filter)
                    return;
                _filter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filter)));

                PerformFiltering();
            }
        }

    }
}
