using System;
using Newtonsoft.Json;

namespace PlusUltra.KeyCloak.ApiClient.ViewModels
{
    public class User
    {
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "email")] public string Email { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "enabled")]
        public bool UserEnabled { get; set; } = true;
    }
}