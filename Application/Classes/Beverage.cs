using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Beverage
    {
        public int Id { get; }
        public byte[] Picture { get; private set; }
        public string Name { get; private set; }
        public int Size { get; private set; }
        public decimal Price { get; private set; }

        public Beverage(int id, byte[] picture, string name, int size, decimal price)
        {
            Id = id;
            Picture = picture;
            Name = name;
            Size = size;
            Price = price;
        }

        public Beverage() 
        {
            
        }
    }
}
