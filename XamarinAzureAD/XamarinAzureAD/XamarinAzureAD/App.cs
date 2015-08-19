using System.Diagnostics;
using MasterDetail;
using Xamarin.Forms;
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

            navPage = new NavigationPage(new RootPage());

            Resolver.Resolve<IDependencyContainer>()
                .Register<INavigationService>(t => new NavigationService(navPage.Navigation));

            //Should be navPage
            return navPage;
        }

        public static void Init()
        {
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