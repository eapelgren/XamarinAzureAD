using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAzureAD.Services;
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace XamarinAzureAD.ViewModel
{
    class LoginPageViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private Boolean _isLoading = false;

        public Boolean IsLoading
        {

            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }




        //private readonly IAzureAdService azureService = Resolver.Resolve<IAzureAdService>();

        private void LoginToAzure()
        {
            IsLoading = true;
            //var loggedIn = await azureService.LoginAdTask();


            //TEMP
            var loggedIn = true;

            IsLoading = false;
            if (loggedIn)
            {
                var mainPage2 = ViewFactory.CreatePage<UserListViewModel, Page>() as Page;
                var navPage = new NavigationPage(mainPage2);
                Resolver.Resolve<IDependencyContainer>()
                    .Register<INavigationService>(t => new NavigationService(navPage.Navigation));
                App.Current.MainPage = navPage;
            }





        }

        private Label _logoLabel;

        public Label LogoLabel
        {

            get
            {
                return _logoLabel ?? (_logoLabel = new Label()
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
                return _usernameEntry ?? (_usernameEntry = new Entry()
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
                return _passwordEntry ?? (_passwordEntry = new Entry()
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
                return _loginButton ?? (_loginButton = new Button()
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


    }
}
