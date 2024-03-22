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
        public byte[] Picture { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }

        public Beverage(int id, byte[] picture, string name, int size, double price)
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
