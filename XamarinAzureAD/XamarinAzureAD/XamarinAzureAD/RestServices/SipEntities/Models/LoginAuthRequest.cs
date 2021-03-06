// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace MobileApi.RestServices.SipEntities.Models
{
    public partial class LoginAuthRequest
    {
        private string _token;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Token
        {
            get { return this._token; }
            set { this._token = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the LoginAuthRequest class.
        /// </summary>
        public LoginAuthRequest()
        {
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type LoginAuthRequest
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.Token != null)
            {
                outputObject["Token"] = this.Token;
            }
            return outputObject;
        }
    }
}
