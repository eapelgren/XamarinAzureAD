using System;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace XamarinAzureAD.Controlls
{
    public class NewsListCell : ViewCell
    {
        public NewsListCell()
        {
            //MAY BREAK OUT REGIONS TO SEPARATE UI CLASSES
            #region profileHeaderView

            var circleProfileImage = new CircleImage()
            {
                Source = "https://media.licdn.com/mpr/mpr/shrinknp_400_400/p/7/000/24a/0d9/13e8e14.jpg",
                HeightRequest = 40,
                WidthRequest = 40,
            };
            //circleProfileImage.SetBinding(CircleImage.SourceProperty, new Binding());


            var authorName = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label)),
                FontFamily = "Verdana",
                FontAttributes = FontAttributes.None,
                VerticalOptions = LayoutOptions.Center
            };
            authorName.SetBinding(Label.TextProperty, new Binding("AuthorName"));

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

            var profileHeaderView = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                Children =
                {
                    circleProfileImage,
                    nameDateStackView
                }
            };

            #endregion

            #region newsPostView

            var newsPostImage = new ImageGallery()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start,
                ItemsSource = {}
                
            };
            newsPostImage.SetBinding(Image.SourceProperty, new Binding("PictureUri"));

            var newsPostText = new Label
            {
                Text =
                    "Lorem ipsum dolor sit amet, ea sit animal luptatum, ea oratio electram philosophia quo, pro eu ignota putant recteque. Cu vel invidunt forensibus, ad sea numquam inermis reprehendunt. Ut melius eripuit usu, utinam ornatus est in. Enim vitae habemus nam in, ei tincidunt necessitatibus est, dolor postea everti qui an. Consul perfecto has an, eu his velit adversarium.",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof (Label)),
                FontFamily = "Verdana"
            };


            var newsPostView = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    newsPostText,
                    newsPostImage
                }
            };

            #endregion
            
            var cell = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 2,
                Children =
                {
                    profileHeaderView,
                    newsPostView,
                },
            };

            View = cell;
        }
    }
}