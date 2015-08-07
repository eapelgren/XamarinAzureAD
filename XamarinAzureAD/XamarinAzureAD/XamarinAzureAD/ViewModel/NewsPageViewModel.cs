using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTOModel.Model;
using DTOModel.Providers.Interfaces;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XLabs.Data;
using XLabs.Ioc;

namespace XamarinAzureAD.ViewModel
{
    public class NewsPageViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private Command _itemTappedCommand;
        private ObservableCollection<ObservableObject> _observableNews;
        public bool IsLoading;

        public NewsPageViewModel()
        {
            Debug.WriteLine("Startin synchron UpdateNews");
            UpdateObservableNews();
            Debug.WriteLine("Finnished synchron UpdateNews");
        }

        public ObservableCollection<ObservableObject> ObservableNews
        {
            get { return _observableNews ?? (_observableNews = new ObservableCollection<ObservableObject>()); }
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

        private async Task UpdateObservableNews()
        {
            try
            {
                IsLoading = true;
                var list = ObservableNews;
                Debug.WriteLine("COLLECTING NEWS");
                var newsProvider = Resolver.Resolve<INewsProvider>();
                var listFromServer = await newsProvider.GetNewsAsyncTask();
                Debug.WriteLine("COLLECTED NEWS");
                var fromServer = listFromServer as IList<INewsDTO> ?? listFromServer.ToList();
                Debug.WriteLine("Count: " + fromServer.Count());
                foreach (var newsDto in fromServer)
                {
                    list.Add(new ObservableNews
                    {
                        AuthorObservableUser = new ObservableUser
                        {
                            AuthorImageUri = new Uri(newsDto.Author.AuthorImageUri),
                            DisplayName = newsDto.Author.DisplayName,
                            GivenName = newsDto.Author.GivenName,
                            Id = newsDto.Author.Id,
                            Location = newsDto.Author.Location,
                            SurName = newsDto.Author.SurName,
                            TelephoneNumber = newsDto.Author.TelephoneNumber
                        },
                        DatePosted = newsDto.DatePosted,
                        Description = newsDto.Description,
                        Header = newsDto.Header,
                        Id = newsDto.Id,
                        PictureUri = new Uri(newsDto.PictureUri)
                    });
                }
                IsLoading = false;
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.Message);
                Debug.WriteLine(ee.InnerException.Message);
                throw;
            }
        }
    }
}