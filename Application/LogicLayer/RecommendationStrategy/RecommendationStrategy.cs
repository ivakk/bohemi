using Classes;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.RecommendationStrategy
{
    public class RecommendationStrategy : IRecommendationStrategy
    {
        /// <summary>
        /// Recommends users who are within a 10-year age difference of the current user,
        /// and share at least 3 liked events and 1 liked drink.
        /// </summary>
        public List<Users> RecommendUsers(Users currentUser, List<Users> allUsers, List<LikedEvent> allEvents, List<LikedBeverage> allBeverages)
        {
            var recommendations = new List<Users>();

            // Calculate the age of the current user from their date of birth.
            var currentUserAge = DateTime.Now.Year - currentUser.Birthday.Year;

            foreach (var user in allUsers)
            {
                if (user.Id == currentUser.Id) continue; // Skip the current user

                // Calculate the age of the other user and compute the age difference.
                var age = DateTime.Now.Year - user.Birthday.Year;

                // Check if the age difference is within 10 years.
                if (Math.Abs(age - currentUserAge) <= 10)
                {
                    // Find common events by comparing event IDs liked by both the current user and the other user.
                    var commonEvents = allEvents.Where(e => e.UserId == user.Id)
                        .Select(e => e.EventId)
                        .Intersect(allEvents.Where(e => e.UserId == currentUser.Id).Select(e => e.EventId))
                        .Count(); // Count the number of common events.

                    // Find common drinks by comparing beverage IDs liked by both the current user and the other user.
                    var commonDrinks = allBeverages.Where(b => b.UserId == user.Id)
                        .Select(b => b.BeverageId)
                        .Intersect(allBeverages.Where(b => b.UserId == currentUser.Id).Select(b => b.BeverageId))
                        .Count(); // Count the number of common drinks.

                    // If there are at least 3 common events and 1 common drink, add this user to the recommendations.
                    if (commonEvents >= 3 && commonDrinks >= 1)
                    {
                        recommendations.Add(user);
                    }
                }
            }
            return recommendations;
        }
    }
}
