using System;
using System.Diagnostics;
using DTOModel.Model;
using DTOModel.Providers.Implementations.Mocked;
using DTOModel.Providers.Interfaces;
using MasterDetail;
using Xamarin.Forms;
using XamarinAzureAD.Handler;
using XamarinAzureAD.Model;
using XamarinAzureAD.Pages;
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services;

namespace XamarinAzureAD
{
    public class App : Application
    {
        private static NavigationPage navPage;

        public App()
        {
            // The root page of your application
            Init();
            MainPage = GetMainPage();
        }

        public static Page GetMainPage()
        {
            //REGISTER VM:S AND PAGES
            ViewFactory.Register<LoginPage3, LoginPageViewModel>();
            ViewFactory.Register<NewsPage, NewsPageViewModel>();

            //var mainPage = ViewFactory.CreatePage<LoginPageViewModel, Page>() as Page;
            navPage = new NavigationPage(new RootPage());

            Resolver.Resolve<IDependencyContainer>()
.Register<INavigationService>(t => new NavigationService(navPage.Navigation));
            //SHOULD BE NAVPAGE
            //var newsDto = new NewsDTO
            //{
            //    Author = new UserDTO
            //    {
            //        DisplayName = "Fredrik Tonn",
            //        AuthorImageUri =
            //            "https://media.licdn.com/mpr/mpr/shrinknp_400_400/p/7/000/24a/0d9/13e8e14.jpg",
            //        GivenName = "MOCKED GIVEN NAME",
            //        Id = "222",
            //        Location = "Stockholm",
            //        SurName = "SURNAME",
            //        TelephoneNumber = "23232332"
            //    },
            //    DatePosted = DateTime.Now.ToString(),
            //    Description =
            //        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            //    Header = "Fredrik en Lysande Medarbetare",
            //    Id = "222",
            //    PictureUri = "https://www.xlent.se/wp-content/mnd/438915.jpg",
            //    Points = "2.2",
            //    Score = "4"
            //};
            //var news = new ObservableNews()
            //{
            //    AuthorObservableUser = new ObservableUser()
            //    {
            //        AuthorImageUri = new Uri(newsDto.Author.AuthorImageUri),
            //        DisplayName = newsDto.Author.DisplayName,
            //        GivenName = newsDto.Author.GivenName,
            //        Id = newsDto.Author.Id,
            //        Location = newsDto.Author.Location,
            //        SurName = newsDto.Author.SurName,
            //        TelephoneNumber = newsDto.Author.TelephoneNumber
            //    },
            //    DatePosted = newsDto.DatePosted,
            //    Description = newsDto.Description,
            //    Header = newsDto.Header,
            //    Id = newsDto.Id,
            //    PictureUri = new Uri(newsDto.PictureUri)
            //};
            
            //var selectedNewsPage = new SelectedNewsPage(news);

            return navPage;
        }

        public static void Init()
        {
            MapperConfiguration.Init();
            var app = Resolver.Resolve<IXFormsApp>();

            if (app == null)
            {
                return;
            }

            app.Closing += (o, e) => Debug.WriteLine("Application Closing");
            app.Error += (o, e) => Debug.WriteLine("Application Error");
            app.Initialize += (o, e) => Debug.WriteLine("Application Initialized");
            app.Resumed += (o, e) => Debug.WriteLine("Application Resumed");
            app.Rotation += (o, e) => Debug.WriteLine("Application Rotated");
            app.Startup += (o, e) => Debug.WriteLine("Application Startup");
            app.Suspended += (o, e) => Debug.WriteLine("Application Suspended");
        }

        public static NavigationPage GetNavigationPage()
        {
            return navPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}