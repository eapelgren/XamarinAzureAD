using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLabs.Data;

namespace XamarinAzureAD.Model
{
    public class XlentAuthResult : ObservableObject
    {
        private string _accessToken;

        public string AccessToken
        {

            get { return _accessToken ?? (_accessToken = "No Token Available"); }
            set { SetProperty(ref _accessToken, value); }
        }
		
        private string _refreshToken;

        public string RefreshToken
        {

            get
            {
                return _refreshToken ?? (_refreshToken = "NoToken");
            }
            set { SetProperty(ref _refreshToken, value); }
        }

        private string _idToken;

        public string IdToken
        {
            get { return _idToken ?? (_idToken = "No Id Token set"); }
            set { SetProperty(ref _idToken, value); }
        }


		

		




		

		



		

		



		

		

    }
}
