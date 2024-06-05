using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class BeverageDTO
    {
        public int Id { get; }
        public byte[] Picture { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }

        public BeverageDTO(int id, byte[] picture, string name, int size, decimal price)
        {
            Id = id;
            Picture = picture;
            Name = name;
            Size = size;
            Price = price;
        }

        public BeverageDTO() 
        {
            
        }
    }
}
