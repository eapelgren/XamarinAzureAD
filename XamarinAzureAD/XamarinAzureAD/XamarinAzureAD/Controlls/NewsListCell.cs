using Xamarin.Forms;
using XamarinAzureAD.Controlls.Views;

namespace XamarinAzureAD.Controlls
{
    public class NewsListCell : ViewCell
    {
        public NewsListCell()
        {
            //MAY BREAK OUT REGIONS TO SEPARATE UI CLASSES

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

            #endregion

            var cell = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 2,
                Children =
                {
                    new PostHeaderView(),
                    newsPostView,
                },
            };

            View = cell;
        }
    }
}