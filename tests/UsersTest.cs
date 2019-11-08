using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlusUltra.KeyCloak.ApiClient.Requests;
using PlusUltra.Testing;
using Shouldly;
using Xunit;

namespace PlusUltra.KeyCloak.ApiClient.Tests
{
    public class UsersTest : TestHost<Startup>
    {
        public UsersTest()
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

            var user = new UserRequest
            {
                Username = $"cadu-{identifier:N}",
                FirstName = "Carlos Eduardo",
                LastName = "Moreia Santos",
                Email = $"{identifier}@gmail.com",
                Enabled = true,
                RequiredActions = new List<string> { "terms_and_conditions" },
                Credentials = new List<UserCredentials>{
                    new UserCredentials{
                        Type ="password",
                        Value= $"{identifier:N}"
                    }
                }
            };

            //Act
            var task = usersClient.PostAsync(user);
            await task;

            //Assert
            task.IsCompletedSuccessfully.ShouldBeTrue();
        }
    }
}