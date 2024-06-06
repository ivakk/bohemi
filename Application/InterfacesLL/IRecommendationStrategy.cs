using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface IRecommendationStrategy
    {
        List<Users> RecommendUsers(Users user, List<Users> allUsers, List<LikedEvent> allEvents, List<LikedBeverage> allBeverages);
    }
}
