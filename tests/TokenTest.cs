using System;
using Xunit;
using System.Threading.Tasks;
using Shouldly;
using PlusUltra.KeyCloak.ApiClient.ViewModels;

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
                grant_type = "password",
                username = "admin",
                password ="admin",
                client_id = "admin-cli"
            };

            //Act
            var token = await authClient.LoginAsync(form);

            //Assert
            token.ShouldNotBeNull();
        }
    }
}
