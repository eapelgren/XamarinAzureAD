using System.Collections.Generic;
using System.Collections.ObjectModel;
using DTOModel.Model;
using DTOModel.Providers.Interfaces;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XLabs.Ioc;

namespace XamarinAzureAD.ViewModel
{
    internal class SelectedNewsViewModel : XLabs.Forms.Mvvm.ViewModel
    {

        public SelectedNewsViewModel(ObservableNews news, ObservableCollection<ObservableComment> commentList )
        {
            ScrollViewIsVisisble = true;
            SingleNewsCollection.Add(news);
            Comments = commentList;
        }

        private ObservableCollection<ObservableNews> _singleNewsCollection;

        public ObservableCollection<ObservableNews> SingleNewsCollection
        {
            get { return _singleNewsCollection ?? (_singleNewsCollection = new ObservableCollection<ObservableNews>()); }
            set { SetProperty(ref _singleNewsCollection, value); }
        }

        private ObservableCollection<ObservableComment> _comments;

        public ObservableCollection<ObservableComment> Comments
        {

            get
            {
                return _comments ?? (_comments = new ObservableCollection<ObservableComment>()
                {
                    
                });
            }
            set { SetProperty(ref _comments, value); }
        }


        private Entry _commentEntry;

        public Entry CommentEntry
        {

            get
            {
                return _commentEntry ?? (_commentEntry = new Entry()
                {
                      
                });
            }
            set { SetProperty(ref _commentEntry, value); }
        }

        public bool ScrollViewIsVisisble { get; set; }


        //public void SendComment()
        //{
        //    var commentProvider = Resolver.Resolve<ICommentProvider>();
        //    if (!string.IsNullOrEmpty(CommentEntry.Text))
        //    {
        //      var loggedInUser = Resolver.Resolve<ICurrentUser>();
        //        commentProvider.SendComment(loggedInUser, CommentEntry.Text);
        //    }
        //}
    }


}