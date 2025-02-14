﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Classes;
using CustomExceptions;
using DTOs;
using InterfacesDAL;
using InterfacesLL;

namespace LogicLayer
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL;
        PasswordHashingService passwordHashingService;

        public UserService(IUserDAL _userDAL)
        {
            this._userDAL = _userDAL;
            passwordHashingService = new PasswordHashingService();
        }

        public bool CreateUser(RegisterDTO newUser)
        {
            if (newUser == null)
            {
                return false;
            }
            else if (string.IsNullOrEmpty(newUser.FirstName) || string.IsNullOrEmpty(newUser.LastName) || newUser.Birthday == null || string.IsNullOrEmpty(newUser.Username) || 
                string.IsNullOrEmpty(newUser.Password) || string.IsNullOrEmpty(newUser.Email) || string.IsNullOrEmpty(newUser.PhoneNumber) || string.IsNullOrEmpty(newUser.Role))
            {
                return false;
            }
            else if (IsUsernameUsed(newUser.Username) == true)
            {
                throw new UsernameUsedException();
            }
            else if (IsEmailUsed(newUser.Email) == true)
            {
                throw new EmailUsedException();
            }
            else
            {
                newUser.PasswordSalt = passwordHashingService.PassSalt(10);
                newUser.PasswordHash = passwordHashingService.PassHash(newUser.Password, newUser.PasswordSalt);
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

            string hashedPasswordToCheck = passwordHashingService.PassHash(password, hashSalt.Item2);

            if (hashSalt.Item1 == hashedPasswordToCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UserDTO CheckUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException();
            }
            else if (!IsPasswordCorrect(username, password))
            {
                throw new InvalidDataException();
            }
            else if (IsUserBanned(GetUserByUsername(username)))
            {
                throw new BannedException();
            }
            else
            {
                return _userDAL.GetUserDTOForLoginDAL(username);
            }
        }
        public Users GetUserById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException();
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
            if (id < 0)
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
            Users curDetails = _userDAL.GetUserByIdDAL(updateUser.Id);
            
            if (updateUser == null)
            {

                throw new ArgumentNullException();
            }
            else if (string.IsNullOrEmpty(updateUser.FirstName) || string.IsNullOrEmpty(updateUser.LastName) || updateUser.Birthday == null || string.IsNullOrEmpty(updateUser.Username) 
                 || string.IsNullOrEmpty(updateUser.Email) || string.IsNullOrEmpty(updateUser.Password) || string.IsNullOrEmpty(updateUser.PhoneNumber) 
                 || string.IsNullOrEmpty(updateUser.Role))
            {
                return false;
            }
            else if (updateUser.Username != curDetails.Username && IsUsernameUsed(updateUser.Username) == true)
            {
                throw new UsernameUsedException();
            }
            else if (updateUser.Email != curDetails.Email && IsEmailUsed(updateUser.Email) == true)
            {
                throw new EmailUsedException();
            }
            else
            {
                if (updateUser.Password == "oaijsnfoiahnofsafgnasaosnfoaiosabfnaofsn")
                {
                    Tuple<string, string> hashSalt = _userDAL.hashSaltDAL(updateUser.Username);
                    updateUser.PasswordHash = hashSalt.Item1;
                    updateUser.PasswordSalt = hashSalt.Item2;
                }
                else
                {
                    updateUser.PasswordSalt = passwordHashingService.PassSalt(10);
                    updateUser.PasswordHash = passwordHashingService.PassHash(updateUser.Password, updateUser.PasswordSalt);
                }
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
        public List<Users> GetFirstUsers(int count)
        {
            List<Users> users = new List<Users>();
            int i = 0;
            foreach (Users user in GetAllUsers())
            {
                if (i < count)
                {
                    users.Add(user);
                    i++;
                }
                else
                {
                    break;
                }
            }
            return users;
        }
    }
}
