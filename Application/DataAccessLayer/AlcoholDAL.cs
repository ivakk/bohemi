using Classes;
using DTOs;
using InterfacesDAL;
using System;
using System.Collections.Generic;
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
            base.CreateBeverageDAL(newAlcohol);
            
            // Set up the query
            string query = $"INSERT INTO {tableName} JOIN Drinks " +
                           $"(id, percentage, age) " +
                           $"VALUES (@id, @percentage, @age)";

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
