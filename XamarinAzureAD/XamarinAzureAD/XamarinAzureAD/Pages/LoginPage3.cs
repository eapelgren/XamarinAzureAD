using Xamarin.Forms;
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.Pages
{
    public class LoginPage3 : BaseView
    {
        public LoginPage3()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var vm = new LoginPageViewModel();
            BindingContext = vm;

            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            var imageLogo = new Image
            {
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.AspectFit,
                Source = "xlent_rgb",
            };

            var logoImageContentView = new ContentView
            {
                Content = imageLogo,
                Padding = new Thickness(0, 10, 0, 10)
            };

            var emailEntry = new Entry
            {
                Placeholder = "email"
            };
            emailEntry.SetBinding(Entry.TextProperty, new Binding("EmailEntry.Text"));

            //var passwordEntry = new Entry
            //{
            //    IsPassword = true,
            //    Placeholder = "password",
            //    BackgroundColor = Color.White,
            //    TextColor = Color.Black,
            //};

            Entry passwordEntry = vm.PasswordEntry;

            var entryStack = new StackLayout
            {
                Children =
                {
                    emailEntry,
                    passwordEntry,
                },
                Padding = new Thickness(5, 0, 5, 0),
                VerticalOptions = LayoutOptions.Center
            };

            var errorLabel = new Label
            {
                TextColor = Color.Red,
            };
            errorLabel.SetBinding(Label.TextProperty, new Binding("ErrorLabel.Text"));
            errorLabel.SetBinding(IsVisibleProperty, new Binding("ErrorLabel.IsVisible"));

            var loginbutton = new Button
            {
                Text = "Login",
            };
            loginbutton.SetBinding(Button.CommandProperty, new Binding("LoginCommand"));

            var baseStack = new StackLayout
            {
                Children =
                {
                    logoImageContentView,
                    entryStack,
                    errorLabel,
                    loginbutton,
                },
                Padding = new Thickness(10, 5, 10, 5),
                Spacing = 10,
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            emailEntry.Focused += (sender, args) => baseStack.VerticalOptions = LayoutOptions.Start;
            emailEntry.Unfocused += (sender, args) => baseStack.VerticalOptions = LayoutOptions.CenterAndExpand;
            passwordEntry.Focused += (sender, args) => baseStack.VerticalOptions = LayoutOptions.Start;
            passwordEntry.Unfocused += (sender, args) => baseStack.VerticalOptions = LayoutOptions.CenterAndExpand;


            BackgroundColor = Color.White;
            Content = baseStack;
        }
    }
}