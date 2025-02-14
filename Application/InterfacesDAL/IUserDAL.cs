﻿using System;
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
        bool CreateUserDAL(RegisterDTO newUser);
        UserDTO GetUserDTOForLoginDAL(string username);
        Users GetUserByIdDAL(int id);
        bool BanUserDAL(Users banUser, string reason);
        bool UnbanUserDAL(Users banUser);
        bool IsUserBannedDAL(Users bannedUser);
        bool IsUsernameUsedDAL(string username);
        bool IsEmailUsedDAL(string email);
        bool DeleteUserDAL(int id);
        Users GetUserByUsernameDAL(string username);
        List<Users> GetAllUsersDAL();
        bool UpdateUserDAL(UpdateUserDTO updateUser);
        Tuple<string, string> hashSaltDAL(string username);
    }
}
