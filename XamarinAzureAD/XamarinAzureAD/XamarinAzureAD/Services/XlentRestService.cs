using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.Services
{
    public class XlentRestService : IAzureAdService
    {
        public Task<AzureAdService.LoginAuthRespons> LoginAdTask(string username, string password)
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
                HttpResponseMessage response = await client.GetAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                var obj = (JArray)
                    Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                list = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<User>>(content);  
            }
            catch (Exception ee)
            {
                System.Diagnostics.Debug.WriteLine("ERROR IN AZURE API: " + ee.Message);
                throw;
            }
            return list;
        }

    }

}

