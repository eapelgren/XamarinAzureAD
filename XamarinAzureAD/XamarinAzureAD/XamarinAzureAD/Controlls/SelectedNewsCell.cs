using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XamarinAzureAD.Pages;
using XLabs.Forms.Controls;

namespace XamarinAzureAD.Controlls
{
    public class SelectedNewsCell : ViewCell
    {
        public SelectedNewsCell()
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
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontFamily = "Verdana",
                FontAttributes = FontAttributes.None,
                VerticalOptions = LayoutOptions.Center
            };
            authorName.SetBinding(Label.TextProperty, new Binding("AuthorObservableUser.DisplayName"));

            var datePosted = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
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
            var headerTapGestureRecognizers = new TapGestureRecognizer();
            headerTapGestureRecognizers.Tapped += async (sender, args) =>
            {
                var navPage = App.GetNavigationPage();

                var observableNews = (ObservableNews)this.BindingContext;
                await navPage.PushAsync(new SelectedUserPage(observableNews.AuthorObservableUser));
            };
            profileHeaderView.GestureRecognizers.Add(headerTapGestureRecognizers);

            #endregion

            #region newsPostView

            var newsPostImage = new Image
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start,
            };
            newsPostImage.SetBinding(Image.SourceProperty, new Binding("PictureUri"));

            var newsPostImageView = new ContentView
            {
                Content = newsPostImage,
                Padding = new Thickness(0, 0, 0, 6),
            };

            var newsPostText = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                FontFamily = "Verdana"
            };
            newsPostText.SetBinding(Label.TextProperty, new Binding("Description"));

            var newsPostTextView = new ContentView
            {
                Content = newsPostText
            };


            var newsPostView = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    newsPostTextView,
                    newsPostImageView,
                }
            };

            #endregion

        }
    }
}
