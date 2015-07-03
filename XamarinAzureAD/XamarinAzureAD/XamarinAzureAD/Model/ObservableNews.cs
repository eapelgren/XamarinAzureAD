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

        private Uri _authorPicUri;

        public Uri AuthorPicUri
        {
            get
            {
                return _authorPicUri ??
                       (_authorPicUri =
                           new Uri(
                               "http://m.c.lnkd.licdn.com/mpr/pub/image-Z3Vejnj3qgjZz0NQvfjLVRjU_HtXiw8YNa5LaS13b5bBjC3wU3VLar4gbVsEjVaHNr1/fredrik-tonn.jpg"));
            }
            set { SetProperty(ref _authorPicUri, value); }
        }

        private string _authorName;

        public string AuthorName
        {
            get
            {
                return _authorName ?? (_authorName = "Fredrik Tonn");
            }
            set { SetProperty(ref _authorName, value); }
        }

        private string _datePosted;

        public string DatePosted
        {

            get
            {
                return _datePosted ?? (_datePosted = "Yesterday at 08:30");
            }
            set { SetProperty(ref _datePosted, value); }
        }


		

		



		

		

    }
}
