using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinAzureAD.Model;
using XLabs.Ioc;

namespace XamarinAzureAD.Services
{
    public class ReadNewsProvider
    {
        public async Task PostReadNews(ReadNewsPCLModel readNews)
        {
            var client = new HttpClient();

            var stringContent = new StringContent(JsonConvert.SerializeObject(readNews));

            var request = new HttpRequestMessage(HttpMethod.Post,
                "https://microsoft-apiapp98fa1f47749147b6bde310c5721cc7be.azurewebsites.net/api/SaveReadNewsData/");
            request.Content = stringContent;

            var auth = Resolver.Resolve<IHttpHeaderAuthenticator>();
            HttpRequestMessage authenticatedRequest = auth.AuthenticateRequestMessage(request);

            await client.PostAsync(request.RequestUri, request.Content);
        }
    }
}
