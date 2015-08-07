using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XamarinAzureAD.ViewModel;

namespace XamarinAzureAD.Controlls
{
    public class DynamicItemTemplate : ViewCell
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext is ObservableNews)
            {
                this.View = new NewsListCell();
            }

            else if (this.BindingContext is ObservableEvent)
            {
                
            }
            else
            {
                this.View = new Label() { Text = "View model does not have a view." };
            }

            this.Height = this.View.HeightRequest;

            this.View.BindingContext = this.BindingContext;
        }
    }
}