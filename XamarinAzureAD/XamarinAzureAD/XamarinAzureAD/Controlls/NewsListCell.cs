using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Behaviors;
using XLabs.Forms.Controls;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;

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
            authorName.SetBinding(Label.TextProperty, new Binding("AuthorUser.DisplayName"));

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

            var headerTapGestureRecongnizer = new TapGestureRecognizer();
            headerTapGestureRecongnizer.Tapped += (sender, args) =>
            {
                var navigation = Resolver.Resolve<INavigationService>();
                var p = 2;
            };

            var profileHeaderView = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                Children =
                {
                    circleProfileImage,
                    nameDateStackView
                },
                Padding = new Thickness(3,6,3,6),
            };
            profileHeaderView.SetBinding(StackLayout.ClassIdProperty, new Binding("AuthorUser.Id"));
            profileHeaderView.GestureRecognizers.Add(headerTapGestureRecongnizer);

            #endregion

            #region newsPostView

            var newsPostImage = new Image()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start,
            };
            newsPostImage.SetBinding(Image.SourceProperty, new Binding("PictureUri"));

            var newsPostImageView = new ContentView()
            {
                Content = newsPostImage,
                Padding = new Thickness(0,0,0,6),
            };

            var newsPostText = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof (Label)),
                FontFamily = "Verdana"
            };
            newsPostText.SetBinding(Label.TextProperty, new Binding("Description"));

            var newsPostTextView = new ContentView()
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


            #region gestures

   
            #endregion


            View = cell;
        }
    }

   
}