using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using XamarinAzureAD.Model;
using XamarinAzureAD.RestServices.SipEntities.Models;

namespace XamarinAzureAD.Services
{
    public interface IAzureAdService
    {
        LoginAuthResponse LoginAdTask(string username, string password);

        LoginAuthResponse LoginAdTask(string token);

        ObservableCollection<User> GetUsersTask();


    }
}
