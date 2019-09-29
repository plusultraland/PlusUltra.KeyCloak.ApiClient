using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PlusUltra.KeyCloak.ApiClient.Tests
{
    public abstract class TestStartup
    {
        public abstract void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}