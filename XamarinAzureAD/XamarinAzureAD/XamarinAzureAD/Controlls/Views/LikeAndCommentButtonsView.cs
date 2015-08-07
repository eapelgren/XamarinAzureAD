using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.Controlls.Views
{
    internal class LikeAndCommentButtonsView : ContentView
    {
        public LikeAndCommentButtonsView()
        {

            LikeButton = new Button()
            {
                Text = "Like",
                TextColor = Color.Navy,
            };

            CommentButton = new Button()
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
                },
            };

            Content = BaseStackLayout;
        }

        public Button LikeButton { get; set; }

        public Button CommentButton { get; set; }

        public StackLayout BaseStackLayout { get; set; }
}
}
