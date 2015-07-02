using System;
using System.Collections.Generic;
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
            var client = new HttpClient();

            JObject jResult;
         
                var responsMessage = await client.GetAsync(
                    String.Format(
                        "https://microsoft-apiapp98fa1f47749147b6bde310c5721cc7be.azurewebsites.net/api/Login/GetByUsernamePassword?username={0}&password={1}",
                        username, password));

           string boole = await responsMessage.Content.ReadAsStringAsync();
       
            if(boole == "true")
                return new XlentAuthResult()
                {
                    RefreshToken = "No Token at this Time",
                    IdToken = "No Token at this Time",
                    AccessToken = "No Token at this Time"
                };
            
            
            throw new Exception("Unkown error in loginadtask");
        }

        public Task<XlentAuthResult> LoginAdTaskAsync(string token)
        {
            throw new NotImplementedException();
        }

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