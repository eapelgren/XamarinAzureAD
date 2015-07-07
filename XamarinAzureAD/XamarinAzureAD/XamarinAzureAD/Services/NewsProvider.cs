using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinAzureAD.Model;
using XLabs.Ioc;

namespace XamarinAzureAD.Services
{
    public class NewsProvider : INewsProvider
    {
        public async Task<ObservableCollection<ObservableNews>> GetNewsTaskAsync(string username, string password)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(
              HttpMethod.Get, "https://microsoft-apiapp98fa1f47749147b6bde310c5721cc7be.azurewebsites.net/api/News/GetNews/");
            
            var auth = Resolver.Resolve<IHttpHeaderAuthenticator>();
            var authenticatedRequest = auth.AuthenticateRequestMessage(request);
            
            HttpResponseMessage response = await client.SendAsync(authenticatedRequest);
            string responseString = await response.Content.ReadAsStringAsync();


            var collection = JsonConvert.DeserializeObject<ObservableCollection<ObservableNews>>(responseString);
            return collection;
        }
    }
}
