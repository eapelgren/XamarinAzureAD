using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json.Linq;
using XamarinAzureAD.Model;
using Newtonsoft.Json;
using XLabs.Ioc;

namespace XamarinAzureAD.Services
{
    public class AzureAdService : IAzureAdService
    {
        private const string _authority = "https://login.windows.net/63efea19-e312-4fa0-9d88-f5586cdcf083";

        private static string _resource2 = "https://graph.windows.net/";
        private static string _clientId = "35e1d0e9-ff0c-4367-b236-07adf3ca5110";
        private static string _tenantId = "63efea19-e312-4fa0-9d88-f5586cdcf083";

        //WORKING IS 7
        private String testLogin = "test7@xlentxmstest.onmicrosoft.com";
        private String testPassword = "newPassword1";

        private AuthenticationResult authenticationResult;
            
        public async Task<XlentRestService.LoginAuthRespons> LoginAdTask(string username, string password)
        {
                var ac = new AuthenticationContext(_authority, false);
                var user = new UserCredential(testLogin, testPassword);
                var task = ac.AcquireTokenAsync(_resource2, _clientId, user).ContinueWith(
                    task1 =>
                    {
                        if (!task1.IsFaulted)
                        {
                            authenticationResult = task1.Result;
                            return new XlentRestService.LoginAuthRespons
                            {
                                LoggedIn = true
                            };
                        }
                        return new XlentRestService.LoginAuthRespons
                        {
                            LoggedIn = false,
                            Exception = task1.Exception
                        };
                    });

            return await task;
        }

        public async Task<ObservableCollection<User>> GetUsersTask()
        {
            JObject jResult;
            var result = new ObservableCollection<User>();
            if (authenticationResult != null)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    string graphRequest = String.Format(CultureInfo.InvariantCulture, "{0}/{1}/users?api-version={2}&$filter=mailNickname eq '{3}'", _resource2, authenticationResult.TenantId, "1.5", "test");
                    HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, graphRequest);
                    httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);
                    HttpResponseMessage respons = await client.SendAsync(httpRequestMessage);

                    string content = await respons.Content.ReadAsStringAsync();
                    jResult = JObject.Parse(content);
                    
                }
                catch (Exception ee)
                {
                    result.Add(new User { error = ee.Message });
                    return result;
                }

                if (jResult["odata.error"] != null)
                {
                    result.Add(new User { error = (string)jResult["odata.error"]["message"]["value"] });
                    return result;
                }
                if (jResult["value"] == null)
                {
                    result.Add(new User { error = "Unknown Error." });
                    return result;
                }
                foreach (JObject results in jResult["value"])
                {
                    result.Add(new User
                    {
                        //DisplayName = (string)results["displayName"],
                        GivenName = (string)results["givenName"],
                        SurName = (string)results["surname"],
                        TelephoneNumber = (string)results["telephoneNumber"] == null ? "Not Listed." : (string)results["telephoneNumber"]
                    });
                }
               
            }
            return result;
        }
    }
}
