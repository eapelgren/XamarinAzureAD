using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.Pages
{
    [ViewType(typeof (SelectedNewsPage))]
    public partial class SelectedNewsPage : BaseView
    {
        private readonly SelectedNewsViewModel vm;

        public SelectedNewsPage(ObservableNews news, ObservableCollection<ObservableComment> commentList)
        {
            Title = "SelectedNewsPage";
            vm = new SelectedNewsViewModel(news, commentList);
            BindingContext = vm;
            InitializeComponent();
        }

        private void EntryIsFocused(object sender, FocusEventArgs e)
        {
            vm.ScrollViewIsVisisble = false;
        }

        private void SendComment(object sender, EventArgs e)
        {
            //vm.SendComment();
        }
    }
}