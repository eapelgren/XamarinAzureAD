using System.Collections.Generic;
using XamarinAzureAD.Pages;

namespace MasterDetail
{
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            Add(new MenuItem
            {
                Title = "News",
                IconSource = "contacts.png",
                TargetType = typeof (MainTabbedContainer)
            });

            Add(new MenuItem
            {
                Title = "Messages",
                IconSource = "leads.png",
                TargetType = typeof (MessagesPage)
            });

            Add(new MenuItem
            {
                Title = "About",
                IconSource = "accounts.png",
                TargetType = typeof (AboutPage)
            });

            Add(new MenuItem
            {
                Title = "Account",
                IconSource = "opportunities.png",
                TargetType = typeof (AccountPage)
            });
        }
    }
}