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
    public interface IAzureAdService
    {
        Task<XlentRestService.LoginAuthRespons> LoginAdTask(string username, string password);

        Task<XlentRestService.LoginAuthRespons> LoginAdTask(string token);

        Task<ObservableCollection<User>> GetUsersTask();


    }
}
