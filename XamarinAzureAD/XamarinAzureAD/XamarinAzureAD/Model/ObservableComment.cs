using XLabs.Data;

namespace XamarinAzureAD.Model
{
    public class ObservableComment : ObservableObject
    {
        private ObservableUser _author;
        private string _comment;
        private string _id;

        public string Id
        {
            get { return _id ?? (_id = "NO ID"); }
            set { SetProperty(ref _id, value); }
        }

        public ObservableUser Author
        {
            get
            {
                return _author ?? (_author = new ObservableUser
                {
                    DisplayName = "NOT AUTHOR SET"
                });
            }
            set { SetProperty(ref _author, value); }
        }

        public string Comment
        {
            get { return _comment ?? (_comment = "NO COMMENT SET"); }
            set { SetProperty(ref _comment, value); }
        }
    }
}