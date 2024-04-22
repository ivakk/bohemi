using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesDAL;
using Classes;
using DTOs;

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

            // Open the connection
            connection.Open();
            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
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
            finally
            {
                connection.Close();
            }
        }

        public LoginDTO GetUserForDTODAL(string username, string password)
        {
            LoginDTO user = null;
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
                    user = new LoginDTO((int)reader["id"], (string)reader["username"], password,
                        (string)reader["passwordHash"], (string)reader["passwordSalt"], (string)reader["role"]);
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
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
            finally
            {
                connection.Close();
            }
            return user;
        }
    }
}
