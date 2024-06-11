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
        private IRecommendationStrategy _strategy;
        private readonly IRecommendationStrategy _ageEventBeverageStrategy;
        private readonly IRecommendationStrategy _birthdayClosenessStrategy;

        public UserRecommender(IRecommendationStrategy ageEventBeverageStrategy, IRecommendationStrategy birthdayClosenessStrategy)
        {
            _ageEventBeverageStrategy = ageEventBeverageStrategy;
            _birthdayClosenessStrategy = birthdayClosenessStrategy;
            _strategy = ageEventBeverageStrategy;  // Default strategy
        }

        public List<Users> RecommendUsers(Users currentUser, List<Users> allUsers, List<LikedEvent> allEvents, List<LikedBeverage> allBeverages)
        {
            // Check if current user has sufficient data
            bool hasSufficientData = allEvents.Count(e => e.UserId == currentUser.Id) >= 3 &&
                                     allBeverages.Count(d => d.UserId == currentUser.Id) >= 1;

            // Decide which strategy to use based on the data availability
            if (hasSufficientData)
            {
                _strategy = _ageEventBeverageStrategy;
                if (_strategy.RecommendUsers(currentUser, allUsers, allEvents, allBeverages).Count() <= 1)
                {
                    _strategy = _birthdayClosenessStrategy;
                }
            }
            else
            {
                _strategy = _birthdayClosenessStrategy;
            }

            // Execute the recommendation strategy
            return _strategy.RecommendUsers(currentUser, allUsers, allEvents, allBeverages);
        }

        // Optionally expose a method to manually set the strategy if needed
        public void SetStrategy(IRecommendationStrategy strategy)
        {
            _strategy = strategy;
        }
    }
}
