using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PlusUltra.KeyCloak.ApiClient.ViewModels;

namespace PlusUltra.KeyCloak.ApiClient.Handlers
{
    public class AuthenticationHeaderHandler : DelegatingHandler
    {
        public AuthenticationHeaderHandler(IKeyCloakAuthClient authClient, IOptions<KeyCloakSettings> settings)
        {
            this.authClient = authClient;
            this.settings = settings.Value;
        }

        private readonly IKeyCloakAuthClient authClient;
        private readonly KeyCloakSettings settings;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var form = new LoginForm
            {
                client_id = settings.ClientId,
                client_secret= settings.ClientSecret,
            };

            //Obter o token
            var token = await authClient.LoginAsync(form);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}