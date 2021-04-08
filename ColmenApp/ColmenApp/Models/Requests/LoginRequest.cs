using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ColmenApp.Models.Requests
{
    public class LoginRequest
    {
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }
    }
}
