using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace XamarinAzureAD.Controlls
{
    public class UserCell : ExtendedViewCell
    {
        public UserCell()
        {
            var nameLabel = new Label
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            nameLabel.SetBinding(Label.TextProperty, new Binding("DisplayName"));

            var locationLabel = new Label
            {
                FontSize = 12
            };
            locationLabel.SetBinding(Label.TextProperty, new Binding("Location"));


            var roundedImage = new CircleImage
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 40,
                WidthRequest = 40
            };
            roundedImage.SetBinding(Image.SourceProperty, new Binding("AuthorImageUri"));


            var nameStack = new StackLayout
            {
                Children =
                {
                    nameLabel,
                    locationLabel
                }
            };

            View roundedImageContentView = new ContentView
            {
                Content = roundedImage,
                Padding = new Thickness(5, 0, 0, 0)
            };

            var mainStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    roundedImageContentView,
                    nameStack
                }
            };

            View = mainStack;
        }
    }
}