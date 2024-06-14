using Classes;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.RecommendationStrategy
{
    public class UserRecommender
    {
        private StrategyManager _strategyManager;

        public UserRecommender(StrategyManager strategyManager)
        {
            _strategyManager = strategyManager;
        }

        public List<Users> RecommendUsers(Users currentUser, List<Users> allUsers, List<LikedEvent> allEvents, List<LikedBeverage> allBeverages)
        {
            // Use the StrategyManager to select the primary strategy based on the current user's data
            IRecommendationStrategy primaryStrategy = _strategyManager.DetermineStrategy(currentUser, allEvents, allBeverages);

            // Get initial recommendations using the selected primary strategy
            List<Users> recommendedUsers = primaryStrategy.RecommendUsers(currentUser, allUsers, allEvents, allBeverages);

            // Check the number of recommendations; if 1 or fewer, apply the BirthdayClosenessStrategy
            if (recommendedUsers.Count <= 1)
            {
                // Assuming the BirthdayClosenessStrategy is always the secondary option when primary is insufficient
                IRecommendationStrategy secondaryStrategy = new BirthdayClosenessRecommendationStrategy();
                List<Users> additionalRecommendations = secondaryStrategy.RecommendUsers(currentUser, allUsers, allEvents, allBeverages);

                // Add additional recommendations ensuring no duplicates
                foreach (var user in additionalRecommendations)
                {
                    if (!recommendedUsers.Contains(user))
                    {
                        recommendedUsers.Add(user);
                    }
                }
            }

            return recommendedUsers;
        }
    }
}
