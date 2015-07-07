using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.Services
{
    public interface IAuthenticationProvider
    {
        Task<XlentAuthResult> LoginAdTaskAsync(string username, string password);

        Task<XlentAuthResult> LoginAdTaskAsync(string refreshToken);
    }
}
