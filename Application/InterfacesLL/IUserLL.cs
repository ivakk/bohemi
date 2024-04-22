using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using DTOs;

namespace InterfacesLL
{
    public interface IUserLL
    {
        public bool CreateUser(RegisterDTO newUser);
        public bool IsPasswordCorrect(string username, string password);
        public LoginDTO CheckUser(string username, string password);
        public Users GetUserById(int id);
    }
}
