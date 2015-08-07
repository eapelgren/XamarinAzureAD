using System;
using System.Diagnostics;
using System.Windows.Input;
using DTOModel.Providers.Interfaces;
using Xamarin.Forms;
using XamarinAzureAD.Handler;
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace XamarinAzureAD.ViewModel
{
    public class LoginPageViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private StackLayout _baseStack;
        private Label _errorLabel;
        private bool _isLoading;
        private Button _loginButton;
        private Entry _passwordEntry;
        private Entry _usernameEntry;
        public bool ErrorHasOccoured;

        public LoginPageViewModel()
        {
            ErrorHasOccoured = false;
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        public Entry EmailEntry
        {
            get
            {
                return _usernameEntry ?? (_usernameEntry = new Entry
                {
                    Text = "test1@xlentwebapi.onmicrosoft.com"
                });
            }
            set { SetProperty(ref _usernameEntry, value); }
        }

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
                    return new Command(() =>
                    {
                        IsLoading = true;
                        LoginToAzureNavigateToNewsPage();
                    });
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


        public Label ErrorLabel
        {
            get
            {
                return _errorLabel ?? (_errorLabel = new Label
                {
                    Text = "Enter Username Password",
                    IsVisible = ErrorHasOccoured
                });
            }
            set { SetProperty(ref _errorLabel, value); }
        }

        public StackLayout BaseStack
        {
            get
            {
                return _baseStack ?? (_baseStack = new StackLayout
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand
                });
            }
            set { SetProperty(ref _baseStack, value); }
        }

        private async void LoginToAzureNavigateToNewsPage()
        {
            try
            {
                var adService = Resolver.Resolve<IAuthenticationProvider>();
                var loginAuthResponse =
                    await adService.GetTokensAsyncTask(EmailEntry.Text, PasswordEntry.Text);
                var tokenHandler = new LocalTokenHandler();
                tokenHandler.SetAccessToken(loginAuthResponse.AccessToken);
                tokenHandler.SetRefreshToken(loginAuthResponse.RefreshToken);
            }
            catch (Exception ee)
            {
                ErrorHasOccoured = true;
                ErrorLabel.Text = "Invalid Username or Password";
                Debug.WriteLine("ERROR IN LOGIN TO AZURE" + ee.Message);
                return;
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