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
    [ViewType(typeof(SelectedNewsPage))]
    public partial class SelectedNewsPage : BaseView
    {
        public SelectedNewsPage(ObservableNews news)
        {
            BindingContext = new SelectedNewsViewModel(news);
            InitializeComponent();
        }
    }
}
