using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
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
                return _pictureUri ?? (_pictureUri = new Uri("http://ozarktech.com/wp-content/uploads/2014/05/image-not-available-grid.jpg"));
            }
            set { SetProperty(ref _pictureUri, value); }
        }

}
}
