using Xamarin.Forms;
using XamarinAzureAD.Model;
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.Pages
{
    [ViewType(typeof (NewsPage))]
    public partial class NewsPage : BaseView
    {
        public NewsPage()
        {
            Title = "NewsPage";
            BindingContext = new NewsPageViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView) sender;
            var observableNews = (ObservableNews) listView.SelectedItem;

            Navigation.PushAsync(new SelectedNewsPage(observableNews));
        }
    }
}