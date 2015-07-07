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
            this.Detail = new ContentPage();
            this.Master = new ContentPage();
        }
    }
}
