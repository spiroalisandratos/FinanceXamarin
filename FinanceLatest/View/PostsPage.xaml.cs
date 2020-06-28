using System;
using System.Collections.Generic;
using FinanceLatest.Models;
using Xamarin.Forms;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using System.Threading.Tasks;
using FinanceLatest.ViewModel;

namespace FinanceLatest.View
{
    public partial class PostsPage : ContentPage
    {
        PostsVM postsVM;
        
        public PostsPage()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
            postsVM = Resources["vm"] as PostsVM;
        }

        public PostsPage(Item item)
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
            postsVM = Resources["vm"] as PostsVM;
            postsVM.SelectedPost = item;
            //try
            //{
            // throw new Exception("Unable to load blog");

            //}
            //catch (Exception ex)
            //{
            //    var errors = new Dictionary<string, string>()
            //    {
            //        {"BlogLink", item.ItemLink }
            //    };
            //    TrackErrors(ex, errors);
            //}



            webView.Source = item.ItemLink;
            var report = new Dictionary<string, string>()
            {
                {"BlogLink", item.ItemLink },
                { "BlogTitle", item.Title}
            };
            TrackBlogVisits(report);
            
        }

        private async void TrackBlogVisits(Dictionary<string,string> dic)
        {
            if (await Analytics.IsEnabledAsync())
            {
                Analytics.TrackEvent("Blog_post_navigation", dic);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Analytics hasn't been enabled");
            }
            
        }

        private async void TrackErrors(Exception ex, Dictionary<string, string> dic)
        {
            if (await Crashes.IsEnabledAsync())
            {
                Analytics.TrackEvent("Blog_post_navigation", dic);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Analytics hasn't been enabled");
            }

        }
    }
}
