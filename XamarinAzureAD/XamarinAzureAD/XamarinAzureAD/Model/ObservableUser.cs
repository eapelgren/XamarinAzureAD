using System;
using XLabs.Data;

namespace XamarinAzureAD.Model
{
    public class ObservableUser : ObservableObject
    {
        private Uri _authorImageUri;
        private string _displayName;
        private string _givenName;
        private string _id;
        private string _location;
        private string _surname;
        private string _telephoneNumber;

        public Uri AuthorImageUri

        {
            get
            {
                return _authorImageUri ??
                       (_authorImageUri =
                           new Uri("http://seniorcapital.eu/wp-content/themes/patus/images/no-image-half-landscape.png"));
            }
            set { SetProperty(ref _authorImageUri, value); }
        }

        public string DisplayName
        {
            get { return _displayName ?? (_displayName = ""); }
            set { SetProperty(ref _displayName, value); }
        }

        public string GivenName
        {
            get { return _givenName ?? (_givenName = ""); }
            set { SetProperty(ref _givenName, value); }
        }

        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string Location
        {
            get { return _location ?? (_location = ""); }
            set { SetProperty(ref _location, value); }
        }

        public string SurName
        {
            get { return _surname ?? (_surname = ""); }
            set { SetProperty(ref _surname, value); }
        }

        public string TelephoneNumber
        {
            get { return _telephoneNumber ?? (_telephoneNumber = "Not Listed"); }
            set { SetProperty(ref _telephoneNumber, value); }
        }
    }
}