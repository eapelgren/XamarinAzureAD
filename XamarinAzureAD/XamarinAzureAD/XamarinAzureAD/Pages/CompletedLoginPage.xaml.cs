using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.Pages
{
    [ViewType(typeof(CompletedLoginPage))]
    public partial class CompletedLoginPage : BaseView
    {
        public CompletedLoginPage()
        {
            BindingContext = new CompletedLoginPageViewModel();
            InitializeComponent();
        }
    }
}
