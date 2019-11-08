using System;
using Xunit;
using System.Threading.Tasks;
using Shouldly;
using PlusUltra.KeyCloak.ApiClient.ViewModels;
using PlusUltra.Testing;

namespace PlusUltra.KeyCloak.ApiClient.Tests
{
    public class TokenTest : TestHost<Startup>
    {
        public TokenTest()
        {
            authClient = GetService<IKeyCloakAuthClient>();
        }

        private readonly IKeyCloakAuthClient authClient;


        [Fact]
        public async Task Token_Should_Be_Successfuly()
        {
            //Arrange
            var form = new LoginForm
            {
                client_id = "admin-cli",
                client_secret= "d47aee3b-aad6-4073-be38-fbcc8c525f91"
            };

            //Act
            var token = await authClient.LoginAsync(form);

            //Assert
            token.ShouldNotBeNull();
        }
    }
}
