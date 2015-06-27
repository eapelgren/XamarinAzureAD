using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using XamarinAzureAD.RestServices.XlentRestService;
using XamarinAzureAD.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;
using AuthenticationResult = XamarinAzureAD.RestServices.XlentRestService.Models.AuthenticationResult;

namespace XamarinAzureAD.Handler
{
    public class LocalTokenHandler
    {
        public string GetRefreshToken()
        {
            try
            {
                byte[] byteToken = Resolver.Resolve<ISecureStorage>().Retrieve("refreshToken");
                if (byteToken != null)
                {
                    return Encoding.UTF8.GetString(byteToken, 0, byteToken.Count());
                }
            }
            catch (Exception ee)
            {
                throw new NoTokenException("No refreshToken found", ee);
            }

            return "Unknown refreshToken error";
        }

        public string GetAccessToken()
        {
            try
            {
                byte[] byteToken = Resolver.Resolve<ISecureStorage>().Retrieve("accessToken");
                if (byteToken != null)
                {
                    return Encoding.UTF8.GetString(byteToken, 0, byteToken.Count());
                }
            }
            catch (Exception ee)
            {
                throw new NoTokenException("No accessToken found", ee);
            }

            return "Unknown accessToken error";
        }

        public Task<AuthenticationResult> GetAuthContextAsync()
        {

            try
            {
                var task = new Task<AuthenticationResult>(() =>
                {
                    var result =
                        new XlentAzureRestService().LoginAdTaskAsync(GetRefreshToken());
                    return result;
                });
                return task;
            }
            catch (Exception ee)
            {

                throw new AuthInvalidException("Could not Authenticate with refreshToken", ee);
            
            }
        }
    }
}

public class NoTokenException : Exception
{
    public NoTokenException()
    {
    }

    public NoTokenException(string message) : base(message)
    {
    }

    public NoTokenException(string message, Exception inner) : base(message, inner)
    {
    }
}

public class AuthInvalidException : Exception
{
    //
    // For guidelines regarding the creation of new exception types, see
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    // and
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    //

    public AuthInvalidException()
    {
    }

    public AuthInvalidException(string message) : base(message)
    {
    }

    public AuthInvalidException(string message, Exception inner) : base(message, inner)
    {
    }
}
