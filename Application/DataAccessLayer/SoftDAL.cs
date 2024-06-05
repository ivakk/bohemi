using Classes;
using DTOs;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SoftDAL : BeverageDAL, ISoftDAL
    {
        private readonly string tableName = "Soft";

        public bool CreateSoftDAL(SoftDTO newSoft)
        {
            base.CreateBeverageDAL(newSoft);

            // Set up the query
            string query = $"INSERT INTO {tableName} JOIN Drinks " +
                           $"(id, carbonated) " +
                           $"VALUES (@id, @carbonated)";

            try
            {
                // Open the connection
                connection.Open();
                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);
                command.Parameters.AddWithValue("@id", GetNextId());
                command.Parameters.AddWithValue("@carbonated", newSoft.Carbonated);

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
        public Soft GetSoftByIdDAL(int id)
        {
            Soft newSoft = null;
            string query = $"SELECT Soft.id, picture, name, size, price, carbonated FROM {tableName} JOIN Drinks ON Soft.id = Drinks.id WHERE id = @id";

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
                    newSoft = new Soft((int)reader["id"], (byte[]?)reader["picture"], (string)reader["name"], (int)reader["size"], (decimal)reader["price"],
                        (string)reader["carbonated"]);
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
            return newSoft;
        }
        public bool DeleteSoftDAL(int id)
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
        public List<Soft> GetAllSoftDAL()
        {
            string query = $"SELECT Soft.id, picture, name, size, price, carbonated FROM {tableName} JOIN Drinks ON Soft.id = Drinks.id";
            List<Soft> softs = new List<Soft>();

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
                    softs.Add(new Soft((int)reader["id"], (byte[]?)reader["picture"], (string)reader["name"], (int)reader["size"], (decimal)reader["price"],
                        (string)reader["carbonated"]));
                }
                reader.Close();
                return softs;
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
            return softs;
        }
        public bool UpdateSoftDAL(SoftDTO updateSoft)
        {
            base.UpdateBeverageDAL(updateSoft);

            string query =
                $"UPDATE {tableName} " +
                $"SET carbonated = @carbonated " +
                $"WHERE id = @id";

            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                // Add the parameters
                command.Parameters.AddWithValue("@id", updateSoft.Id);
                command.Parameters.AddWithValue("@carbonated", updateSoft.Carbonated);

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
