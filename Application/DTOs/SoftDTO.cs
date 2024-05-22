using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class SoftDTO : BeverageDTO
    {
        public string Carbonated { get; set; }

        public SoftDTO(int id, byte[] picture, string name, int size, double price, string carbonated) : base(id, picture, name, size, price) 
        {
            Carbonated = carbonated;
        }

        public SoftDTO()
        {

        }
    }
}
