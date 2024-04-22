using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using DTOs;

namespace InterfacesDAL
{
    public interface IUserDAL
    {
        public bool CreateUserDAL(RegisterDTO newUser);
        public LoginDTO GetUserForDTODAL(string username, string password);
        public Users GetUserByIdDAL(int id);
    }
}
