using System.Collections.Generic;
using System.Threading.Tasks;
using PlusUltra.KeyCloak.ApiClient.ViewModels;
using Refit;

namespace PlusUltra.KeyCloak.ApiClient
{
    public interface IKeyCloakUsersClient
    {
        [Get("/users/{id}")]
        Task<User> GetAsync(string id);

        [Get("/users")]        
        Task<IEnumerable<User>> SearchAsync([Query]string search);

        [Post("/users")]
        Task PostAsync([Body] User user);
    }
}