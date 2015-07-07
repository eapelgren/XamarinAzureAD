using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAzureAD.Services
{
    public class HttpHeaderProviderMocked : IHttpHeaderAuthenticator
    {
        public HttpRequestMessage AuthenticateRequestMessage(HttpRequestMessage message)
        {
            Debug.WriteLine("HTTP HEADER AUTHENTICATOR IS MOCKED");
            return message;
        }
    }
}
