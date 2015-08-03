using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace XamarinAzureAD.Controlls.Views
{
    public class PostHeaderView : ContentView
    {
        public PostHeaderView()
        {
            #region profileHeaderView

            var circleProfileImage = new CircleImage
            {
                HeightRequest = 40,
                WidthRequest = 40,
            };
            circleProfileImage.SetBinding(Image.SourceProperty, new Binding("AuthorObservableUser.AuthorImageUri"));


            var authorName = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label)),
                FontFamily = "Verdana",
                FontAttributes = FontAttributes.None,
                VerticalOptions = LayoutOptions.Center
            };
            authorName.SetBinding(Label.TextProperty, new Binding("AuthorObservableUser.DisplayName"));

            var datePosted =
                new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof (Label)),
                    VerticalOptions = LayoutOptions.Start
                };
            datePosted.SetBinding(Label.TextProperty, new Binding("DatePosted"));

            var nameDateStackView = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 1,
                Children =
                {
                    authorName,
                    datePosted
                },
            };

            var profileHeaderView = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                Children =
                {
                    circleProfileImage,
                    nameDateStackView
                },
                Padding = new Thickness(3, 6, 3, 6),
            };
            profileHeaderView.SetBinding(ClassIdProperty, new Binding("AuthorObservableUser.Id"));
            //profileHeaderView.GestureRecognizers.Add(headerTapGestureRecongnizer);

            #endregion
        }
    }
}