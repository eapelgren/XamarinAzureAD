using System;
using System.Diagnostics;
using System.Text;
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
        private bool _isLoading;

        public bool IsLoading
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
                    Text = "Username",
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

        //private Command _entryTapCommand;

        //public Command EntryTapCommand
        //{

        //    get { return _entryTapCommand ?? (_entryTapCommand = new Command(
        //    {
        //        throw new not
        //    }) }
        //    set { SetProperty(ref _entryTapCommand, value); }
        //}


		

		


        private void LogginButtonClicked()
        {
            IsLoading = true;
            LoginToAzure();
        }

        private async void LoginToAzure()
        {
            try
            {
                var adService = Resolver.Resolve<IAzureRestService>();
                XlentAuthResult loginAuthResponse =
                    await adService.LoginAdTaskAsync(UsernameEntry.Text, PasswordEntry.Text);
                var storage = Resolver.Resolve<ISecureStorage>();
                storage.Store("refreshToken", Encoding.UTF8.GetBytes(loginAuthResponse.RefreshToken));
                storage.Store("accessToken", Encoding.UTF8.GetBytes(loginAuthResponse.IdToken));
            }
            catch (Exception ee)
            {
                Debug.WriteLine("ERROR IN LOGIN TO AZURE");
                throw;
            }


            var mainPage2 = ViewFactory.CreatePage<NewsPageViewModel, Page>() as Page;
            var navPage = new NavigationPage(mainPage2);

            //SET NEW NAVIGATION SERVICE
            Resolver.Resolve<IDependencyContainer>()
                .Register<INavigationService>(t => new NavigationService(navPage.Navigation));
            //NAVIGATE TO NEW VIEWMODEL
            Application.Current.MainPage = navPage
        }
    }
}

