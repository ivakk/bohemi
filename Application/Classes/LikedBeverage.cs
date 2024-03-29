using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class LikedBeverage
    {
        public int UserId { get; private set; }
        public int BeverageId { get; private set; }

        public LikedBeverage(int userId, int eventId)
        {
            UserId = userId;
            BeverageId = eventId;
        }
    }
}
