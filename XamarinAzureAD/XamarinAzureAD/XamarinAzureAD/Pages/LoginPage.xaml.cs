using Xamarin.Forms;
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.Pages
{
    [ViewType(typeof (LoginPage))]
    public class LoginPage : BaseView
    {
        public LoginPage()
        {
            BindingContext = new LoginPageViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}