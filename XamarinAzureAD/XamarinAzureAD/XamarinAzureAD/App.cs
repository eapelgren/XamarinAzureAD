using System.Diagnostics;
using Xamarin.Forms;
using XamarinAzureAD.Pages;
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;
using XLabs.Platform.Mvvm;

namespace XamarinAzureAD
{
    public class App : Application
    {
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

            var mainPage = ViewFactory.CreatePage<LoginPageViewModel, Page>() as Page;
            var navPage = new NavigationPage(new MainTabbedContainer());
            //SHOULD BE NAVPAGE
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