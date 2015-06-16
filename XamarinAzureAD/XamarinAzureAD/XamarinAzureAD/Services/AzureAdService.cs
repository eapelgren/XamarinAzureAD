using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.Services
{
    public class AzureAdService : IAzureAdService
    {
        private const string _authority = "https://login.windows.net/63efea19-e312-4fa0-9d88-f5586cdcf083";

        private static string _resource2 = "https://graph.windows.net/";
        private static string _clientId = "35e1d0e9-ff0c-4367-b236-07adf3ca5110";
        private static string _tenantId = "63efea19-e312-4fa0-9d88-f5586cdcf083";

        //WORKING IS 7
        private String testLogin = "test6@xlentxmstest.onmicrosoft.com";
        private String testPassword = "newPassword1";

        private AuthenticationResult authenticationResult = null;

        public async Task<AzureLoginRespons> LoginAdTask(string username, string password)
        {
                var ac = new AuthenticationContext(_authority, false);
                var user = new UserCredential(testLogin, testPassword);
                var task = ac.AcquireTokenAsync(_resource2, _clientId, user).ContinueWith(
                    task1 =>
                    {
                        if (!task1.IsFaulted)
                        {
                        authenticationResult = task1.Result;
                            return new AzureLoginRespons
                            {
                                LoggedIn = true
                            };
                        }
                        return new AzureLoginRespons
                        {
                            LoggedIn = false,
                            Exception = task1.Exception
                        };
                    });

            return await task;
        }

        public ObservableCollection<User> GetUsersTask()
        {
            List<User> result = new List<User>();
            if (authenticationResult != null)
            {
                
            }
        
        }

       
        public class AzureLoginRespons
        {
            public Boolean LoggedIn;
            public Exception Exception;
        }
    }
}
