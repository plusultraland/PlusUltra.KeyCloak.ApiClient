using System.Threading.Tasks;
using PlusUltra.KeyCloak.ApiClient.Entities;
using Refit;

namespace PlusUltra.KeyCloak.ApiClient
{
    public interface IKeyCloakUsersClient
    {
        [Get("/users/{id}")]
        [Headers("Authorization: Bearer")]
        Task<User> GetUser(string id);
    }
}