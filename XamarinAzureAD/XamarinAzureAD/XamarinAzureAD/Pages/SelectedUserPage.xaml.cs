using XamarinAzureAD.Model;
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.Pages
{
    public partial class SelectedUserPage : BaseView
    {
        public SelectedUserPage(ObservableUser user)
        {
            BindingContext = new SelectedUserViewModel(user);
            InitializeComponent();
        }
    }
}