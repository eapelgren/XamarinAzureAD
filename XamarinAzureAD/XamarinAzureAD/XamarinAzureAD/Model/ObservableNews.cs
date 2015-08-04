using System;
using XLabs.Data;

namespace XamarinAzureAD.Model
{
    public class ObservableNews : ObservableObject
    {
        private ObservableUser _authorUser;
        private string _datePosted;
        private string _description;
        private string _header;
        private string _id;
        private Uri _pictureUri;

        public new string Id
        {
            get { return _id ?? (_id = ""); }
            set { SetProperty(ref _id, value); }
        }

        public string Description
        {
            get { return _description ?? (_description = ""); }
            set { SetProperty(ref _description, value); }
        }

        public string Header
        {
            get { return _header ?? (_header = ""); }
            set { SetProperty(ref _header, value); }
        }

        public Uri PictureUri
        {
            get
            {
                return _pictureUri ??
                       (_pictureUri =
                           new Uri("http://ozarktech.com/wp-content/uploads/2014/05/image-not-available-grid.jpg"));
            }
            set { SetProperty(ref _pictureUri, value); }
        }

        public string DatePosted
        {
            get { return _datePosted; }
            set { SetProperty(ref _datePosted, value); }
        }

        public ObservableUser AuthorObservableUser
        {
            get { return _authorUser ?? (_authorUser = new ObservableUser()); }
            set { SetProperty(ref _authorUser, value); }
        }
    }
}