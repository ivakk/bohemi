using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Alcohol : Beverage
    {
        public double Percentage { get; set; }
        public int Age { get; set; }
        
        public Alcohol(int id, byte[] picture, string name, int size, double price, double percentage, int age) : base(id, picture, name, size, price)
        {
            Percentage = percentage;
            Age = age;
        }
        
        public Alcohol() 
        {
            
        }
    }
}
