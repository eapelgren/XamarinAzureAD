using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinAzureAD.ViewModel;

namespace XamarinAzureAD.Pages
{
    public partial class UserListPage : XLabs.Forms.Mvvm.BaseView
    {
        public UserListPage()
        {
            BindingContext = new UserListViewModel();
            InitializeComponent();
        }
    }
}
