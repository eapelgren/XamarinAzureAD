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
    public class AuthenticationProvider : IAuthenticationProvider
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


    }
}