using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using DTOModel.Providers.Interfaces;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XLabs.Ioc;

namespace XamarinAzureAD.ViewModel
{
    public class NewsPageViewModel : XLabs.Forms.Mvvm.ViewModel
    {

        public bool isLoading;

        private ObservableCollection<ObservableNews> _observableNews;

        public ObservableCollection<ObservableNews> ObservableNews
        {

            get { return _observableNews ?? (_observableNews = new ObservableCollection<ObservableNews>()); }
            set { SetProperty(ref _observableNews, value); }
        }

        private async Task<ObservableCollection<ObservableNews>> GetNews()
        {
            isLoading = true;
            var list = new ObservableCollection<ObservableNews>();
            Debug.WriteLine("COLLECTING NEWS");
            var observableNewsList = new ObservableCollection<ObservableNews>();
            var newsProvider = Resolver.Resolve<INewsProvider>();
            var userProvider = Resolver.Resolve<IUserProvider>()
        }
   
            isLoading = false;
            return list;
        }


        private ICommand _itemTappedCommand;

        public ICommand ItemTappedCommand
        {

            get
            {
                return _itemTappedCommand ?? (_itemTappedCommand = new Command(() =>
                {
                    ObservableNews.Add(new ObservableNews()
                    {
                        AuthorName = "HELLO"
                    }); 
                }
                    ));
            }
            set { SetProperty(ref _itemTappedCommand, value); }
        }


		

		



		

		



		

		



		

		


    }

}
