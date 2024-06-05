using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using DTOs;

namespace InterfacesLL
{
    public interface IUserService
    {
        bool CreateUser(RegisterDTO newUser);
        bool IsPasswordCorrect(string username, string password);
        UserDTO CheckUser(string username, string password);
        Users GetUserById(int id);
        bool BanUser(Users banUser, string reason);
        bool UnbanUser(Users banUser);
        bool IsUserBanned(Users bannedUser);
        bool IsUsernameUsed(string username);
        bool IsEmailUsed(string email);
        bool DeleteUser(int id);
        Users GetUserByUsername(string username);
        bool IsEmail(string email);
        bool IsPhoneNumber(string phoneNumber);
        List<Users> GetAllUsers();
        bool UpdateUser(UpdateUserDTO updateUser);
        List<Users> GetUsersBySearch(string search);
        UpdateUserDTO GetUserForUpdateDTO(int id);
        List<Users> GetFirstUsers(int count);
    }
}
