using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XamarinAzureAD.Handler;
using XamarinAzureAD.Model;
using XLabs.Ioc;

namespace XamarinAzureAD.Services
{
    public class XlentAzureRestServicePCL : IAzureRestService
    {
        private const string _apiLink = "https://microsoft-apiappc1f91447b91f4dc3834cbde4fca6a49c.azurewebsites.net/:";

        public async Task<XlentAuthResult> LoginAdTaskAsync(string username, string password)
        {
            var client = new HttpClient(new NativeMessageHandler())
            {
            };

            JObject jResult;
            try
            {
                var responsMessage = await client.GetAsync(
                    String.Format(
                        "http://microsoft-apiappc1f91447b91f4dc3834cbde4fca6a49c.azurewebsites.net:443/api/Login/GetByUsernamePassword?username={0}&password={1}",
                        username, password));

                string content = await responsMessage.Content.ReadAsStringAsync();
                jResult = JObject.Parse(content);
            }
            catch (Exception)
            {
                Debug.WriteLine("Error Sending or Parsing");
                throw;
            }

            if (jResult["odata.error"] != null)
            {
                throw new Exception("ODATA ERROR" + (string) jResult["odata.error"]["message"]["value"]);
            }

            if (jResult["value"] == null)
            {
                throw new Exception("UNKOWN ERROR IN LoginAdTask");
            }

            foreach (JObject result in jResult["value"])
            {
                return new XlentAuthResult()
                {
                    RefreshToken = (string) result["RefreshToken"],
                    IdToken = (string) result["IdToken"]
                };
            }
            throw new Exception("Unkown error in loginadtask");
        }

        public Task<XlentAuthResult> LoginAdTaskAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<ObservableNews>> GetNewsTaskAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<ObservableUser>> GetUserTaskAsync()
        {
            throw new NotImplementedException();
        }
    }
}