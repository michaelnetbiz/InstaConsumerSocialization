using InstaConsumerSocialization.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace InstaConsumerSocialization
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void EventHandler(Post sender, GridViewItem itemInvoked)
        {
            if (sender.IsLiked == false)
            {
                sender.IsLiked = true;
            }
            else
            {
                sender.IsLiked = false;
            }
        }

        private void EventHandler(Post sender, TappedRoutedEventArgs e)
        {
            if (sender.IsLiked == false)
            {
                sender.IsLiked = true;
            }
            else
            {
                sender.IsLiked = false;
            }
        }
    }
}
