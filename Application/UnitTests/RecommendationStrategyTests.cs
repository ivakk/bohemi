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
            List<Users> users = mockStrategyDAL.GetAllUsers();
            List<LikedEvent> events = mockStrategyDAL.GetAllEvents();
            List<LikedBeverage> beverages = mockStrategyDAL.GetAllBeverages();
            AgeEventBeverageRecommendationStrategy strategy = new AgeEventBeverageRecommendationStrategy();
            Users currentUser = new Users(1, null, "Test", "User1", new DateTime(1995, 01, 01), "testuser1", "testuser1@mail.com", "1234567890", "customer");

            // Act
            List<Users> recommendedUsers = strategy.RecommendUsers(currentUser, users, events, beverages);

            // Assert
            Assert.Contains(recommendedUsers, u => u.Id == 2); // User 2 should match
            Assert.DoesNotContain(recommendedUsers, u => u.Id == 3); // User 3 should not match
        }

        [Fact]
        public void RecommendUsers_WithoutCommonInterests_ReturnsEmpty()
        {
            // Arrange
            MockStrategyDAL mockStrategyDAL = new MockStrategyDAL();
            AgeEventBeverageRecommendationStrategy strategy = new AgeEventBeverageRecommendationStrategy();
            Users currentUser = new Users(3, null, "Test", "User3", new DateTime(2000, 07, 20), "testuser3", "testuser3@mail.com", "2134567890", "customer");

            // Act
            List<Users> recommendedUsers = strategy.RecommendUsers(currentUser, mockStrategyDAL.GetAllUsers(), mockStrategyDAL.GetAllEvents(), mockStrategyDAL.GetAllBeverages());

            // Assert
            Assert.Empty(recommendedUsers); // No users should be recommended
        }
        [Fact]
        public void AgeEventBeverageRecommendation_HappyFlow_ReturnsCorrectUsers()
        {
            // Arrange
            MockStrategyDAL mockStrategyDAL = new MockStrategyDAL();
            List<Users> users = mockStrategyDAL.GetAllUsers();
            List<LikedEvent> events = mockStrategyDAL.GetAllEvents();
            List<LikedBeverage> beverages = mockStrategyDAL.GetAllBeverages();
            AgeEventBeverageRecommendationStrategy strategy = new AgeEventBeverageRecommendationStrategy();
            Users currentUser = users[0]; // User 1

            // Act
            List<Users> recommendedUsers = strategy.RecommendUsers(currentUser, users, events, beverages);

            // Assert
            Assert.Contains(recommendedUsers, u => u.Id == 2); // User 2 matches criteria
            Assert.DoesNotContain(recommendedUsers, u => u.Id == 3); // User 3 does not match age range
            Assert.DoesNotContain(recommendedUsers, u => u.Id == 4); // User 4 does not have enough common events/drinks
        }

        [Fact]
        public void AgeEventBeverageRecommendation_UnhappyFlow_NoCommonInterests_ReturnsNoUsers()
        {
            //Arrange
            MockStrategyDAL mockStrategyDAL = new MockStrategyDAL();
            List<Users> users = mockStrategyDAL.GetAllUsers();
            List<LikedEvent> events = mockStrategyDAL.GetAllEvents(); // Assume no events for User 2
            List<LikedBeverage> beverages = mockStrategyDAL.GetAllBeverages(); // Assume no drinks for User 2
            AgeEventBeverageRecommendationStrategy strategy = new AgeEventBeverageRecommendationStrategy();
            Users currentUser = users[0]; // User 1

            // Manipulate data to remove commonalities
            events.RemoveAll(e => e.UserId == 2);
            beverages.RemoveAll(d => d.UserId == 2);

            // Act
            List<Users> recommendedUsers = strategy.RecommendUsers(currentUser, users, events, beverages);

            // Assert
            Assert.DoesNotContain(recommendedUsers, u => u.Id == 2); // User 2 has no common interests
        }
        [Fact]
        public void BirthdayClosenessRecommendation_HappyFlow_ReturnsCorrectOrder()
        {
            //Arrange
            MockStrategyDAL mockStrategyDAL = new MockStrategyDAL();
            List<Users> users = mockStrategyDAL.GetAllUsers();
            BirthdayClosenessRecommendationStrategy strategy = new BirthdayClosenessRecommendationStrategy();
            Users currentUser = users[0]; // User 1

            // Act
            List<Users> recommendedUsers = strategy.RecommendUsers(currentUser, users);

            // Assert
            var orderedUsers = recommendedUsers.Select(u => u.Id).ToList();
            Assert.Equal(new List<int> { 4, 5, 2 }, orderedUsers); // Expected order based on birthday closeness
        }

        [Fact]
        public void BirthdayClosenessRecommendation_UnhappyFlow_OutOfAgeRange()
        {
            //Arrange
            MockStrategyDAL mockStrategyDAL = new MockStrategyDAL();
            List<Users> users = mockStrategyDAL.GetAllUsers();
            BirthdayClosenessRecommendationStrategy strategy = new BirthdayClosenessRecommendationStrategy();
            Users currentUser = users[0]; // User 1

            // Act
            List<Users> recommendedUsers = strategy.RecommendUsers(currentUser, users);

            // Assert
            Assert.DoesNotContain(recommendedUsers, u => u.Id == 3); // User 3 is out of the 5-year age range
        }
        [Fact]
        public void AgeEventBeverageRecommendation_InsufficientData_NoRecommendations()
        {
            //Arrange
            MockStrategyDAL mockStrategyDAL = new MockStrategyDAL();
            List<Users> users = mockStrategyDAL.GetAllUsers();
            List<LikedEvent> events = mockStrategyDAL.GetAllEvents();
            List<LikedBeverage> beverages = mockStrategyDAL.GetAllBeverages();
            AgeEventBeverageRecommendationStrategy strategy = new AgeEventBeverageRecommendationStrategy();
            Users currentUser = users[0]; // User 1

            // Manipulate data to reflect insufficient data for the current user
            events.RemoveAll(e => e.UserId == 1); // Remove all events liked by User 1
            events.Add(new LikedEvent(1, 1)); // Add only one event for User 1
            events.Add(new LikedEvent(1,2)); // Add second event, still below threshold
            beverages.RemoveAll(d => d.UserId == 1); // Remove all drinks liked by User 1

            // Act
            List<Users> recommendedUsers = strategy.RecommendUsers(currentUser, users, events, beverages);

            // Assert
            Assert.Empty(recommendedUsers); // Expect no recommendations due to insufficient data
        }
        [Fact]
        public void AgeEventBeverageRecommendation_CurrentUserLacksEventsAndBeverages_NoRecommendations()
        {
            //Arrange
            MockStrategyDAL mockStrategyDAL = new MockStrategyDAL();
            List<Users> users = mockStrategyDAL.GetAllUsers();
            List<LikedEvent> events = mockStrategyDAL.GetAllEvents();
            List<LikedBeverage> beverages = mockStrategyDAL.GetAllBeverages();
            AgeEventBeverageRecommendationStrategy strategy = new AgeEventBeverageRecommendationStrategy();
            Users currentUser = new Users(5, null, "Test", "User5", new DateTime(1994, 05, 15), "testuser5", "testuser5@mail.com", "2534567890", "customer"); // New user who lacks sufficient data

            // Act
            List<Users> recommendedUsers = strategy.RecommendUsers(currentUser, users, events, beverages);

            // Assert
            Assert.Empty(recommendedUsers); // No recommendations should be made as the current user lacks the data
        }
        [Fact]
        public void Recommender_SwitchesStrategy_WhenInsufficientData()
        {
            //Arrange
            MockStrategyDAL mockStrategyDAL = new MockStrategyDAL();
            List<Users> users = mockStrategyDAL.GetAllUsers();
            List<LikedEvent> events = mockStrategyDAL.GetAllEvents();
            List<LikedBeverage> beverages = mockStrategyDAL.GetAllBeverages();
            AgeEventBeverageRecommendationStrategy ageEventBeverageStrategy = new AgeEventBeverageRecommendationStrategy();
            BirthdayClosenessRecommendationStrategy birthdayClosenessStrategy = new BirthdayClosenessRecommendationStrategy();
            var strategyManager = new StrategyManager();
            UserRecommender recommender = new UserRecommender(strategyManager);
            Users currentUser = users[0]; // Assuming User 1

            // Remove sufficient event and drink data for the current user
            events.RemoveAll(e => e.UserId == currentUser.Id);
            beverages.RemoveAll(d => d.UserId == currentUser.Id);

            // Act
            List<Users> recommendedUsers = recommender.RecommendUsers(currentUser, users, events, beverages);

            // Assert
            // Since AgeEventBeverage strategy requires 3 events and 1 drink and we've removed these, the recommender should switch to BirthdayCloseness strategy.
            // Hence, we expect the results to be based on birthday closeness rather than shared events/drinks.
            Assert.True(recommendedUsers.All(u => u.Id != currentUser.Id)); // Ensure no self-recommendation
            Assert.True(recommendedUsers.SequenceEqual(users.Where(u => u.Id != currentUser.Id && Math.Abs(u.Birthday.Year - currentUser.Birthday.Year) <= 5)
                                                            .OrderBy(u => Math.Abs((u.Birthday - currentUser.Birthday).Days))));
        }
        [Fact]
        public void Recommender_UsesPrimaryStrategyEfficiently_WhenSufficient()
        {
            // Arrange
            var mockStrategyDAL = new MockStrategyDAL();
            var users = mockStrategyDAL.GetAllUsers();
            var events = mockStrategyDAL.GetAllEvents();
            var beverages = mockStrategyDAL.GetAllBeverages();
            var strategyManager = new StrategyManager();
            var recommender = new UserRecommender(strategyManager);

            Users currentUser = users[0]; // Assuming User 1 with enough data for primary strategy

            // Act
            var recommendedUsers = recommender.RecommendUsers(currentUser, users, events, beverages);

            // Assert
            // Verify that primary strategy provides sufficient results and secondary is not needed
            var orderedUsers = recommendedUsers.Select(u => u.Id).ToList();
            Assert.Equal(new List<int> { 2, 5 }, orderedUsers); // Expected order
        }
        [Fact]
        public void Recommender_SwitchesStrategy_WhenPrimaryStrategyGivesFewResults()
        {
            // Arrange
            var mockStrategyDAL = new MockStrategyDAL();
            var users = mockStrategyDAL.GetAllUsers();
            var events = mockStrategyDAL.GetAllEvents();
            var beverages = mockStrategyDAL.GetAllBeverages();
            var strategyManager = new StrategyManager();
            var recommender = new UserRecommender(strategyManager);

            // Assuming User 1 initially only gets zero or one recommendation using the AgeEventBeverage strategy
            // Simulate this scenario by limiting event and beverage data to ensure only 0 or 1 user qualifies
            Users currentUser = users[0];  // Assuming User 1

            // Remove events and beverages for all but one user to limit the results from the primary strategy
            events = events.Where(e => e.UserId == currentUser.Id || e.UserId == users[1].Id).ToList();
            beverages = beverages.Where(b => b.UserId == currentUser.Id || b.UserId == users[1].Id).ToList();

            // Act
            var recommendedUsers = recommender.RecommendUsers(currentUser, users, events, beverages);

            // Assert
            // Verify that the secondary strategy is invoked to augment the list of recommendations
            // Check if more than just the primary strategy users are included
            Assert.True(recommendedUsers.Count >= 1);
            Assert.Contains(recommendedUsers, u => u.Id != currentUser.Id); // Ensure that other users are recommended
            Assert.Contains(recommendedUsers, u => u.Id == users[1].Id); // User 2 matches primary strategy
        }
        [Fact]
        public void Recommender_FailsToRecommend_WhenNoStrategyFindsMatches()
        {
            // Arrange
            var mockStrategyDAL = new MockStrategyDAL();
            var users = mockStrategyDAL.GetAllUsers();
            var events = new List<LikedEvent>(); // Empty event list simulating no matching interests
            var beverages = new List<LikedBeverage>(); // Empty beverage list simulating no matching preferences
            var strategyManager = new StrategyManager();
            var recommender = new UserRecommender(strategyManager);

            Users currentUser = users[0]; // Assuming User 1, typically has data but here no events or beverages to match
            users.RemoveAll(u => u.Id != currentUser.Id); // Remove all users besides User 1

            // Act
            var recommendedUsers = recommender.RecommendUsers(currentUser, users, events, beverages);

            // Assert
            // Expecting zero recommendations due to no data matching and no users birthday closeness
            Assert.Empty(recommendedUsers);
        }
    }
}
