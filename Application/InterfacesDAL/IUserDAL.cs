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
        public LoginDTO GetUserForLoginDTODAL(string username, string password);
        public Users GetUserByIdDAL(int id);
        public void BanUserDAL(Users banUser, string reason);
        public void UnbanUserDAL(Users banUser);
        public bool IsUserBannedDAL(Users bannedUser);
        public bool IsUsernameUsedDAL(string username);
        public bool IsEmailUsedDAL(string email);
        public void DeleteUserDAL(int id);
        public Users GetUserByUsernameDAL(string username);
        public List<Users> GetAllUsersDAL();
        public bool UpdateUserDAL(UpdateUserDTO updateUser);
        public UpdateUserDTO GetUserForUpdateDTODAL(int id);
    }
}
