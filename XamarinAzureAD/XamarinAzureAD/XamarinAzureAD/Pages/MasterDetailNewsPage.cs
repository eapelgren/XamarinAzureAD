using Xamarin.Forms;

namespace XamarinAzureAD.Pages
{
    public class MasterDetailNewsPage : MasterDetailPage
    {
        public MasterDetailNewsPage()
        {
            Title = "MasterDetail";
            Master = new ContentPage
            {
                BackgroundColor = Color.Gray,
                Title = "Gray Content"
            };

            Detail = new NewsPage();
        }
    }
}