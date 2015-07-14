using Xamarin.Forms;

namespace XamarinAzureAD.Controlls
{
    public class TestCell : ViewCell
    {
        public TestCell()
        {
            var stackLayout = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "Test"
                    }
                }
            };

            View = stackLayout;
        }
    }
}