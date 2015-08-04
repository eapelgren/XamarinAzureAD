using XamarinAzureAD.Model;

namespace XamarinAzureAD.ViewModel
{
    internal class SelectedNewsViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private ObservableNews _news;

        public SelectedNewsViewModel(ObservableNews news)
        {
            News = news;
        }

        public ObservableNews News
        {
            get { return _news ?? (_news = new ObservableNews()); }
            set { SetProperty(ref _news, value); }
        }
    }
}