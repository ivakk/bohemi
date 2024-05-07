using DTOs;

namespace UnitTests
{
    public class UserTests
    {
        private readonly MockUserDAL _mockUserDAL = new MockUserDAL();

        [Fact]
        public void CreateUserDAL_ShouldAddUser_WhenNewUserIsProvided()
        {
            // Arrange
            var newUser = new RegisterDTO
            {
                Username = "testuser",
                FirstName = "Test",
                LastName = "User",
                Email = "testuser@test.com",
                PhoneNumber = "1234567890",
                Birthday = DateTime.Now,
                Role = "admin"
            };

            // Act
            var result = _mockUserDAL.CreateUserDAL(newUser);

            // Assert
            Assert.True(result);
            Assert.True(_mockUserDAL.IsEmailUsedDAL("testuser@test.com"));
        }

        [Fact]
        public void CreateUserDAL_ShouldFail_WhenDuplicateEmailIsUsed()
        {
            // Arrange
            var user1 = new RegisterDTO
            {
                Username = "user1",
                FirstName = "User",
                LastName = "One",
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
                Email = "duplicate@example.com",  // Same email
                PhoneNumber = "0987654321",
                Birthday = DateTime.Now,
                Role = "user"
            };
            _mockUserDAL.CreateUserDAL(user1);

            // Act
            var result = _mockUserDAL.CreateUserDAL(user2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetUserByIdDAL_ShouldReturnUser_WhenIdIsValid()
        {
            // Arrange
            var newUser = new RegisterDTO
            {
                Username = "existinguser",
                FirstName = "Existing",
                LastName = "User",
                Email = "existuser@example.com",
                PhoneNumber = "1234567890",
                Birthday = DateTime.Now,
                Role = "customer"
            };
            _mockUserDAL.CreateUserDAL(newUser);
            int userId = _mockUserDAL.users.Last().Id;  // Get the ID of the newly added user

            // Act
            var user = _mockUserDAL.GetUserByIdDAL(userId);

            // Assert
            Assert.NotNull(user);
            Assert.Equal("existinguser", user.Username);
        }

        [Fact]
        public void DeleteUserDAL_ShouldRemoveUser_WhenIdIsValid()
        {
            // Arrange
            var newUser = new RegisterDTO
            {
                Username = "deleteuser",
                FirstName = "Delete",
                LastName = "User",
                Email = "deleteuser@example.com",
                PhoneNumber = "1234567890",
                Birthday = DateTime.Now,
                Role = "customer"
            };
            _mockUserDAL.CreateUserDAL(newUser);
            int userId = _mockUserDAL.users.Last().Id;  // Get the ID of the newly added user

            // Act
            _mockUserDAL.DeleteUserDAL(userId);
            var user = _mockUserDAL.GetUserByIdDAL(userId);

            // Assert
            Assert.Null(user);
        }

        [Fact]
        public void UpdateUserDAL_ShouldUpdateUser_WhenUserExists()
        {
            // Arrange
            var newUser = new RegisterDTO
            {
                Username = "updateuser",
                FirstName = "Initial",
                LastName = "User",
                Email = "updateuser@example.com",
                PhoneNumber = "1234567890",
                Birthday = DateTime.Now,
                Role = "customer"
            };
            _mockUserDAL.CreateUserDAL(newUser);
            int userId = _mockUserDAL.users.Last().Id;

            var updateUser = new UpdateUserDTO
            {
                Id = userId,
                ProfilePicture = new byte[0],
                FirstName = "Updated",
                LastName = "User",
                Email = "updated@example.com",
                PhoneNumber = "0987654321",
                Birthday = DateTime.Now.AddDays(-1),
                Username = "updateduser",
                Role = "admin"
            };

            // Act
            var result = _mockUserDAL.UpdateUserDAL(updateUser);
            var updatedUser = _mockUserDAL.GetUserByIdDAL(userId);

            // Assert
            Assert.True(result);
            Assert.Equal("Updated", updatedUser.FirstName);
            Assert.Equal("admin", updatedUser.Role);
        }
    }
}