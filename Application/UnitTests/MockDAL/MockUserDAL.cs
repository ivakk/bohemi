using Classes;
using DTOs;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockDAL
{
    public class MockUserDAL : IUserDAL
    {
        public readonly List<Users> users = new List<Users>();
        public readonly List<Users> bannedUsers = new List<Users>();
        private int nextId = 1;  // Simulating auto-increment ID

        public bool CreateUserDAL(RegisterDTO newUser)
        {
            if (users.Any(u => u.Email == newUser.Email || u.Username == newUser.Username))
            {
                return false;  // Avoid duplicates in username or email
            }

            var user = new Users(nextId++, new byte[0], newUser.FirstName, newUser.LastName,
                newUser.Birthday, newUser.Username, newUser.Email, newUser.PhoneNumber, newUser.Role);

            users.Add(user);
            return true;
        }

        public Users GetUserByIdDAL(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public bool DeleteUserDAL(int id)
        {
            var user = GetUserByIdDAL(id);
            users.Remove(user);
            return true;
        }

        public bool IsUsernameUsedDAL(string username)
        {
            return users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public bool IsEmailUsedDAL(string email)
        {
            return users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public bool UpdateUserDAL(UpdateUserDTO updateUser)
        {
            var user = GetUserByIdDAL(updateUser.Id);
            if (user == null)
            {
                return false;
            }

            users.Remove(GetUserByIdDAL(user.Id));
            users.Add(new Users(updateUser.Id, updateUser.ProfilePicture, updateUser.FirstName, updateUser.LastName, updateUser.Birthday, updateUser.Username,
                updateUser.Email, updateUser.PhoneNumber, updateUser.Role));
            return true;
        }

        public bool BanUserDAL(Users banUser, string reason)
        {
            throw new NotImplementedException();
        }

        public bool UnbanUserDAL(Users banUser)
        {
            throw new NotImplementedException();
        }

        public bool IsUserBannedDAL(Users bannedUser)
        {
            throw new NotImplementedException();
        }

        public Users GetUserByUsernameDAL(string username)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAllUsersDAL()
        {
            throw new NotImplementedException();
        }

        public UpdateUserDTO GetUserForUpdateDTODAL(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserDTOForLoginDAL(string username)
        {
            throw new NotImplementedException();
        }

        public Tuple<string, string> hashSaltDAL(string username)
        {
            throw new NotImplementedException();
        }
    }
}
