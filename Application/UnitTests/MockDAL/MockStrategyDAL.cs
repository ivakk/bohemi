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
            users.Add(new Users(1, null, "Test", "User1", new DateTime(1990, 01, 01), "testuser1", "testuser1@mail.com", "1234567890", "customer"));
            users.Add(new Users(2, null, "Test", "User2", new DateTime(1985, 06, 15), "testuser2", "testuser2@mail.com", "0123456789", "customer"));
            users.Add(new Users(3, null, "Test", "User3", new DateTime(2000, 07, 20), "testuser3", "testuser3@mail.com", "2134567890", "customer"));
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
            likedEvents.Add(new LikedEvent(3, 4));
            return likedEvents;
        }
        public List<LikedBeverage> GetAllBeverages()
        {
            List<LikedBeverage> likedBeverages = new List<LikedBeverage>();
            likedBeverages.Add(new LikedBeverage(1, 1));
            likedBeverages.Add(new LikedBeverage(2, 1));
            likedBeverages.Add(new LikedBeverage(3, 2));
            return likedBeverages;
        }
    }
}
