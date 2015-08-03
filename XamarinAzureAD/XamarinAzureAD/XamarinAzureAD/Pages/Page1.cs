using Xamarin.Forms;
using XamarinAzureAD.ViewModel;

namespace XamarinAzureAD.Pages
{
    public class Page1 : ContentPage
    {
        public Page1()
        {
            Content = new StackLayout
            {
                Children =
                {
                    new Label {Text = "Hello ContentPage"}
                }
            };

            var vm = new NewsPageViewModel();
        }
    }
}