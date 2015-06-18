using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.Pages
{
    [ViewType(typeof(LoginPage))]
    public partial class LoginPage : XLabs.Forms.Mvvm.BaseView
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
