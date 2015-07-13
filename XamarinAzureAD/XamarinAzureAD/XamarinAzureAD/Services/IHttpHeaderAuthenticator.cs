using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAzureAD.Services
{
    public interface IHttpHeaderAuthenticator
    {
        //AC WITH TENANT ID
        //AuthenticationContext ac = new AuthenticationContext("https://login.windows.net/d020f655-3b3b-4c7e-bb9a-97466a58e617", false);


        //var _nativeClientId = "a68b3653-b125-46a6-9715-afd741873ad5";
        //var _internalClientId = "7342a457-a4b1-4bdc-8dba-e51462f45c6a";

        HttpRequestMessage AuthenticateRequestMessage(HttpRequestMessage message);
    }
}
