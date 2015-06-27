    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Data;

namespace XamarinAzureAD.Model
{
    public class ObservableUser : ObservableObject
    {

        private string _displayName;

        public string DisplayName
        {

            get { return _displayName ?? (_displayName = ""); }
            set { SetProperty(ref _displayName, value); }
        }

    
        private string _givenName;

        public string GivenName
        {

            get { return _givenName ?? (_givenName = ""); }
            set { SetProperty(ref _givenName, value); }
        }


        private string _surname;

        public string SurName
        {

            get { return _surname ?? (_surname = ""); }
            set { SetProperty(ref _surname, value); }
        }


        private string _location;

        public string Location
        {

            get
            {
                return _location ?? (_location = "");
            }
            set { SetProperty(ref _location, value); }
        }

        private string _telephoneNumber;

        public string TelephoneNumber
        {

            get
            {
                return _telephoneNumber ?? (_telephoneNumber = "Not Listed");
            }
            set { SetProperty(ref _telephoneNumber, value); }
        }

        private Image _image;

        public Image Image
        {

            get
            {
                return _image ?? (_image = new Image()
                {
                    Source = "http://seniorcapital.eu/wp-content/themes/patus/images/no-image-half-landscape.png"
                });
            }
            set { SetProperty(ref _image, value); }
        }
        
        public string error { get; set; }
    }
}
