using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PlusUltra.ApiClient;
using PlusUltra.KeyCloak.ApiClient.Handlers;
using Refit;

namespace PlusUltra.KeyCloak.ApiClient
{
    public static class RegisterServices
    {
        public static IHttpClientBuilder AddKeyCloakApiClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KeyCloakSettings>(configuration.GetSection(nameof(KeyCloakSettings)));
            var configs = services.BuildServiceProvider().GetRequiredService<IOptions<KeyCloakSettings>>().Value;
            
            services.AddTransient<AuthenticationHeaderHandler>();

            services.AddApiClient<IKeyCloakAuthClient>(c => c.BaseAddress = configs.TokenUri);

            return services.AddApiClient<IKeyCloakUsersClient>(c => c.BaseAddress = configs.AdminUri)
                        .AddHttpMessageHandler<AuthenticationHeaderHandler>();
        }
    }
}