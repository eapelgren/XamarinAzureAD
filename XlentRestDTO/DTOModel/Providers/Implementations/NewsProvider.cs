using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using DTOModel.Model;
using DTOModel.Providers.Interfaces;
using Newtonsoft.Json;

namespace DTOModel.Providers.Implementations
{
    public class NewsProvider : INewsProvider
    {
        private IAuthenticationProvider authProvider;

        public NewsProvider(IAuthenticationProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        public async Task<IEnumerable<INewsDTO>> GetNewsAsyncTask()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://microsoft-apiapp98fa1f47749147b6bde310c5721cc7be.azurewebsites.net/api/News/GetNews/");

            var authenticatedRequest = await authProvider.AddBearerToRequestMessageAsyncTask(request);

            HttpResponseMessage response = await client.SendAsync(authenticatedRequest);
            string responseString = await response.Content.ReadAsStringAsync();


            var collection = JsonConvert.DeserializeObject<IEnumerable<INewsDTO>>(responseString);
            return collection;
        }

        public async Task<IEnumerable<INewsDTO>> GetNewsAsyncTask(string id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://microsoft-apiapp98fa1f47749147b6bde310c5721cc7be.azurewebsites.net/api/News/GetNews/");
            
            var authenticatedRequest = await authProvider.AddBearerToRequestMessageAsyncTask(request);
            HttpResponseMessage response = await client.SendAsync(authenticatedRequest);
            string responseString = await response.Content.ReadAsStringAsync();
            var collection = JsonConvert.DeserializeObject<IEnumerable<INewsDTO>>(responseString);
            return collection;
        }

        public Task<INewsDTO> PostNewsAsyncTask(INewsDTO news)
        {
            throw new NotImplementedException();
        }
    }
}