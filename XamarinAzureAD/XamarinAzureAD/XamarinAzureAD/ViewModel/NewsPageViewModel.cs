using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using XamarinAzureAD.Model;

using XamarinAzureAD.Services;
using XLabs.Ioc;

namespace XamarinAzureAD.ViewModel
{
    public class NewsPageViewModel : XLabs.Forms.Mvvm.ViewModel
    {

        public bool isLoading;

        private ObservableCollection<ObservableNews> _observableNews;

        public ObservableCollection<ObservableNews> ObservableNews
        {

            get { return _observableNews ?? (_observableNews = GetNews()); }
            set { SetProperty(ref _observableNews, value); }
        }

        private ObservableCollection<ObservableNews> GetNews()
        {
            isLoading = true;
            var list = new ObservableCollection<ObservableNews>();
            Debug.WriteLine("COLLECTING NEWS");
            Resolver.Resolve<INewsProvider>().GetNewsTaskAsync("test1@xlentwebapi.onmicrosoft.com", "newPassword1").ContinueWith(task =>
            {
                ObservableNews = task.Result;
            });
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
