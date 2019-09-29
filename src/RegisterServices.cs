using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;

namespace PlusUltra.KeyCloak.ApiClient
{
    public static class RegisterServices
    {
        public static IServiceCollection AddKeyCloakApiClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KeyCloakSettings>(configuration.GetSection(nameof(KeyCloakSettings)));
            var configs = services.BuildServiceProvider().GetRequiredService<IOptions<KeyCloakSettings>>().Value;

            services.AddRefitClient<IKeyCloakUsersClient>()
                .ConfigureHttpClient(c => c.BaseAddress = configs.AdminUri);

            return services;
        }
    }
}