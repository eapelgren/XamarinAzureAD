using Xamarin.Forms;

namespace XamarinAzureAD.Controlls.Views
{
    internal class LikeAndCommentButtonsView : ContentView
    {
        public LikeAndCommentButtonsView()
        {
            LikeButton = new Button
            {
                Text = "Like",
                TextColor = Color.Navy
            };

            CommentButton = new Button
            {
                Text = "Comment",
                TextColor = Color.Navy
            };

            BaseStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    LikeButton,
                    CommentButton
                }
            };

            Content = BaseStackLayout;
        }

        public Button LikeButton { get; set; }
        public Button CommentButton { get; set; }
        public StackLayout BaseStackLayout { get; set; }
    }
}