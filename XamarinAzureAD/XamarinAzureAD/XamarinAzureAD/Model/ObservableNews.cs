using System;
using XLabs.Data;

namespace XamarinAzureAD.Model
{
    public class ObservableNews : ObservableObject
    {
        private string _description;

        public string Description
        {
            get { return _description ?? (_description = ""); }
            set { SetProperty(ref _description, value); }
        }

        private string _header;

        public string Header
        {
            get { return _header ?? (_header = ""); }
            set { SetProperty(ref _header, value); }
        }

        private Uri _pictureUri;

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

        private ObservableUser _authorUser;

        public ObservableUser AuthorUser
        {

            get
            {
                return _authorUser ?? (_authorUser = new ObservableUser()
                {
                    error = "No User Set"
                });
            }
            set { SetProperty(ref _authorUser, value); }
        }

        private DateTime _datePosted;

        public DateTime DatePosted
        {
            get { return _datePosted; }
            set { SetProperty(ref _datePosted, value); }
        }
    	

    }
}
