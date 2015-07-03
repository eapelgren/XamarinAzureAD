using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.Services
{
    public class NewsProvider : INewsProvider
    {
        public async Task<ObservableCollection<ObservableNews>> GetNewsTaskAsync(string username, string password)
        {
            //AC WITH TENANT ID
            //AuthenticationContext ac = new AuthenticationContext("https://login.windows.net/d020f655-3b3b-4c7e-bb9a-97466a58e617", false);


            //var _nativeClientId = "a68b3653-b125-46a6-9715-afd741873ad5";
            //var _internalClientId = "7342a457-a4b1-4bdc-8dba-e51462f45c6a";
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(
              HttpMethod.Get, "https://microsoft-apiapp98fa1f47749147b6bde310c5721cc7be.azurewebsites.net/api/News/GetNews/5");

            HttpResponseMessage response = await client.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<ObservableCollection<ObservableNews>>(responseString);
            return obj;
        }
    }
}
