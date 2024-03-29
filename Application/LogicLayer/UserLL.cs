using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using DTOs;
using InterfacesDAL;
using InterfacesLL;

namespace LogicLayer
{
    public class UserLL : IUserLL
    {
        private readonly IUserDAL _userDAL;
        PasswordHashingLL passwordHashingLL;

        public UserLL(IUserDAL _userDAL)
        {
            this._userDAL = _userDAL;
            passwordHashingLL = new PasswordHashingLL();
        }

        public UserLL()
        {
        }

        public bool CreateUser(RegisterDTO newUser)
        {
            return _userDAL.CreateUserDAL(newUser);
        }

        public bool IsPasswordCorrect(string username, string password)
        {
            /// This function returns true, if the password is correct for the given username.

            // Get user by username property, 
            LoginDTO user = _userDAL.GetUserForDTODAL(username, password);

            // If there is no user with the given username address, return false.
            if (user == null)
            {
                return false;
            }

            string hashedPasswordToCheck = passwordHashingLL.PassHash(password, user.PasswordSalt);

            if (user.PasswordHash == hashedPasswordToCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public LoginDTO CheckUser(string username, string password)
        {
            if (!IsPasswordCorrect(username, password))
            {
                throw new Exception();
            }

            return _userDAL.GetUserForDTODAL(username, password);
        }
    }
}
