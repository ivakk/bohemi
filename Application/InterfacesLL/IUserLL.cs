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
        public void BanUser(Users banUser, string reason);
        public void UnbanUser(Users banUser);
        public bool IsUserBanned(Users bannedUser);
        public bool IsUsernameUsed(string username);
        public bool IsEmailUsed(string email);
        public void DeleteUser(int id);
        public Users GetUserByUsername(string username);
        public bool IsEmail(string email);
        public bool IsPhoneNumber(string phoneNumber);
        public List<Users> GetAllUsers();
        public bool UpdateUser(UpdateUserDTO updateUser);
        public List<Users> GetUsersBySearch(string search);
        public UpdateUserDTO GetUserForUpdateDTO(int id);
    }
}
