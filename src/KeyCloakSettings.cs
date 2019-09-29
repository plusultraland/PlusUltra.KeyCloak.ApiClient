using System;

namespace PlusUltra.KeyCloak.ApiClient
{
    public class KeyCloakSettings
    {
        public string Uri { get; set; }
        public string Realm { get; set; }
        public string ClientId { get; set; }
        public string UserName { get; set; }    
        public string Password { get; set; }
        public Uri TokenUri => new Uri($"{Uri}/auth/realms/${Realm}/protocol/openid-connect/token");
        public Uri AdminUri => new Uri($"{Uri}/auth/admin/realms/${Realm}/");
    }
}
