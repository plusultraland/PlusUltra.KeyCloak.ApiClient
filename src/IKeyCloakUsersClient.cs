using System.Collections.Generic;
using System.Threading.Tasks;
using PlusUltra.KeyCloak.ApiClient.Requests;
using PlusUltra.KeyCloak.ApiClient.Responses;
using Refit;

namespace PlusUltra.KeyCloak.ApiClient
{
    public interface IKeyCloakUsersClient
    {
        [Get("/users/{id}")]
        Task<UserResponse> GetAsync(string id);

        [Get("/users")]        
        Task<IEnumerable<UserResponse>> SearchAsync([Query]string search);

        [Post("/users")]
        Task PostAsync([Body] UserRequest request);

        [Put("/users/{id}")]
        Task PutAsync(string id, [Body] UserRequest request);

        [Delete("/users/{id}")]
        Task DeleteAsync(string id);


        [Put("/users/{id}/send-verify-email")]
        Task SendVerifyEmail(string id);
    }
}