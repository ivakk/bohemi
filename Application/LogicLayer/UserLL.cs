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

        public bool CreateUser(RegisterDTO newUser)
        {
            if (newUser == null)
            {
                return false;
            }
            else if (string.IsNullOrEmpty(newUser.FirstName) || string.IsNullOrEmpty(newUser.LastName) || newUser.Birthday == null || string.IsNullOrEmpty(newUser.Username) || string.IsNullOrEmpty(newUser.Email)
                 || string.IsNullOrEmpty(newUser.PasswordHash) || string.IsNullOrEmpty(newUser.PasswordSalt) || string.IsNullOrEmpty(newUser.PhoneNumber) || string.IsNullOrEmpty(newUser.Role))
            {
                return true;
            }
            else
            {
                return _userDAL.CreateUserDAL(newUser);
            }
        }
        public bool IsPasswordCorrect(string username, string password)
        {
            /// This function returns true, if the password is correct for the given username.

            // Get user by username property, 
            Tuple<string, string> hashSalt = _userDAL.hashSaltDAL(username);

            // If there is no user with the given username address, return false.
            if (hashSalt == null)
            {
                return false;
            }

            string hashedPasswordToCheck = passwordHashingLL.PassHash(password, hashSalt.Item2);

            if (hashSalt.Item1 == hashedPasswordToCheck)
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
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("username");
            }
            else if (!IsPasswordCorrect(username, password))
            {
                throw new Exception();
            }
            else
            {
                return _userDAL.GetUserForLoginDTODAL(username, password);
            }
        }
        public Users GetUserById(int id)
        {
            if (id < 0 || id == null)
            {
                throw new ArgumentNullException("id");
            }
            else
            {
                return _userDAL.GetUserByIdDAL(id);
            }
        }
        public bool BanUser(Users banUser, string reason)
        {
            if (banUser == null || string.IsNullOrEmpty(reason))
            {
                return false;
            }
            else
            {
                return _userDAL.BanUserDAL(banUser, reason);
            }
        }
        public bool UnbanUser(Users banUser)
        {
            if (banUser == null)
            {
                return false;
            }
            else
            {
                return _userDAL.UnbanUserDAL(banUser); ;
            }
        }
        public bool IsUserBanned(Users bannedUser)
        {
            if(bannedUser == null)
            {
                return false;
            }
            else
            {
                return _userDAL.IsUserBannedDAL(bannedUser);
            }
        }
        public bool IsUsernameUsed(string username)
        {
            if (username == null)
            {
                return false;
            }
            else
            {
                return _userDAL.IsUsernameUsedDAL(username);
            }
        }
        public bool IsEmailUsed(string email)
        {
            if (email == null)
            {
                return false;
            }
            else
            {
                return _userDAL.IsEmailUsedDAL(email);
            }
        }
        public bool DeleteUser(int id)
        {
            if (id < 0 || id == null)
            {
                return false;
            }
            else
            {
                return _userDAL.DeleteUserDAL(id);
            }
        }
        public Users GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("username");
            }
            else
            {
                return _userDAL.GetUserByUsernameDAL(username);
            }
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
            if (updateUser == null)
            {
                throw new ArgumentNullException();
            }
            else if (string.IsNullOrEmpty(updateUser.FirstName) || string.IsNullOrEmpty(updateUser.LastName) || updateUser.Birthday == null || string.IsNullOrEmpty(updateUser.Username) 
                 || string.IsNullOrEmpty(updateUser.Email) || string.IsNullOrEmpty(updateUser.PasswordHash) || string.IsNullOrEmpty(updateUser.PasswordSalt) || string.IsNullOrEmpty(updateUser.PhoneNumber) 
                 || string.IsNullOrEmpty(updateUser.Role))
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _userDAL.UpdateUserDAL(updateUser);
            }
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
            if (id < 0 || id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _userDAL.GetUserForUpdateDTODAL(id);
            }
        }
    }
}
