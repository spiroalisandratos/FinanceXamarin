using System;
using System.Collections.Generic;
using FinanceLatest.Models;
using Xamarin.Forms;

namespace FinanceLatest.View
{
    public partial class PostsPage : ContentPage
    {
        public PostsPage()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
        }

        public PostsPage(Item item)
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);

            webView.Source = item.ItemLink;
        }
    }
}
