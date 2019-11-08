using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlusUltra.KeyCloak.ApiClient.Requests
{
    public class UserRequest
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Enabled { get; set; }

        public List<string> RequiredActions { get; set; }
    }
}