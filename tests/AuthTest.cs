using System.Threading.Tasks;
using PlusUltra.KeyCloak.ApiClient;
using PlusUltra.KeyCloak.ApiClient.Tests;
using Shouldly;
using Xunit;

namespace tests
{
    public class AuthTest : TestHost<Startup>
    {
        public AuthTest()
        {
            this.usersClient = GetService<IKeyCloakUsersClient>();
        }

        private readonly IKeyCloakUsersClient usersClient;

        [Fact]
        public async Task Find_User_Should_Be_Succesfuly()
        {
            //Arrange
            var userId = "b70936be-ceb7-40e3-b082-1ebc89910ac1";

            //Act
            var data = await usersClient.GetUserAsync(userId);

            //Assert
            data.ShouldNotBeNull();
            data.UserName.ShouldBe("alefcarlos");
        }
    }
}