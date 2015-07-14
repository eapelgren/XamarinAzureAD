using System.Net.Http;
using System.Threading.Tasks;
using DTOModel.Model;

namespace DTOModel.Providers.Interfaces
{
    public interface IAuthenticationProvider
    {
        Task<IAuthenticationDTO> GetTokensAsyncTask(string username, string password);

        Task<IAuthenticationDTO> GetTokensAsyncTask(string refreshToken);

        Task<HttpRequestMessage> AddBearerToRequestMessageAsyncTask(HttpRequestMessage message);
    }
}