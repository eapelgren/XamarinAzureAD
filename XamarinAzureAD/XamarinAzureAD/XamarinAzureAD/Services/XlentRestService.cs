using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.Services
{
    public class XlentRestService : IAzureAdService
    {

        public Task<LoginAuthRespons> LoginAdTask(string username, string password)
        {
            return null;
        }

        
        
        public async Task<ObservableCollection<User>> GetUsersTask()
        {

            const string request = "https://microsoft-apiapp745d3ca9013d4894bebef4e0a6f85f8e.azurewebsites.net/api/Users";
            ObservableCollection<User> list;
            try
            {
                HttpClient client = new HttpClient();
                
                var serializer = new Newtonsoft.Json.s

                HttpResponseMessage response = await client.PostAsync(request,)
                var content = await response.Content.ReadAsStringAsync();
                var obj = (JArray)
                    JsonConvert.DeserializeObject(content);

                list = JsonConvert.DeserializeObject<ObservableCollection<User>>(content);  
            }
            catch (Exception ee)
            {
                Debug.WriteLine("ERROR IN AZURE API: " + ee.Message);
                throw;
            }
            return list;
        }
     
        [JsonObject]
        public class LoginAuthRespons
        {
            public Boolean LoggedIn;
            public Exception Exception;
        }

        [JsonObject]
        public class LoginAuthRequest
        {
            public string Token;
        }
    }

}

