using System;
<<<<<<< HEAD
<<<<<<< HEAD
using System.Diagnostics;
using System.Windows.Input;
using DTOModel.Providers.Interfaces;
using Xamarin.Forms;
using XamarinAzureAD.Handler;
=======
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XamarinAzureAD.Services;
<<<<<<< HEAD
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace XamarinAzureAD.ViewModel
{
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
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
<<<<<<< HEAD
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
        {
            get
            {
                return _usernameEntry ?? (_usernameEntry = new Entry
                {
<<<<<<< HEAD
<<<<<<< HEAD
                    Text = "test1@xlentwebapi.onmicrosoft.com"
=======
                    Text = "Username"
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
                    Text = "Username"
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
                });
            }
            set { SetProperty(ref _usernameEntry, value); }
        }

<<<<<<< HEAD
<<<<<<< HEAD
=======
        private Entry _passwordEntry;

>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
        private Entry _passwordEntry;

>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
        public Entry PasswordEntry
        {
            get
            {
                return _passwordEntry ?? (_passwordEntry = new Entry
                {
<<<<<<< HEAD
<<<<<<< HEAD
                    Text = "newPassword1",
=======
                    Text = "Password",
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
                    Text = "Password",
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
                    IsPassword = true
                });
            }
            set { SetProperty(ref _passwordEntry, value); }
        }

<<<<<<< HEAD
<<<<<<< HEAD
=======
        private Button _loginButton;

>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
        private Button _loginButton;

>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
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

<<<<<<< HEAD
<<<<<<< HEAD
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
=======
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
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
<<<<<<< HEAD
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
