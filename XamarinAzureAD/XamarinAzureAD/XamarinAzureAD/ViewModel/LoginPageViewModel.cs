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

        public Entry UsernameEntry
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
            IsLoading = true;
            LoginToAzure();
            IsLoading = false;
        }

        private void LoginToAzure()
        {
            var adService = Resolver.Resolve<IAzureAdService>();

            var loginAuthResponse = adService.LoginAdTask(UsernameEntry.Text, PasswordEntry.Text);
            if (loginAuthResponse.LoggedIn != null && loginAuthResponse.LoggedIn.Value)
            {
                var storage = Resolver.Resolve<ISecureStorage>();
                storage.Store("refreshToken", System.Text.Encoding.UTF8.GetBytes(loginAuthResponse.EncryptedRefreshToken));
                storage.Store("accessToken", System.Text.Encoding.UTF8.GetBytes(loginAuthResponse.EncryptedAccessToken));
                
                var mainPage2 = ViewFactory.CreatePage<UserListViewModel, Page>() as Page;
                var navPage = new NavigationPage(mainPage2);
                
                //SET NEW NAVIGATION SERVICE
                Resolver.Resolve<IDependencyContainer>()
                    .Register<INavigationService>(t => new NavigationService(navPage.Navigation));
                
                //NAVIGATE TO NEW VIEWMODEL
                Application.Current.MainPage = navPage;

            }
            else
            {
                ExceptionLabel.Text = loginAuthResponse.Exception.ToString();
                ExceptionLabel.IsVisible = true;
                Debug.WriteLine("ERROR Loggin" + loginAuthResponse.Exception);
            }
            
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
