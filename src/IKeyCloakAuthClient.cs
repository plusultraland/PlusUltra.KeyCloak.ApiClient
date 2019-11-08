using System.Threading.Tasks;
using PlusUltra.KeyCloak.ApiClient.Requests;
using PlusUltra.KeyCloak.ApiClient.Responses;
using Refit;

namespace PlusUltra.KeyCloak.ApiClient
{
    public interface IKeyCloakAuthClient
    {
        [Post("/protocol/openid-connect/token")]
        Task<TokenResponse> LoginAsync([Body(BodySerializationMethod.UrlEncoded)]AuthRequest request);
    }
}