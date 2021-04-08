using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ColmenApp.Models
{
    public class Customer
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "rfc", NullValueHandling = NullValueHandling.Ignore)]
        public string Rfc { get; set; }

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "contact_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactName { get; set; }

        [JsonProperty(PropertyName = "contact_number", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactNumber { get; set; }

        [JsonProperty(PropertyName = "created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "deleted_at", NullValueHandling = NullValueHandling.Ignore)]
        public object DeletedAt { get; set; }
    }
}
