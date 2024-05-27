using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserDTO
    {
        public int Id { get; }
        public string? Role { get; set; }

        public UserDTO(int id, string role)
        {
            Id = id;
            Role = role;
        }
        
        public UserDTO() 
        { 
        }
    }
}
