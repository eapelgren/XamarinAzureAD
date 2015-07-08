using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XamarinAzureAD.Pages
{
    public class MasterDetailNewsPage : MasterDetailPage
    {
        public MasterDetailNewsPage()
        {
            this.Title = "MasterDetail";
            this.Master = new ContentPage()
            {
                BackgroundColor = Color.Gray,
                Title = "Gray Content"
                
            };

            this.Detail = new NewsPage();

        }
    }
}
