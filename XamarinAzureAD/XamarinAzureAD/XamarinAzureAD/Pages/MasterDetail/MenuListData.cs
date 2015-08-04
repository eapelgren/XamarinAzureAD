using System;
using Xamarin.Forms;
using System.Collections.Generic;
using XamarinAzureAD.Pages;

namespace MasterDetail
{

	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "News", 
				IconSource = "contacts.png", 
				TargetType = typeof(MainTabbedContainer)
			});

			this.Add (new MenuItem () { 
				Title = "Messages", 
				IconSource = "leads.png", 
				TargetType = typeof(MessagesPage)
			});

			this.Add (new MenuItem () { 
				Title = "About", 
				IconSource = "accounts.png", 
				TargetType = typeof(AboutPage)
			});

			this.Add (new MenuItem () {
				Title = "Account",
				IconSource = "opportunities.png",
				TargetType = typeof(AccountPage)
			});
		}
	}
}