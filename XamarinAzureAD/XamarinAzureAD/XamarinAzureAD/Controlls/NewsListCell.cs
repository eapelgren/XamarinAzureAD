using System.Collections.ObjectModel;
using DTOModel.Providers.Interfaces;
using Xamarin.Forms;
using XamarinAzureAD.Controlls.Views;
using XamarinAzureAD.Mapper;
using XamarinAzureAD.Model;
using XamarinAzureAD.Pages;
using XamarinAzureAD.ViewModel;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace XamarinAzureAD.Controlls
{
    public class NewsListCell : ContentView
    {
        public NewsListCell()
        {
            //MAY BREAK OUT REGIONS TO SEPARATE UI CLASSES

            var profileHeaderView = new ProfileHeaderView();

            profileHeaderView.AuthorNameLabel.SetBinding(Label.TextProperty,
                new Binding("AuthorObservableUser.DisplayName"));
            profileHeaderView.CircleProfileImage.SetBinding(Image.SourceProperty,
                new Binding("AuthorObservableUser.AuthorImageUri"));
            profileHeaderView.DatePostedLabel.SetBinding(Label.TextProperty, new Binding("DatePosted"));

            var profileHeaderGestureRecognizer = new TapGestureRecognizer();
            profileHeaderGestureRecognizer.Tapped += async (sender, args) =>
            {
                var senderView = (ContentView) sender;
                var news = (ObservableNews) senderView.BindingContext;
                var navPage = App.GetNavigationPage();
                await navPage.PushAsync(new SelectedUserPage(news.AuthorObservableUser));
            };

            profileHeaderView.GestureRecognizers.Add(profileHeaderGestureRecognizer);

            //ToDo Create Bindings For Likes ETC
            var likesAndSeenLabelsView = new LikesAndSeenLabelsView();

            #region newsPostView

            var newsPostView = new NewsPostView();
            newsPostView.NewsPostImage.SetBinding(Image.SourceProperty, new Binding("PictureUri"));
            newsPostView.NewsPostTextLabel.SetBinding(Label.TextProperty, new Binding("Description"));


            var newsTapGestureRecognizers = new TapGestureRecognizer();
            newsTapGestureRecognizers.Tapped += async (sender, args) =>
            {
                var senderView = (ContentView) sender;
                var news = (ObservableNews) senderView.BindingContext;
                var navPage = App.GetNavigationPage();
                await navPage.PushAsync(new SelectedNewsPage(news));
            };
            newsPostView.GestureRecognizers.Add(newsTapGestureRecognizers);

            #endregion

            //ToDo CREATE LIKE AND COMMENT ACCTION
            var likeAndCommentButtonView = new LikeAndCommentButtonsView();

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
                    likesAndSeenLabelsView,
                    likeAndCommentButtonView
                }
            };

            var frame = new Frame
            {
                OutlineColor = Color.Navy,
                Content = cell
            };

            Content = frame;
        }
    }
}