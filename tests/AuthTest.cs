using System;
using System.Threading.Tasks;
using PlusUltra.KeyCloak.ApiClient.ViewModels;
using PlusUltra.Testing;
using Shouldly;
using Xunit;

namespace PlusUltra.KeyCloak.ApiClient.Tests
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
        
        [Fact]
        public async Task Create_User_Should_Be_Succesfuly()
        {
            //Arrange
            var identifier = Guid.NewGuid().ToString("N");
            
            var user = new User
            {
                UserName = $"cadu-{identifier:N}",
                FirstName = "Carlos Eduardo",
                LastName = "Moreia Santos",
                Email = $"{identifier}@gmail.com",
                UserEnabled = true
            };

            //Act
            var task =  usersClient.PostUserAsync(user);
            await task;

            //Assert
            task.IsCompletedSuccessfully.ShouldBeTrue();
        }
    }
}