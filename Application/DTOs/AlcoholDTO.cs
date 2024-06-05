using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AlcoholDTO : BeverageDTO
    {
        public double Percentage { get; set; }
        public int Age { get; set; }
        
        public AlcoholDTO(int id, byte[] picture, string name, int size, decimal price, int percentage, int age) : base(id, picture, name, size, price)
        {
            Percentage = percentage;
            Age = age;
        }
        
        public AlcoholDTO() 
        {
            
        }
    }
}
