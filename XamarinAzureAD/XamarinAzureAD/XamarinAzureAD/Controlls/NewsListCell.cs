using Xamarin.Forms;
using XamarinAzureAD.Controlls;
using XamarinAzureAD.Model;
using XamarinAzureAD.Pages;
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

                var observableNews = (ObservableNews) this.BindingContext; 
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
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof (Label)),
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

            var newsTapGestureRecognizers = new TapGestureRecognizer();
            newsTapGestureRecognizers.Tapped += async (sender, args) =>
            {
                var navPage = App.GetNavigationPage();
                await navPage.PushAsync(new SelectedNewsPage((ObservableNews)this.BindingContext));
            };
            newsPostView.GestureRecognizers.Add(newsTapGestureRecognizers);




            #endregion


            var likesLabel = new Label()
            {
                Text = "37 Likes",
                FontSize = 13,
                TextColor = Color.Blue,
            };

            var commentsLabel = new Label()
            {
                Text = "12 Comments",
                FontSize = 13,
                TextColor = Color.Blue,
            };

            var seenbyLabel = new Label()
            {
                Text = "64 Views",
                FontSize = 13,
                TextColor = Color.Blue
            };


            var numbersView = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    likesLabel,
                    commentsLabel,
                    seenbyLabel
                },
                Spacing = 10
            };

            var buttonsView = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Button()
                    {
                        Text = "Like",
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                    },
                    new Button()
                    {
                        Text = "Comment",
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    },
                    new Button()
                    {
                        Text = "Share",
                        HorizontalOptions = LayoutOptions.EndAndExpand
                    }
                },
            };


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
                    numbersView,
                    new BoxView() { Color = Color.Black, WidthRequest = 100, HeightRequest = 2,},
                    buttonsView
                },
            };

            var frame = new Frame()
            {
                HasShadow = true,
                OutlineColor = Color.Navy,
                Content = cell
            };

            var contentHolder = new ContentView()
            {
                Content = frame,
                Padding = new Thickness(5,0,5, 30)
            };

            View = contentHolder;
            
        }
    }
}