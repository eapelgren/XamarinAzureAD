using XLabs.Data;

namespace XamarinAzureAD.Model
{
    public class XlentAuthResult : ObservableObject
    {
        private string _accessToken;
        private string _idToken;

        private string _refreshToken;

        public string AccessToken
        {
            get { return _accessToken ?? (_accessToken = "No Token Available"); }
            set { SetProperty(ref _accessToken, value); }
        }

        public string RefreshToken
        {
            get { return _refreshToken ?? (_refreshToken = "NoToken"); }
            set { SetProperty(ref _refreshToken, value); }
        }

        public string IdToken
        {
            get { return _idToken ?? (_idToken = "No Id Token set"); }
            set { SetProperty(ref _idToken, value); }
        }
    }
}