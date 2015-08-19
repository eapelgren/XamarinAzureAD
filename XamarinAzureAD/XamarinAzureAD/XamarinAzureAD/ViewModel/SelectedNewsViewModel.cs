using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Channels;
using DTOModel.Providers.Interfaces;
using Xamarin.Forms;
using XamarinAzureAD.Mapper;
using XamarinAzureAD.Model;
using XLabs.Ioc;

namespace XamarinAzureAD.ViewModel
{
    internal class SelectedNewsViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private Entry _commentEntry;
        private ObservableCollection<ObservableComment> _comments;
        private ObservableNews _selectedNews;

        public SelectedNewsViewModel(ObservableNews news)
        {
            ScrollViewIsVisisble = true;
            SelectedNews = news;

            var commentsProvider = Resolver.Resolve<ICommentProvider>();
            commentsProvider.GetCommentsTask(news.Id).ContinueWith(task =>
            {
                var commentListDTO = task.Result.ToList();
                foreach (var commentDto in commentListDTO)
                {
                    Comments.Add(CommentMapper.Convert(commentDto));
                }
            });

        }

        public ObservableNews SelectedNews
        {
            get { return _selectedNews ?? (_selectedNews = new ObservableNews()); }
            set { SetProperty(ref _selectedNews, value); }
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