using Xamarin.Forms;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.Controlls
{
    public class DynamicItemTemplate : ViewCell
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ObservableNews)
            {
                View = new NewsListCell();
            }

            else if (BindingContext is ObservableEvent)
            {
            }
            else
            {
                View = new Label {Text = "View model does not have a view."};
            }

            Height = View.HeightRequest;

            View.BindingContext = BindingContext;
        }
    }
}