using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesDAL;
using Classes;
using DTOs;

namespace DataAccessLayer
{
    public class BeverageDAL : Connection, IBeverageDAL
    {
        private readonly string tableName = "Drinks";

        public int GetNextId()
        {
            string query = $"SELECT IDENT_CURRENT('{tableName}')";
            int id = 0;
            // Open the connection
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader.GetValue(0));
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return id;
        }
        public bool CreateBeverageDAL(BeverageDTO newBeverage)
        {
            // Set up the query
            string query = $"INSERT INTO {tableName} " +
                           $"(picture, name, size, price) " +
                           $"VALUES (@picture, @name, @size, @price)";

            try
            {
                // Open the connection
                connection.Open();
                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);
                command.Parameters.AddWithValue("@picture", newBeverage.Picture);
                command.Parameters.AddWithValue("@name", newBeverage.Name);
                command.Parameters.AddWithValue("@size", newBeverage.Size);
                command.Parameters.AddWithValue("@price", newBeverage.Price);

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
        public void DeleteBeverageDAL(int id)
        {
            // Set up the query
            string query = $"DELETE FROM {tableName} WHERE id = @id";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            // Add the parameters
            command.Parameters.AddWithValue("@id", id);

            try
            {
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
        public bool UpdateBeverageDAL(BeverageDTO updateBeverage)
        {
            string query =
                $"UPDATE {tableName} " +
                $"SET picture = @picture, name = @name, size = @size, price = @price " +
                $"WHERE id = @id";

            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                // Add the parameters
                command.Parameters.AddWithValue("@id", updateBeverage.Id);
                command.Parameters.AddWithValue("@picture", updateBeverage.Picture);
                command.Parameters.AddWithValue("@name", updateBeverage.Name);
                command.Parameters.AddWithValue("@size", updateBeverage.Size);
                command.Parameters.AddWithValue("@price", updateBeverage.Price );

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
