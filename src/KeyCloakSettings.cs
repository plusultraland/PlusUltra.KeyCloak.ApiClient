using System;

namespace PlusUltra.KeyCloak.ApiClient
{
    public class KeyCloakSettings
    {
        public string Uri { get; set; }
        public string Realm { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public Uri TokenUri => new Uri($"{Uri}/auth/realms/{Realm}");
        public Uri AdminUri => new Uri($"{Uri}/auth/admin/realms/{Realm}");
    }
}
