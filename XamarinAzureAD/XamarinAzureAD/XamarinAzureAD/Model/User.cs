using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinAzureAD.Model
{
    public class User
    {
        public string displayName { get; set; }
        public string userPrincipalName { get; set; }
        public string givenName { get; set; }
        public string surname { get; set; }
        public string location { get; set; }
        public string telephoneNumber { get; set; }
        public string error { get; set; }
        
        public Image image { get; set; }
    }
}
