using System;
using System.Net.Http;
using System.Threading.Tasks;
using DTOModel.Model;
using DTOModel.Providers.Interfaces;

namespace DTOModel.Providers.Implementations
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        public Task<IAuthenticationDTO> GetTokensAsyncTask(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IAuthenticationDTO> GetTokensAsyncTask(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<HttpRequestMessage> AddBearerToRequestMessageAsyncTask(HttpRequestMessage message)
        {
            throw new NotImplementedException();
        }
    }
}