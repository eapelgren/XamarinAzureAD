using System;
using System.Diagnostics;
using Xamarin.Forms;
using XamarinAzureAD.Pages;
using XLabs.Ioc;

namespace MasterDetail
{
    public class RootPage : MasterDetailPage
    {
        private readonly MenuPage menuPage;

        public RootPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            menuPage = new MenuPage();
            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);
            Master = menuPage;
            Detail = new MainTabbedContainer();
        }

        private void NavigateTo(MenuItem menu)
        {
            if (menu == null)
                return;

            var displayPage = (Page) Activator.CreateInstance(menu.TargetType);

            var navPage = Resolver.Resolve<NavigationPage>();
            try
            {
            navPage.PopToRootAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            navPage.PushAsync(displayPage);

            Detail = navPage;
            menuPage.Menu.SelectedItem = null;
            IsPresented = false;
        }
    }
}