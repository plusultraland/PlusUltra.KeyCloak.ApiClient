using System.Threading.Tasks;
using PlusUltra.KeyCloak.ApiClient.ViewModels;
using Refit;

namespace PlusUltra.KeyCloak.ApiClient
{
    public interface IKeyCloakUsersClient
    {
        [Get("/users/{id}")]
        Task<User> GetUserAsync(string id);
    }
}