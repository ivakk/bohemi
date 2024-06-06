using Classes;
using LogicLayer.RecommendationStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockDAL;

namespace UnitTests
{
    public class RecommendationStrategyTests
    {
        [Fact]
        public void RecommendUsers_WithCommonInterestsAndAgeRange_ReturnsCorrectRecommendations()
        {
            // Arrange
            MockStrategyDAL mockStrategyDAL = new MockStrategyDAL();
            RecommendationStrategy strategy = new RecommendationStrategy();
            Users currentUser = new Users(1, null, "Test", "User1", new DateTime(1990, 01, 01), "testuser1", "testuser1@mail.com", "1234567890", "customer");

            // Act
            List<Users> recommendedUsers = strategy.RecommendUsers(currentUser, mockStrategyDAL.GetAllUsers(), mockStrategyDAL.GetAllEvents(), mockStrategyDAL.GetAllBeverages());

            // Assert
            Assert.Contains(recommendedUsers, u => u.Id == 2); // User 2 should match
            Assert.DoesNotContain(recommendedUsers, u => u.Id == 3); // User 3 should not match
        }

        [Fact]
        public void RecommendUsers_WithoutCommonInterests_ReturnsEmpty()
        {
            // Arrange
            MockStrategyDAL mockStrategyDAL = new MockStrategyDAL();
            RecommendationStrategy strategy = new RecommendationStrategy();
            Users currentUser = new Users(1, null, "Test", "User1", new DateTime(1991, 01, 01), "testuser1", "testuser1@mail.com", "1234567890", "customer");

            // Act
            List<Users> recommendedUsers = strategy.RecommendUsers(currentUser, mockStrategyDAL.GetAllUsers(), mockStrategyDAL.GetAllEvents(), mockStrategyDAL.GetAllBeverages());

            // Assert
            Assert.Empty(recommendedUsers); // No users should be recommended
        }
    }
}
