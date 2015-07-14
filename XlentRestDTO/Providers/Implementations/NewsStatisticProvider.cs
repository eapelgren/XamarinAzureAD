using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using DTOModel.Model;
using DTOModel.Providers.Interfaces;
using Newtonsoft.Json;

namespace DTOModel.Providers.Implementations
{
    public class NewsStatisticProvider : INewsStatisticProvider
    {
        private IAuthenticationProvider _authenticationProvicer;

        public NewsStatisticProvider(IAuthenticationProvider authenticationProvider)
        {
            this._authenticationProvicer = authenticationProvider;
        }
        
        public async Task PostNewsStatisticAsyncTask(INewsStatisticDTO news)
        {

         HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(
              HttpMethod.Post, "https://microsoft-apiapp98fa1f47749147b6bde310c5721cc7be.azurewebsites.net/api/SaveReadNewsData/");
            client.PostAsync(
                "https://microsoft-apiapp98fa1f47749147b6bde310c5721cc7be.azurewebsites.net/api/SaveReadNewsData/",
                new StringContent(JsonConvert.SerializeObject(news)));

            var authenticatedRequest = await  _authenticationProvicer.AddBearerToRequestMessageAsyncTask(request);
   
            HttpResponseMessage response = await client.SendAsync(authenticatedRequest);

        }
    }
}
