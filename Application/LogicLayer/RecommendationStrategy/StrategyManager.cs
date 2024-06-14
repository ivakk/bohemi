using Classes;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.RecommendationStrategy
{
    public class StrategyManager
    {
        public IRecommendationStrategy DetermineStrategy(Users currentUser, List<LikedEvent> allEvents, List<LikedBeverage> allBeverages)
        {
            // Check if the current user has sufficient data
            bool hasEnoughEvents = allEvents.Count(e => e.UserId == currentUser.Id) >= 3;
            bool hasEnoughDrinks = allBeverages.Count(d => d.UserId == currentUser.Id) >= 1;

            if (hasEnoughEvents && hasEnoughDrinks)
            {
                return new AgeEventBeverageRecommendationStrategy();
            }
            else
            {
                return new BirthdayClosenessRecommendationStrategy();
            }
        }
    }
}
