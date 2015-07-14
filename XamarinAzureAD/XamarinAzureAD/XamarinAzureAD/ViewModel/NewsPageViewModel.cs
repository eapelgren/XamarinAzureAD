using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using DTOModel.Providers.Interfaces;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XLabs.Ioc;

namespace XamarinAzureAD.ViewModel
{
    public class NewsPageViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        public bool IsLoading;
        private Command _itemTappedCommand;

        private ObservableCollection<ObservableNews> _observableNews;

        public ObservableCollection<ObservableNews> ObservableNews
        {
            get { return _observableNews ?? (_observableNews = new ObservableCollection<ObservableNews>()); }
            set { SetProperty(ref _observableNews, value); }
        }

        public Command ItemTappedCommand
        {
            get
            {
                return _itemTappedCommand ??
                       (_itemTappedCommand = new Command(() => ObservableNews.Add(new ObservableNews
                       {
                           Header = "Test Header"
                       })));
            }

            set { SetProperty(ref _itemTappedCommand, value); }
        }

        private async Task<ObservableCollection<ObservableNews>> GetNews()
        {
            IsLoading = true;
            var list = new ObservableCollection<ObservableNews>();
            Debug.WriteLine("COLLECTING NEWS");
            var observableNewsList = new ObservableCollection<ObservableNews>();
            var newsProvider = Resolver.Resolve<INewsProvider>();
            var userProvider = Resolver.Resolve<IUserProvider>();

            IsLoading = false;
            return list;
        }
    }
}