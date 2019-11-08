using System;
using Newtonsoft.Json;

namespace PlusUltra.KeyCloak.ApiClient.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool UserEnabled { get; set; }
    }
}