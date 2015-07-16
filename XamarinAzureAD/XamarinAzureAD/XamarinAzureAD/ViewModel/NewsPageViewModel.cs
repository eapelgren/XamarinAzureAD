using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTOModel.Providers.Interfaces;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XLabs.Ioc;

namespace XamarinAzureAD.ViewModel
{
    public class NewsPageViewModel : XLabs.Forms.Mvvm.ViewModel
    {

        public NewsPageViewModel()
        {
            //UpdateObservableNews().Start();
        }
        public bool IsLoading;
        private Command _itemTappedCommand;

        private ObservableCollection<ObservableNews> _observableNews;

        public ObservableCollection<ObservableNews> ObservableNews
        {
            get { return _observableNews ?? (_observableNews = new ObservableCollection<ObservableNews>()); }
            set { SetProperty(ref _observableNews, value); }
        }

        //public Command ItemTappedCommand
        //{
        //    get
        //    {
        //        return _itemTappedCommand ??
        //               (_itemTappedCommand = new Command(() => ObservableNews.Add(new ObservableNews
        //               {
        //                   Header = "Test Header"
        //               })));
        //    }

        //    set { SetProperty(ref _itemTappedCommand, value); }
        //}

        private async Task UpdateObservableNews()
        {
            IsLoading = true;
            var list = new ObservableCollection<ObservableNews>();
            Debug.WriteLine("COLLECTING NEWS");
            var newsProvider = Resolver.Resolve<INewsProvider>();
            var userProvider = Resolver.Resolve<IUserProvider>();
            var listFromServer = await newsProvider.GetNewsAsyncTask();
            foreach (var newsDto in listFromServer)
            {
                var userList = await userProvider.GetUsersAsyncTask(newsDto.AuthorId);
                var user = userList.FirstOrDefault();
                var observableUser = new ObservableUser()
                {
                    DisplayName = user.DisplayName,
                    AuthorImageUri = user.AuthorImageUri,
                    GivenName = user.GivenName,
                    Id = user.Id,
                    Location = user.Location,
                    SurName = user.SurName,
                    TelephoneNumber = user.TelephoneNumber
                };
                list.Add(new ObservableNews()
                {
                  AuthorUser  = observableUser,
                  DatePosted = DateTime.Parse(newsDto.DatePosted),
                  Description = newsDto.Description,
                  Header = newsDto.Header
                });
            }
            IsLoading = false;
            ObservableNews = list;
        }
    }
}