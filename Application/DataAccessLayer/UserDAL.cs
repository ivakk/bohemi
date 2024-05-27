using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesDAL;
using Classes;
using DTOs;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class UserDAL : Connection, IUserDAL
    {
        private readonly string tableName = "Users";

        public UserDAL() 
        { 
        }


        /**
         * Query that creates a new user in the database
         */
        public bool CreateUserDAL(RegisterDTO newUser)
        {
            // Set up the query
            string query = $"INSERT INTO {tableName} " +
                           $"(username, firstName, lastName, email, birthdate, passwordHash, passwordSalt, phoneNumber, role) " +
                           $"VALUES (@username, @firstName, @lastName, @email," +
                           $"@birthday, @passwordHash, @passwordSalt, @phoneNumber, @role)";

            try
            {
                // Open the connection
                connection.Open();
                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);
                command.Parameters.AddWithValue("@username", newUser.Username);
                command.Parameters.AddWithValue("@firstName", newUser.FirstName);
                command.Parameters.AddWithValue("@lastName", newUser.LastName);
                command.Parameters.AddWithValue("@email", newUser.Email);
                command.Parameters.AddWithValue("@role", newUser.Role);
                command.Parameters.AddWithValue("@birthday", newUser.Birthday);
                command.Parameters.AddWithValue("@passwordHash", newUser.PasswordHash);
                command.Parameters.AddWithValue("@passwordSalt", newUser.PasswordSalt);
                command.Parameters.AddWithValue("@phoneNumber", newUser.PhoneNumber);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();

                return true;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public UserDTO GetUserDTOForLoginDAL(string username)
        {
            UserDTO user = null;
            string query = $"SELECT id, role FROM {tableName} WHERE username = @username";


            try
            {
                // Open the connection
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                // Add the parameters
                command.Parameters.AddWithValue("@username", username);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = (new UserDTO((int)reader["id"], (string)reader["role"]));
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return user;
        }

        public Users GetUserByIdDAL(int id)
        {
            Users user = null;
            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            try
            {
                // Open the connection
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                // Add the parameters
                command.Parameters.AddWithValue("@id", id);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new Users((int)reader["id"], (byte[]?)reader["profilePicture"], (string)reader["firstName"], (string)reader["lastName"],
                        (DateTime)reader["birthdate"], (string)reader["username"], (string)reader["email"], (string)reader["phoneNumber"], (string)reader["role"]);
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return user;
        }

        public bool BanUserDAL(Users banUser, string reason)
        {
            string query = $"INSERT INTO Banned " +
                           $"(reason, userId) " +
                           $"VALUES (@reason, @userId)";

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, Connection.connection);
                command.Parameters.AddWithValue("@userId", banUser.Id);
                command.Parameters.AddWithValue("@reason", reason);

                using SqlDataReader reader = command.ExecuteReader();
                return true;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                connection.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public bool UnbanUserDAL(Users bannedUser)
        {
            // Set up the query
            string query = $"DELETE FROM Banned WHERE userId = @userId";

            try
            {

                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                // Add the parameters
                command.Parameters.AddWithValue("@userId", bannedUser.Id);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                return true;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public bool IsUserBannedDAL(Users bannedUser)
        {
            string query = $"SELECT reason, userId FROM Banned JOIN Users ON Banned.userId = Users.id WHERE Users.id = @id";

            try
            {
                // Open the connection
                connection.Open();

                SqlCommand command = new SqlCommand(query, Connection.connection);
                // Add the parameters
                command.Parameters.AddWithValue("@id", bannedUser.Id);


                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (!reader.Read())
                {
                    return false;
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public bool IsUsernameUsedDAL(string username)
        {
            string query = $"SELECT * FROM {tableName} WHERE username = @username";

            try
            {
                // Open the connection
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                // Add the parameters
                command.Parameters.AddWithValue("@username", username);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return true;
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public bool IsEmailUsedDAL(string email)
        {
            string query = $"SELECT * FROM {tableName} WHERE email = @email";


            try
            {
                // Open the connection
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                // Add the parameters
                command.Parameters.AddWithValue("@email", email);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return true;
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public bool DeleteUserDAL(int id)
        {
            // Set up the query
            string query = $"DELETE FROM {tableName} WHERE id = @id";
            if (IsUserBannedDAL(GetUserByIdDAL(id)))
            {
                UnbanUserDAL(GetUserByIdDAL(id));
            }
            
            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                // Add the parameters
                command.Parameters.AddWithValue("@id", id);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                return true;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public Users GetUserByUsernameDAL(string username)
        {
            Users user = null;
            string query = $"SELECT * FROM {tableName} WHERE username = @username";

            try
            {
                // Open the connection
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                // Add the parameters
                command.Parameters.AddWithValue("@username", username);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new Users((int)reader["id"], (byte[]?)reader["profilePicture"], (string)reader["firstName"], (string)reader["lastName"],
                        (DateTime)reader["birthdate"], (string)reader["username"], (string)reader["email"], (string)reader["phoneNumber"], (string)reader["role"]);
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return user;
        }
        public List<Users> GetAllUsersDAL()
        {
            string query = $"SELECT * FROM {tableName}";

            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                List<Users> users = new List<Users>();

                while (reader.Read())
                {
                    users.Add(new Users((int)reader["id"], (byte[]?)reader["profilePicture"], (string)reader["firstName"], (string)reader["lastName"], 
                        (DateTime)reader["birthdate"], (string)reader["username"], (string)reader["email"], 
                        !string.IsNullOrEmpty(reader["phoneNumber"].ToString()) ? (string)reader["phoneNumber"] : null, (string)reader["role"]));
                }
                reader.Close();
                return users;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return new List<Users>();
        }
        public bool UpdateUserDAL(UpdateUserDTO updateUser)
        {
            string query =
                $"UPDATE {tableName} " +
                $"SET username = @username, profilePicture = @profilePicture, firstName = @firstName, lastName = @lastName, email = @email, birthdate = @birthday, passwordHash = @passwordHash, " +
                $"passwordSalt = @passwordSalt, phoneNumber = @phoneNumber, role = @role " +
                $"WHERE id = @id";

            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);
                // Add the parameters
                command.Parameters.AddWithValue("@id", updateUser.Id);
                command.Parameters.AddWithValue("@username", updateUser.Username);
                command.Parameters.AddWithValue("@profilePicture", updateUser.ProfilePicture);
                command.Parameters.AddWithValue("@firstName", updateUser.FirstName);
                command.Parameters.AddWithValue("@lastName", updateUser.LastName);
                command.Parameters.AddWithValue("@email", updateUser.Email);
                command.Parameters.AddWithValue("@birthday", updateUser.Birthday);
                command.Parameters.AddWithValue("@phoneNumber", updateUser.PhoneNumber);
                command.Parameters.AddWithValue("@passwordHash", updateUser.PasswordHash);
                command.Parameters.AddWithValue("@passwordSalt", updateUser.PasswordSalt);
                command.Parameters.AddWithValue("@role", updateUser.Role);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();

                connection.Close();
                return true;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public UpdateUserDTO GetUserForUpdateDTODAL(int id)
        {
            UpdateUserDTO user = null;
            string query = $"SELECT * FROM {tableName} WHERE id = @id";


            try
            {
                // Open the connection
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                // Add the parameters
                command.Parameters.AddWithValue("@id", id);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new UpdateUserDTO((int)reader["id"], (byte[]?)reader["profilePicture"], (string)reader["firstName"], (string)reader["lastName"], 
                        (DateTime)reader["birthdate"], (string)reader["username"], (string)reader["email"], (string)reader["password"],
                        !string.IsNullOrEmpty(reader["phoneNumber"].ToString()) ? (string)reader["phoneNumber"] : null, 
                        (string)reader["role"]);
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return user;
        }
        public Tuple<string, string> hashSaltDAL(string username)
        {
            string query = $"SELECT passwordHash, passwordSalt FROM {tableName} WHERE username = @username";
            Tuple<string, string> hashSalt = null;
            try
            {
                // Open the connection
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                // Add the parameters
                command.Parameters.AddWithValue("@username", username);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    hashSalt = new Tuple<string, string>((string)reader["passwordHash"], (string)reader["passwordSalt"]);
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return hashSalt;
        }
    }
}
