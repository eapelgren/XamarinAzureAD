﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinAzureAD.Model;
using XamarinAzureAD.Pages;
using XamarinAzureAD.Services;
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
        
        public App()
        {
            // The root page of your application
            Init();
            MainPage = GetMainPage();
        }

        public static Page GetMainPage()
        {
            //REGISTER VM:S AND PAGES
            ViewFactory.Register<LoginPage, LoginPageViewModel>();
            ViewFactory.Register<UserListPage, UserListViewModel>();
            
            
            var mainPage = ViewFactory.CreatePage<LoginPageViewModel, Page>() as Page;
            var navPage = new NavigationPage(mainPage);
            
            //REGISTER NAVIGATION SERVICE
            Resolver.Resolve<IDependencyContainer>()
                .Register<INavigationService>(t => new NavigationService(navPage.Navigation));
            
            //REGISTER AZURE AD SERVICE
        
            
            return navPage;
        }

        public static void Init()
        {

            var app = Resolver.Resolve<IXFormsApp>();
            
            //SET AZURE AD SERVICE
           
            
            
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
