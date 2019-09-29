using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PlusUltra.KeyCloak.ApiClient.Handlers;
using Refit;

namespace PlusUltra.KeyCloak.ApiClient
{
    public static class RegisterServices
    {
        public static IServiceCollection AddKeyCloakApiClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KeyCloakSettings>(configuration.GetSection(nameof(KeyCloakSettings)));
            var configs = services.BuildServiceProvider().GetRequiredService<IOptions<KeyCloakSettings>>().Value;

            services.AddTransient<AuthenticationHeaderHandler>();

            services.AddRefitClient<IKeyCloakUsersClient>()
                .ConfigureHttpClient(c => c.BaseAddress = configs.AdminUri)
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();

            services.AddRefitClient<IKeyCloakAuthClient>()
                .ConfigureHttpClient(c => c.BaseAddress = configs.TokenUri);

            return services;
        }
    }
}