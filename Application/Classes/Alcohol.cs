using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Alcohol : Beverage
    {
        public int Percentage { get; private set; }
        public int Age { get; private set; }
        
        public Alcohol(int id, byte[] picture, string name, int size, double price, int percentage, int age) : base(id, picture, name, size, price)
        {
            Percentage = percentage;
            Age = age;
        }
        
        public Alcohol() 
        {
            
        }

        public string GetObjectString()
        {
            return Id.ToString() + Name + Size + Price + Percentage + Age;
        }
    }
}
