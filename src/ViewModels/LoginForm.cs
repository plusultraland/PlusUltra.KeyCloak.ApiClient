namespace PlusUltra.KeyCloak.ApiClient.ViewModels
{
    public class LoginForm
    {
        public string grant_type { get; set; } = "client_credentials";
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }
}