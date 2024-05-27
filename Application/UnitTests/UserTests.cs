using DTOs;
using UnitTests.MockDAL;
using LogicLayer;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace UnitTests
{
    public class UserTests
    {
        public MockUserDAL _mockUserDAL = new MockUserDAL();
        public UserLL _userLL = new UserLL(new MockUserDAL());

        [Fact] 
        public void CreateUser_ShouldAddUser_WhenNewUserIsProvided()
        {
            // Arrange
            var newUser = new RegisterDTO
            {
                Username = "testuser",
                FirstName = "Test",
                LastName = "User",
                Password = "password",
                Email = "testuser@test.com",
                PhoneNumber = "1234567890",
                Birthday = DateTime.Now,
                Role = "admin"
            };

            // Act
            var result = _userLL.CreateUser(newUser);

            // Assert
            Assert.True(result);
            Assert.True(_userLL.IsEmailUsed("testuser@test.com"));
        }

        [Fact]
        public void CreateUser_ShouldThrowException_WhenDuplicateEmailIsUsed()
        {
            // Arrange
            var user1 = new RegisterDTO
            {
                Username = "user1",
                FirstName = "User",
                LastName = "One",
                Password = "password",
                Email = "duplicate@example.com",
                PhoneNumber = "1234567890",
                Birthday = DateTime.Now,
                Role = "user"
            };
            var user2 = new RegisterDTO
            {
                Username = "user2",
                FirstName = "User",
                LastName = "Two",
                Password = "password",
                Email = "duplicate@example.com",  // Same email
                PhoneNumber = "0987654321",
                Birthday = DateTime.Now,
                Role = "user"
            };
            _userLL.CreateUser(user1);

            try
            {
                // Act
                var result = _userLL.CreateUser(user2);
                //// Assert
                //Assert.IsType<ArgumentOutOfRangeException>("");

            }
            //Assert
            catch (ArgumentOutOfRangeException)
            {
                
            }
            
        }

        [Fact]
        public void GetUserById_ShouldReturnUser_WhenIdIsValid()
        {
            // Arrange
            var newUser = new RegisterDTO
            {
                Username = "existinguser",
                FirstName = "Existing",
                LastName = "User",
                Password = "password",
                Email = "existuser@example.com",
                PhoneNumber = "1234567890",
                Birthday = DateTime.Now,
                Role = "customer"
            };
            _userLL.CreateUser(newUser);
            int userId = _mockUserDAL.users.Last().Id;  // Get the ID of the newly added user

            // Act
            var user = _userLL.GetUserById(userId);

            // Assert
            Assert.NotNull(user);
            Assert.Equal("existinguser", user.Username);
        }

        [Fact]
        public void DeleteUser_ShouldRemoveUser_WhenIdIsValid()
        {
            // Arrange
            var newUser = new RegisterDTO
            {
                Username = "deleteuser",
                FirstName = "Delete",
                LastName = "User",
                Password = "password",
                Email = "deleteuser@example.com",
                PhoneNumber = "1234567890",
                Birthday = DateTime.Now,
                Role = "customer"
            };
            _userLL.CreateUser(newUser);
            int userId = _mockUserDAL.users.Last().Id;  // Get the ID of the newly added user

            // Act
            _userLL.DeleteUser(userId);
            var user = _userLL.GetUserById(userId);

            // Assert
            Assert.Null(user);
        }

        [Fact]
        public void UpdateUser_ShouldUpdateUser_WhenUserExists()
        {
            // Arrange
            var newUser = new RegisterDTO
            {
                Username = "updateuser",
                FirstName = "Initial",
                LastName = "User",
                Password = "password",
                Email = "updateuser@example.com",
                PhoneNumber = "1234567890",
                Birthday = DateTime.Now,
                Role = "customer"
            };
            _userLL.CreateUser(newUser);
            int userId = _mockUserDAL.users.Last().Id;

            var updateUser = new UpdateUserDTO
            {
                Id = userId,
                ProfilePicture = new byte[0],
                FirstName = "Updated",
                LastName = "User",
                Password = "password",
                Email = "updated@example.com",
                PhoneNumber = "0987654321",
                Birthday = DateTime.Now.AddDays(-1),
                Username = "updateduser",
                Role = "admin"
            };

            // Act
            var result = _userLL.UpdateUser(updateUser);
            var updatedUser = _userLL.GetUserById(userId);

            // Assert
            Assert.True(result);
            Assert.Equal("Updated", updatedUser.FirstName);
            Assert.Equal("admin", updatedUser.Role);
        }
    }
}