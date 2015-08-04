using System;
using Xamarin.Forms;
using System.Linq;
using XamarinAzureAD.Pages;

namespace MasterDetail
{
	public class RootPage : MasterDetailPage
	{
		MenuPage menuPage;

		public RootPage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
			menuPage = new MenuPage ();
			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);
			Master = menuPage;
			Detail = new NavigationPage (new MainTabbedContainer());
		}

		void NavigateTo (MenuItem menu)
		{
			if (menu == null)
				return;
			
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);
			Detail = new NavigationPage (displayPage);
			menuPage.Menu.SelectedItem = null;
			IsPresented = false;
		}
	}
}