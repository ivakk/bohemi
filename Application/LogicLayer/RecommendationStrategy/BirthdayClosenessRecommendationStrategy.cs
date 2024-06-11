using Classes;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.RecommendationStrategy
{
    public class BirthdayClosenessRecommendationStrategy : IRecommendationStrategy
    {
        public List<Users> RecommendUsers(Users currentUser, List<Users> allUsers, List<LikedEvent> allEvents = null, List<LikedBeverage> allBeverage = null)
        {
            var currentUserAge = DateTime.Now.Year - currentUser.Birthday.Year;
            return allUsers.Where(u => u.Id != currentUser.Id)
                           .Select(u => new {
                               User = u,
                               Age = DateTime.Now.Year - u.Birthday.Year,
                               DaysDifference = Math.Abs((u.Birthday - currentUser.Birthday).Days)
                           })
                           .Where(u => Math.Abs(u.Age - currentUserAge) <= 5)  // Only consider users within 5 years of age difference
                           .OrderBy(u => u.DaysDifference) // Order by closeness in days
                           .Select(u => u.User)
                           .ToList();
        }
    }
}
