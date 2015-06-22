using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XamarinAzureAD.Model;
using XamarinAzureAD.RestServices.SipEntities;
using XamarinAzureAD.RestServices.SipEntities.Models;

namespace XamarinAzureAD.Services
{
    public class XlentRestService : IAzureAdService
    {

        public LoginAuthResponse LoginAdTask(string username, string password)
        {
            var loginController = new SipEntitiesClient().Login;
            var result = loginController.LoginUsernamePassword(username, password);
            return result;
        }

        public LoginAuthResponse LoginAdTask(string token)
        {
            throw new NotImplementedException();
        }


        public ObservableCollection<User> GetUsersTask()
        {
            throw new NotImplementedException();
        }


    }

}

