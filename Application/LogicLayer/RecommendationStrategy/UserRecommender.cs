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
        private IRecommendationStrategy _recommendationStrategy;

        /// <summary>
        /// Initializes the recommender with a specific strategy.
        /// </summary>
        public UserRecommender(IRecommendationStrategy recommendationStrategy)
        {
            _recommendationStrategy = recommendationStrategy;
        }

        /// <summary>
        /// Sets or switches the recommendation strategy.
        /// </summary>
        public void SetStrategy(IRecommendationStrategy recommendationStrategy)
        {
            _recommendationStrategy = recommendationStrategy;
        }

        /// <summary>
        /// Generates recommendations for a user using the current strategy.
        /// </summary>
        public List<Users> RecommendUsers(Users user, List<Users> allUsers, List<LikedEvent> allEvents, List<LikedBeverage> allBeverages)
        {
            return _recommendationStrategy.RecommendUsers(user, allUsers, allEvents, allBeverages);
        }
    }
}
