﻿using Xamarin.Forms;

namespace XamarinAzureAD.Pages
{
    public partial class MainTabbedContainer : TabbedPage
    {
        public MainTabbedContainer()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}