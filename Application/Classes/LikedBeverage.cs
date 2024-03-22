using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class LikedBeverage
    {
        public int UserId { get; set; }
        public int BeverageId { get; set; }

        public LikedBeverage(int userId, int eventId)
        {
            UserId = userId;
            BeverageId = eventId;
        }
    }
}
