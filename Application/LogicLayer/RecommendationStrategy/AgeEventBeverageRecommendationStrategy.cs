using Classes;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.RecommendationStrategy
{
    public class AgeEventBeverageRecommendationStrategy : IRecommendationStrategy
    {
        /// <summary>
        /// Recommends users who are within a 10-year age difference of the current user,
        /// and share at least 3 liked events and 1 liked drink.
        /// </summary>
        public List<Users> RecommendUsers(Users currentUser, List<Users> allUsers, List<LikedEvent> allEvents, List<LikedBeverage> allBeverages)
        {
            if (allEvents == null || allBeverages == null)
            {
                throw new ArgumentNullException("allEvents and allBeverages cannot be null for this strategy.");
            }

            var currentUserAge = DateTime.Now.Year - currentUser.Birthday.Year;
            return allUsers.Where(u => u.Id != currentUser.Id)
                           .Select(u => new {
                               User = u,
                               Age = DateTime.Now.Year - u.Birthday.Year
                           })
                           .Where(u => Math.Abs(u.Age - currentUserAge) <= 5)  // Only consider users within 5 years of age difference
                           .Select(u => new {
                               u.User,
                               CommonEvents = allEvents.Where(e => e.UserId == u.User.Id).Select(e => e.EventId).Intersect(allEvents.Where(e => e.UserId == currentUser.Id).Select(e => e.EventId)).Count(),
                               CommonDrinks = allBeverages.Where(b => b.UserId == u.User.Id).Select(b => b.BeverageId).Intersect(allBeverages.Where(b => b.UserId == currentUser.Id).Select(b => b.UserId)).Count()
                           })
                           .Where(u => u.CommonEvents >= 3 && u.CommonDrinks >= 1)
                           .OrderByDescending(u => u.CommonEvents + u.CommonDrinks)
                           .Select(u => u.User)
                           .ToList();
        }
    }
}
