using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinAzureAD.Handler;
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
                    Text = "test1@xlentwebapi.onmicrosoft.com",
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
                    Text = "newPassword1",
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

        public ICommand LoginCommand
        {
            get
            {
                try
                {
                return new Command(LogginButtonClicked);

                }
                catch (Exception ee)
                {
                    Debug.WriteLine("GETS HERE");
                    throw;
                }
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
            LoginToAzureNavigateToNewsPage();
        }

        private async void LoginToAzureNavigateToNewsPage()
        {
            try
            {
                var adService = Resolver.Resolve<IAuthenticationProvider>();
                XlentAuthResult loginAuthResponse =
                    await adService.LoginAdTaskAsync(UsernameEntry.Text, PasswordEntry.Text);
                var tokenHandler = new LocalTokenHandler();
                tokenHandler.SetAccessToken(loginAuthResponse.AccessToken);
                tokenHandler.SetRefreshToken(loginAuthResponse.RefreshToken);
            }
            catch (Exception ee)
            {
                Debug.WriteLine("ERROR IN LOGIN TO AZURE");
                throw;
            }


            var newsPage = ViewFactory.CreatePage<NewsPageViewModel, Page>() as Page;
            var navPage = new NavigationPage(newsPage);

            //SET NEW NAVIGATION SERVICE
            Resolver.Resolve<IDependencyContainer>()
                .Register<INavigationService>(t => new NavigationService(navPage.Navigation));
            //NAVIGATE TO NEW VIEWMODEL
            Application.Current.MainPage = navPage;
        }
    }
}

