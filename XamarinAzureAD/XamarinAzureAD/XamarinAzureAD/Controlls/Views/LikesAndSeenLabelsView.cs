using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.Controlls.Views
{
    public class LikesAndSeenLabelsView : ContentView
    {
        public LikesAndSeenLabelsView()
        {

            LikesLabel = new Label
            {
                Text = "37 Likes",
                FontSize = 13,
                TextColor = Color.Blue
            };

            CommentsLabel= new Label
            {
                Text = "12 Comments",
                FontSize = 13,
                TextColor = Color.Blue
            };

            SeenbyLabel = new Label
            {
                Text = "64 Views",
                FontSize = 13,
                TextColor = Color.Blue
            };

            BaseStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    LikesLabel,
                    CommentsLabel,
                    SeenbyLabel
                },
                Spacing = 10
            };

            Content = BaseStackLayout;

        }

        public Label LikesLabel { get; set; }

        public Label CommentsLabel { get; set; }

        public Label SeenbyLabel { get; set; }

        public StackLayout BaseStackLayout { get; set; }


    }
}
