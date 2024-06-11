using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockDAL
{
    public class MockStrategyDAL
    {
        public List<Users> GetAllUsers()
        {
            List<Users> users = new List<Users>();
            users.Add(new Users(1, null, "Test", "User1", new DateTime(1995, 05, 15), "testuser1", "testuser1@mail.com", "1234567890", "customer")); // Test User
            users.Add(new Users(2, null, "Test", "User2", new DateTime(1993, 05, 15), "testuser2", "testuser2@mail.com", "0123456789", "customer")); // Within 5-year range
            users.Add(new Users(3, null, "Test", "User3", new DateTime(1987, 05, 15), "testuser3", "testuser3@mail.com", "2134567890", "customer")); // Outside 5-year range
            users.Add(new Users(4, null, "Test", "User4", new DateTime(1996, 05, 15), "testuser4", "testuser4@mail.com", "3124567890", "customer")); // Within 5-year range, no common events/drinks
            return users;
        }
        public List<LikedEvent> GetAllEvents()
        {
            List<LikedEvent> likedEvents = new List<LikedEvent>();
            likedEvents.Add(new LikedEvent(1, 1));
            likedEvents.Add(new LikedEvent(1, 2));
            likedEvents.Add(new LikedEvent(1, 3));
            likedEvents.Add(new LikedEvent(2, 1));
            likedEvents.Add(new LikedEvent(2, 2));
            likedEvents.Add(new LikedEvent(2, 3));
            likedEvents.Add(new LikedEvent(4, 4));
            return likedEvents;
        }
        public List<LikedBeverage> GetAllBeverages()
        {
            List<LikedBeverage> likedBeverages = new List<LikedBeverage>();
            likedBeverages.Add(new LikedBeverage(1, 1));
            likedBeverages.Add(new LikedBeverage(2, 1));
            likedBeverages.Add(new LikedBeverage(4, 2));
            return likedBeverages;
        }
    }
}
