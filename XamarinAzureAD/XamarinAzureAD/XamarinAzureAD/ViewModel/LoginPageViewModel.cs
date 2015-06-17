using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XamarinAzureAD.Services;
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace XamarinAzureAD.ViewModel
{
    internal class LoginPageViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private Boolean _isLoading;

        public Boolean IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private async void LoginToAzure()
        {
            IsLoading = true;
            var adService = Resolver.Resolve<IAzureAdService>();

            var task = adService.LoginAdTask("username", "password");
            var result = await task;
            if (result.LoggedIn)
            {
                var mainPage2 = ViewFactory.CreatePage<UserListViewModel, Page>() as Page;
                var navPage = new NavigationPage(mainPage2);
                Resolver.Resolve<IDependencyContainer>()
                    .Register<INavigationService>(t => new NavigationService(navPage.Navigation));
                Application.Current.MainPage = navPage;

            }
            else
            {
                ExceptionLabel.Text = result.Exception.InnerException.ToString();
                ExceptionLabel.IsVisible = true;
                Debug.WriteLine("ERROR Loggin" + result.Exception);
            }
            IsLoading = false;
        }

        private Label _logoLabel;

        public Label LogoLabel
        {
            get
            {
                return _logoLabel ?? (_logoLabel = new Label
                {
                    Text = "LOGO COMPANY..."
                });
            }
            set { SetProperty(ref _logoLabel, value); }
        }

        private Entry _usernameEntry;

        public Entry UsernamEntry
        {
            get
            {
                return _usernameEntry ?? (_usernameEntry = new Entry
                {
                    Text = "Username"
                });
            }
            set { SetProperty(ref _usernameEntry, value); }
        }

        private Entry _passwordEntry;

        public Entry PasswordEntry
        {
            get
            {
                return _passwordEntry ?? (_passwordEntry = new Entry
                {
                    Text = "Password",
                    IsPassword = true
                });
            }
            set { SetProperty(ref _passwordEntry, value); }
        }

        private Button _loginButton;

        public Button LoginButton
        {
            get
            {
                return _loginButton ?? (_loginButton = new Button
                {
                    Text = "Login",
                    BackgroundColor = Color.Blue
                });
            }
            set { SetProperty(ref _loginButton, value); }
        }

        private Command _loginCommand;

        public Command LoginCommand
        {
            get
            {
                return _loginCommand ??
                       (_loginCommand =
                           new Command(LogginButtonClicked));
            }
        }

        private void LogginButtonClicked()
        {
            LoginToAzure();
        }

        private Label _exceptionLabel;

        public Label ExceptionLabel
        {

            get
            {
                return _exceptionLabel ?? (_exceptionLabel = new Label()
                {
                  IsEnabled  = true,
                  TextColor = Color.Red,
                  IsVisible = false
                });
            }
            set { SetProperty(ref _exceptionLabel, value); }
        }


		

		

    }
        
}
