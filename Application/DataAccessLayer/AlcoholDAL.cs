using Classes;
using DTOs;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AlcoholDAL : BeverageDAL, IAlcoholDAL
    {
        private readonly string tableName = "Alcohol";

        public bool CreateAlcoholDAL(AlcoholDTO newAlcohol)
        {
            // First, create a base beverage entry
            base.CreateBeverageDAL(newAlcohol);

            // Set up the query for alcohol-specific details
            string query = $"INSERT INTO {tableName} (id, percentage, age) " +
                           $"VALUES (@id, @percentage, @age)";

            // Using block for managing the connection
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Create SqlCommand inside a using block
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use Add instead of AddWithValue to specify the type explicitly
                        command.Parameters.Add("@id", SqlDbType.Int).Value = GetNextId(); // Assuming GetNextId returns an int
                        command.Parameters.Add("@percentage", SqlDbType.Decimal).Value = newAlcohol.Percentage;
                        command.Parameters.Add("@age", SqlDbType.Int).Value = newAlcohol.Age;

                        // Execute the command
                        command.ExecuteNonQuery();

                        return true;
                    }
                }
                catch (SqlException e)
                {
                    // Handle SQL-specific errors
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    // Handle general errors
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public Alcohol GetAlcoholByIdDAL(int id)
        {
            Alcohol newAlcohol = null;
            string query = $"SELECT Alcohol.id, picture, name, size, price, percentage, age FROM {tableName} JOIN Drinks ON Alcohol.id = Drinks.id WHERE Alcohol.id = @id";

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
                    newAlcohol = new Alcohol((int)reader["id"], reader["picture"] != DBNull.Value ? (byte[]?)reader["picture"] : null, (string)reader["name"], (int)reader["size"], (decimal)reader["price"],
                        (int)reader["percentage"], (int)reader["age"]);
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
            return newAlcohol;
        }
        public bool DeleteAlcoholDAL(int id)
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
                    alcohols.Add(new Alcohol((int)reader["id"], reader["picture"] != DBNull.Value ? (byte[]?)reader["picture"] : null, (string)reader["name"], (int)reader["size"], (decimal)reader["price"],
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return alcohols;
        }
        public bool UpdateAlcoholDAL(AlcoholDTO updateAlcohol)
        {
            base.UpdateBeverageDAL(updateAlcohol);

            string query =
                $"UPDATE {tableName} " +
                $"SET percentage = @percentage, age = @age " +
                $"WHERE id = @id";

            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                // Add the parameters
                command.Parameters.AddWithValue("@id", updateAlcohol.Id);
                command.Parameters.AddWithValue("@title", updateAlcohol.Percentage);
                command.Parameters.AddWithValue("@description", updateAlcohol.Age);

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
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
