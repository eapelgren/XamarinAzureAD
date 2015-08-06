using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace XamarinAzureAD.Controlls
{
    class CommentCell : ExtendedViewCell
    {
        public CommentCell()
        {
            var circleProfileImage = new CircleImage
            {
                HeightRequest = 30,
                WidthRequest = 30,
                VerticalOptions = LayoutOptions.Start
            };
            circleProfileImage.SetBinding(Image.SourceProperty, new Binding("Author.AuthorImageUri"));

            View authorNameLabel = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 13,
                VerticalOptions = LayoutOptions.Start,
            };
            authorNameLabel.SetBinding(Label.TextProperty, new Binding("Author.DisplayName"));


            var authorView = new ContentView()
            {
                Content = authorNameLabel
            };

            View commentLabel = new Label()
            {
                FontSize = 10,
            };
            commentLabel.SetBinding(Label.TextProperty, new Binding("Comment"));

            var dateLabel = new Label()
            {
                Text = DateTime.Now.ToString(),
                FontSize = 13,
                TextColor = Color.Blue,
            };

            View textView = new StackLayout()
            {
                Children =
                {
                    authorView,
                    commentLabel,
                    dateLabel
                },
                Orientation = StackOrientation.Vertical
            };



            var baseStack = new StackLayout()
            {
                Children =
                {
                    circleProfileImage,
                    textView,
                },
                Orientation = StackOrientation.Horizontal,
                Spacing = 8,
            };

            var baseView = new ContentView()
            {
                Padding = new Thickness(5, 0, 5, 10),
                BackgroundColor = Color.Gray,
                Content = baseStack
            };
            ShowDisclousure = false;
            View = baseView;
        }
    }
}
