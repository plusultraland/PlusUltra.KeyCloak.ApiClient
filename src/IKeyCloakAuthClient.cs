using System.Threading.Tasks;
using PlusUltra.KeyCloak.ApiClient.ViewModels;
using Refit;

namespace PlusUltra.KeyCloak.ApiClient
{
    public interface IKeyCloakAuthClient
    {
        [Post("/protocol/openid-connect/token")]
        Task<Token> LoginAsync([Body(BodySerializationMethod.UrlEncoded)]LoginForm request);
    }
}