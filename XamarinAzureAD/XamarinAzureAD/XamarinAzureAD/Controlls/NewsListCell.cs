using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace XamarinAzureAD.Controlls
{
    public class NewsListCell : ViewCell
    {
        public NewsListCell()
        {
            
            var image = new Image
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            image.SetBinding(Image.SourceProperty, new Binding("PictureUri"));
            
            var profileHeader = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                Children =
                {
                    new CircleImage()
                    {
                        Source = "https://media.licdn.com/mpr/mpr/shrinknp_400_400/p/7/000/24a/0d9/13e8e14.jpg",
                        HeightRequest = 40,
                        WidthRequest = 40,
                    },
                    new Label()
                    {
                        Text = "Fredrik Tonn",
                    }
                }
            };

            var detailTextCell = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new Label()
                    {
                        Text =
                            "Lorem ipsum dolor sit amet, ea sit animal luptatum, ea oratio electram philosophia quo, pro eu ignota putant recteque. Cu vel invidunt forensibus, ad sea numquam inermis reprehendunt. Ut melius eripuit usu, utinam ornatus est in. Enim vitae habemus nam in, ei tincidunt necessitatibus est, dolor postea everti qui an. Consul perfecto has an, eu his velit adversarium.",
                            FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
                        
                    }
                }
            };

            var cell = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    profileHeader,
                    detailTextCell,
                    image
                }

            };

            this.View = cell;

        }


    }
}
