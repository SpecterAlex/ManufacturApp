using Newtonsoft.Json;

namespace ColmenApp.Models.Responses
{
    public class LoginResponse
    {
        [JsonProperty(PropertyName = "user", NullValueHandling = NullValueHandling.Ignore)]
        public User User { get; set; }
        
        [JsonProperty(PropertyName = "access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; }
        
        [JsonProperty(PropertyName = "token_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiresAt { get; set; }
    }
}
