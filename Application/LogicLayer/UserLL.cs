using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
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
            LoginDTO user = _userDAL.GetUserForLoginDTODAL(username, password);

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

            return _userDAL.GetUserForLoginDTODAL(username, password);
        }
        public Users GetUserById(int id)
        {
            return _userDAL.GetUserByIdDAL(id);
        }
        public void BanUser(Users banUser, string reason)
        {
            _userDAL.BanUserDAL(banUser, reason);
        }
        public void UnbanUser(Users banUser)
        {
            _userDAL.UnbanUserDAL(banUser);
        }
        public bool IsUserBanned(Users bannedUser)
        {
            return _userDAL.IsUserBannedDAL(bannedUser);
        }
        public bool IsUsernameUsed(string username)
        {
            return _userDAL.IsUsernameUsedDAL(username);
        }
        public bool IsEmailUsed(string email)
        {
            return _userDAL.IsEmailUsedDAL(email);
        }
        public void DeleteUser(int id)
        {
            _userDAL.DeleteUserDAL(id);
        }
        public Users GetUserByUsername(string username)
        {
            return _userDAL.GetUserByUsernameDAL(username);
        }
        public bool IsEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

            return emailRegex.IsMatch(email);
        }
        public bool IsPhoneNumber(string phoneNumber)
        {
            Regex phoneRegex = new Regex(@"^0\d{9}$");

            return phoneRegex.IsMatch(phoneNumber);
        }
        public List<Users> GetAllUsers()
        {
            return _userDAL.GetAllUsersDAL();
        }
        public bool UpdateUser(UpdateUserDTO updateUser)
        {
            return _userDAL.UpdateUserDAL(updateUser);
        }
        public List<Users> GetUsersBySearch(string search)
        {
            List<Users> result = new List<Users>();
            foreach (Users User in GetAllUsers())
            {
                if (User.GetObjectString().Contains(search))
                {
                    result.Add(User);
                }
            }
            return result;
        }
        public UpdateUserDTO GetUserForUpdateDTO(int id)
        {
            return _userDAL.GetUserForUpdateDTODAL(id);
        }
    }
}
