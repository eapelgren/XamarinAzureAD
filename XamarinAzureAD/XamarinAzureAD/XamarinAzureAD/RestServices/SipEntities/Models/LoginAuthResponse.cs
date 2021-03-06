// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace MobileApi.RestServices.SipEntities.Models
{
    public partial class LoginAuthResponse
    {
        private string _exception;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Exception
        {
            get { return this._exception; }
            set { this._exception = value; }
        }
        
        private bool? _loggedIn;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? LoggedIn
        {
            get { return this._loggedIn; }
            set { this._loggedIn = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the LoginAuthResponse class.
        /// </summary>
        public LoginAuthResponse()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken exceptionValue = inputObject["Exception"];
                if (exceptionValue != null && exceptionValue.Type != JTokenType.Null)
                {
                    this.Exception = exceptionValue.ToString(Newtonsoft.Json.Formatting.Indented);
                }
                JToken loggedInValue = inputObject["LoggedIn"];
                if (loggedInValue != null && loggedInValue.Type != JTokenType.Null)
                {
                    this.LoggedIn = ((bool)loggedInValue);
                }
            }
        }
    }
}
