using XamarinAzureAD.Model;

namespace XamarinAzureAD.ViewModel
{
    internal class SelectedItemViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private ObservableNews _selectedNews;

        public ObservableNews SelectedNews
        {
            get { return _selectedNews ?? (_selectedNews = new ObservableNews()); }
            set { SetProperty(ref _selectedNews, value); }
        }
    }
}