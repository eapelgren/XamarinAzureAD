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

        private String testLogin = "test5@xlentxmstest.onmicrosoft.com";
        private String testPassword = "ThePasssword6";

        private AuthenticationContext authContext = null;

        public async Task<AuthenticationResult> LoginAdTask(string username, string password)
        {
                var ac = new AuthenticationContext("https://login.windows.net/63efea19-e312-4fa0-9d88-f5586cdcf083", null);
                var user = new UserCredential(testLogin, testPassword);
                var authResult = await ac.AcquireTokenAsync(_resource2, _clientId, user);
            
            return authResult;

        }

        public ObservableCollection<User> GetUsersTask()
        {
            throw new NotImplementedException();
        }
    }
}
