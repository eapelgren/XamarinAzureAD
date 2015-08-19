using Xamarin.Forms;
using XamarinAzureAD.Model;
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace XamarinAzureAD.Pages
{
    [ViewType(typeof (UsersPage))]
    public partial class UsersPage : BaseView
    {
        private readonly UserPageViewModel vm;

        public UsersPage()
        {
            vm = new UserPageViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        private void Entry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry) sender;
            vm.SearchText = entry.Text;
            vm.UpdateListAfterSearch();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView) sender;
            var observableUser = (ObservableUser) listView.SelectedItem;
            var navService = Resolver.Resolve<INavigationService>();
            Navigation.PushAsync(new SelectedUserPage(observableUser));
        }
    }
}