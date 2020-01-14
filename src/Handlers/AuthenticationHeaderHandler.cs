using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using PlusUltra.DistributedCache;
using PlusUltra.KeyCloak.ApiClient.Requests;
using PlusUltra.KeyCloak.ApiClient.Responses;

namespace PlusUltra.KeyCloak.ApiClient.Handlers
{
    public class AuthenticationHeaderHandler : DelegatingHandler
    {
        public AuthenticationHeaderHandler(IKeyCloakAuthClient authClient, IOptions<KeyCloakSettings> settings, IDistributedCache cache)
        {
            this.authClient = authClient;
            this.settings = settings.Value;
            this.cache = cache;
        }

        private readonly IKeyCloakAuthClient authClient;
        private readonly KeyCloakSettings settings;
        private readonly IDistributedCache cache;

        const string CACHE_KEY = "keycloak_key";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var form = new AuthRequest
            {
                client_id = settings.ClientId,
                client_secret = settings.ClientSecret,
            };

            //Tentar obter token do cache, senão realizar request
            var token = await cache.GetObjectAsync<TokenResponse>(CACHE_KEY);

            if (token is null)
            {
                //fazer request  do token e salvar no cache
                token = await authClient.LoginAsync(form);
                var ts = token.expires_in <= 60 * 5 ? TimeSpan.FromSeconds(token.expires_in) : TimeSpan.FromSeconds(token.expires_in - 60 * 5);
                await cache.SetObjectAsync(CACHE_KEY, token, ts);
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}