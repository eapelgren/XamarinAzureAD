using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace XamarinAzureAD.Controlls.Views
{
    public class ProfileHeaderView : ContentView
    {
        public ProfileHeaderView()
        {
            CircleProfileImage = new CircleImage
            {
                HeightRequest = 40,
                WidthRequest = 40
            };

            AuthorNameLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label)),
                FontFamily = "Verdana",
                FontAttributes = FontAttributes.None,
                VerticalOptions = LayoutOptions.Center
            };

            DatePostedLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof (Label)),
                VerticalOptions = LayoutOptions.Start
            };

            var nameDateStackView = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 1,
                Children =
                {
                    AuthorNameLabel,
                    DatePostedLabel
                }
            };

            BaseStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                Children =
                {
                    CircleProfileImage,
                    nameDateStackView
                },
                Padding = new Thickness(3, 6, 3, 6)
            };

            Content = BaseStackLayout;
        }

        public CircleImage CircleProfileImage { get; set; }
        public Label AuthorNameLabel { get; set; }
        public Label DatePostedLabel { get; set; }
        public StackLayout BaseStackLayout { get; set; }
    }
}