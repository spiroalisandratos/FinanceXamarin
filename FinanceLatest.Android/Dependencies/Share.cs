using System;
using System.Threading.Tasks;
using Android.Content;
using FinanceLatest.Droid.Dependencies;
using FinanceLatest.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace FinanceLatest.Droid.Dependencies
{
    public class Share : IShare
    {
        public Task Show(string title, string url)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");

            intent.PutExtra(Intent.ExtraText, url);
            intent.PutExtra(Intent.ExtraSubject, title);
          
            var chooserIntent = Intent.CreateChooser(intent, title);
            chooserIntent.SetFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(chooserIntent);
            return Task.FromResult(true);
        }
    }
}
