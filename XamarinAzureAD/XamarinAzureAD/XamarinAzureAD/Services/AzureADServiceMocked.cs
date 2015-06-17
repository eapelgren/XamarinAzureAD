using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.Services
{
    public class AzureADServiceMocked : IAzureAdService
    {
        public async Task<AzureAdService.LoginAuthRespons> LoginAdTask(string username, string password)
        {
            return
            new AzureAdService.LoginAuthRespons()
            {
                LoggedIn = true
            };
        }

        public async Task<ObservableCollection<User>> GetUsersTask()
        {
                var collection = new ObservableCollection<User>
                {
                    new User()
                    {
                        //DisplayName = "Emil Apelgren",
                        GivenName = "Emil",
                        SurName = "Apelgren",
                        //Image = new Image()
                        //{
                        //    Source = "http://i.ytimg.com/vi/_Dv7FKvUPBQ/hqdefault.jpg"
                        //},
                        //Location = "Xlent HQ",

                    },
                    new User()
                    {
                        //DisplayName = "Fredrik Tonn",
                        GivenName = "Fredrik",
                        SurName = "Tonn",
                        //Image = new Image()
                        //{
                        //    Source = "https://media.licdn.com/mpr/mpr/shrinknp_400_400/p/7/000/24a/0d9/13e8e14.jpg"
                        //},
                        //Location = "Xlent HQ"

                    },
                    new User()
                    {
                        //DisplayName = "Åsa Nisse",
                        GivenName = "Åsa",
                        SurName = "Nisse",
                        //Image = new Image()
                        //{
                        //    Source =
                        //        "http://www.mallorcanyheter.com/wp-content/uploads/2013/11/John_Elfstrom-Asa-Nisse-2-350x250.jpg"
                        //},
                        Location = "AstridLand",
                    }
                };
                return collection;
        }
    }
}
