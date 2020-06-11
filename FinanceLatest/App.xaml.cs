using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

namespace FinanceLatest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            string androidAppSecret = "7ac547bb-8948-4f88-ae8b-e453ec6f073f";
            string iosAppSecret = "d90ba8dd-450a-4417-b9ce-ee050239dc48";

            AppCenter.Start($"android={androidAppSecret};ios={iosAppSecret}", typeof(Crashes), typeof(Analytics));

            bool hasCrashed = await Crashes.HasCrashedInLastSessionAsync();

            if (hasCrashed)
            {
                var crashReport = await Crashes.GetLastSessionCrashReportAsync();
            }

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
