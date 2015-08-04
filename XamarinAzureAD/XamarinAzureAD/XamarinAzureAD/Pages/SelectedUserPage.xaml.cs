using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
