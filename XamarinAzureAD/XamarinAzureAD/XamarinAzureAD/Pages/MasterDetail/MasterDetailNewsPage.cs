using MasterDetail;
using Xamarin.Forms;

namespace XamarinAzureAD.Pages
{
    public class MasterDetailNewsPage : MasterDetailPage
    {
        public MasterDetailNewsPage()
        {
            Title = "MasterDetail";
            Master = new MenuPage();
            Detail = new MainTabbedContainer();
        }
    }
}