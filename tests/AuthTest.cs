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
            var userId = "2108b4c3-e7f3-4659-bcba-3da427cb841f";

            //Act
            var data = await usersClient.GetAsync(userId);

            //Assert
            data.ShouldNotBeNull();
            data.Email.ShouldBe("alef.carlos@gmail.com");
        }

        [Fact]
        public async Task Search_User_Should_Be_Succesfuly()
        {
            //Arrange
            var search = "alef.carlos@gmail.com";

            //Act
            var data = await usersClient.SearchAsync(search);

            //Assert
            data.ShouldNotBeEmpty();
        }
        
        [Fact]
        public async Task Create_User_Should_Be_Succesfuly()
        {
            //Arrange
            var identifier = Guid.NewGuid();
            
            var user = new User
            {
                UserName = $"cadu-{identifier:N}",
                FirstName = "Carlos Eduardo",
                LastName = "Moreia Santos",
                Email = $"{identifier}@gmail.com",
                UserEnabled = true
            };

            //Act
            var task =  usersClient.PostAsync(user);
            await task;

            //Assert
            task.IsCompletedSuccessfully.ShouldBeTrue();
        }
    }
}