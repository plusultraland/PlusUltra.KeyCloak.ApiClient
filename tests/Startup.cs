using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PlusUltra.KeyCloak.ApiClient.Tests
{
    public class Startup : TestStartup
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddKeyCloakApiClients(configuration);
        }
    }
}