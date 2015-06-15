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
    class AzureAdService : IAzureAdService
    {
        private static string _authority = "https://login.windows.net/63efea19-e312-4fa0-9d88-f5586cdcf083";
        private static string _resource = "311a71cc-e848-46a1-bdf8-97ff7156d8e6";
        private static string _clientId = "869bb9a1-e9e1-46ca-930a-bd17c0a59b80";
        private static string _tenantId = "63efea19-e312-4fa0-9d88-f5586cdcf083";

        private String testLogin = "test6@xlentxmstest.onmicrosoft.com";
        private String testPassword = "ThePasssword6";


        public async Task<bool> LoginAdTask(string username, string password)
        {

            var authContext = new AuthenticationContext(_authority);
            var user = new UserCredential(testLogin, testPassword);
            var authResult = await authContext.AcquireTokenAsync(_resource, _clientId, user);

            return true;



        }

        public ObservableCollection<User> GetUsersTask()
        {
            throw new NotImplementedException();
        }
    }
}
