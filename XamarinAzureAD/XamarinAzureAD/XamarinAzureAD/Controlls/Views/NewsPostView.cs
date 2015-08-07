using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinAzureAD.Controlls.Views
{
    public class NewsPostView : ContentView
    {
        public NewsPostView()
        {
            NewsPostImage = new Image
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start,
            };

            //PADDING FOR PICTURE
            var newsPostImageView = new ContentView
            {
                Content = NewsPostImage,
                Padding = new Thickness(0, 0, 0, 6)
            };

           NewsPostTextLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                FontFamily = "Verdana"
            };

            BaseStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    NewsPostTextLabel,
                    newsPostImageView
                }
            };

            Content = BaseStackLayout;
        }

        public Image NewsPostImage { get; set; }

        public Label NewsPostTextLabel { get; set; }

        public StackLayout BaseStackLayout { get; set; }

    }
}
