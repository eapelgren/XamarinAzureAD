using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.ViewModel
{
    internal class SelectedNewsViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private Entry _commentEntry;
        private ObservableCollection<ObservableComment> _comments;
        private ObservableCollection<ObservableNews> _singleNewsCollection;

        public SelectedNewsViewModel(ObservableNews news, ObservableCollection<ObservableComment> commentList)
        {
            ScrollViewIsVisisble = true;
            SingleNewsCollection.Add(news);
            Comments = commentList;
        }

        public ObservableCollection<ObservableNews> SingleNewsCollection
        {
            get
            {
                return _singleNewsCollection ?? (_singleNewsCollection = new ObservableCollection<ObservableNews>());
            }
            set { SetProperty(ref _singleNewsCollection, value); }
        }

        public ObservableCollection<ObservableComment> Comments
        {
            get { return _comments ?? (_comments = new ObservableCollection<ObservableComment>()); }
            set { SetProperty(ref _comments, value); }
        }

        public Entry CommentEntry
        {
            get { return _commentEntry ?? (_commentEntry = new Entry()); }
            set { SetProperty(ref _commentEntry, value); }
        }

        public bool ScrollViewIsVisisble { get; set; }
    }
}