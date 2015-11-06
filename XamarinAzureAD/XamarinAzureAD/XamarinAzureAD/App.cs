<<<<<<< HEAD
﻿using System.Diagnostics;
using MasterDetail;
using Xamarin.Forms;
using XamarinAzureAD.Pages;
=======
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinAzureAD.Model;
using XamarinAzureAD.Pages;
using XamarinAzureAD.Services;
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
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
<<<<<<< HEAD
        private static NavigationPage navPage;

=======
        
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
        public App()
        {
            // The root page of your application
            Init();
            MainPage = GetMainPage();
        }

        public static Page GetMainPage()
        {
            //REGISTER VM:S AND PAGES
<<<<<<< HEAD
            ViewFactory.Register<LoginPage3, LoginPageViewModel>();
            ViewFactory.Register<NewsPage, NewsPageViewModel>();
            ViewFactory.Register<SelectedNewsPage, SelectedNewsViewModel>();

            Resolver.Resolve<IDependencyContainer>()
                .Register<NavigationPage>(t => new NavigationPage());

            var rootPage = new RootPage();
            navPage = new NavigationPage(rootPage);
            
            Resolver.Resolve<IDependencyContainer>()
                .Register<INavigationService>(t => new NavigationService(navPage.Navigation));
            
            //Should be navPage
=======
            ViewFactory.Register<LoginPage, LoginPageViewModel>();
            ViewFactory.Register<UserListPage, UserListViewModel>();
            
            
            var mainPage = ViewFactory.CreatePage<LoginPageViewModel, Page>() as Page;
            var navPage = new NavigationPage(mainPage);
            
            //REGISTER NAVIGATION SERVICE
            Resolver.Resolve<IDependencyContainer>()
                .Register<INavigationService>(t => new NavigationService(navPage.Navigation));
            
            //REGISTER AZURE AD SERVICE
        
            
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
            return navPage;
        }

        public static void Init()
        {
<<<<<<< HEAD
            var app = Resolver.Resolve<IXFormsApp>();

=======

            var app = Resolver.Resolve<IXFormsApp>();
            
            //SET AZURE AD SERVICE
           
            
            
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
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

<<<<<<< HEAD
        public static NavigationPage GetNavigationPage()
        {
            return navPage;
        }
=======


>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d

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
<<<<<<< HEAD
}
=======
}
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
