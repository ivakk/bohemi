using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AlcoholDAL : BeverageDAL
    {
        private readonly string tableName = "Alcohol";

        public bool CreateAlcoholDAL(AlcoholDTO newAlcohol)
        {
            base.CreateBeverageDAL(newAlcohol);
            
            // Set up the query
            string query = $"INSERT INTO {tableName} JOIN Drinks " +
                           $"(id, percentage, age) " +
                           $"VALUES (@picture, @description, @day, @picture)";

            try
            {
                // Open the connection
                connection.Open();
                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);
                command.Parameters.AddWithValue("@id", GetNextId());
                command.Parameters.AddWithValue("@percentage", newAlcohol.Percentage);
                command.Parameters.AddWithValue("@age", newAlcohol.Age);

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
        public Alcohol GetAlcoholByIdDAL(int id)
        {
            Alcohol newAlcohol = null;
            string query = $"SELECT Alcohol.id, picture, name, size, price, percentage, age FROM {tableName} JOIN Drinks ON Alcohol.id = Drinks.id WHERE id = @id";

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
                    newAlcohol = new Alcohol((int)reader["id"], (byte[]?)reader["picture"], (string)reader["name"], (int)reader["size"], (double)reader["price"],
                        (int)reader["percentage"], (int)reader["age"]);
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
            return newAlcohol;
        }
        public void DeleteAlcoholDAL(int id)
        {
            base.DeleteBeverageDAL(id);
            // Set up the query
            string query = $"DELETE FROM {tableName} WHERE id = @id";

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
        }
        public List<Alcohol> GetAllAlcoholsDAL()
        {
            string query = $"SELECT Alcohol.id, picture, name, size, price, percentage, age FROM {tableName} JOIN Drinks ON Alcohol.id = Drinks.id";
            List<Alcohol> alcohols = new List<Alcohol>();

            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    alcohols.Add(new Alcohol((int)reader["id"], (byte[]?)reader["picture"], (string)reader["name"], (int)reader["size"], (double)reader["price"],
                        (int)reader["percentage"], (int)reader["age"]));
                }
                reader.Close();
                return alcohols;
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
            return alcohols;
        }
        public bool UpdateEventDAL(AlcoholDTO updateEvent)
        {
            string query =
                $"UPDATE {tableName} " +
                $"SET title = @title, description = @description, day = @day, picture = @picture " +
                $"WHERE id = @id";

            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                // Add the parameters
                command.Parameters.AddWithValue("@id", updateEvent.Id);
                command.Parameters.AddWithValue("@title", updateEvent.Title);
                command.Parameters.AddWithValue("@description", updateEvent.Description);
                command.Parameters.AddWithValue("@day", updateEvent.Day);
                command.Parameters.AddWithValue("@picture", updateEvent.Picture);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();

                connection.Close();
                return true;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
                connection.Close();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
