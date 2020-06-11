using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FinanceLatest.Interfaces;
using FinanceLatest.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FinanceLatest.ViewModel
{
    public class PostsVM : INotifyPropertyChanged
    {
        private Item selectedPost;
        public Item SelectedPost
        {
            get { return selectedPost; }
            set
            {
                selectedPost = value;
                OnPropertyChanged("SelectedPost");
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Command ShareCommand { get; set; }

        public PostsVM()
        {
            SelectedPost = new Item();
            ShareCommand = new Command(Share);
        }

        public void Share()
        {
            IShare share = DependencyService.Get<IShare>();
            share.Show("Post From Nasa", selectedPost.ItemLink);
        }
    }
}
