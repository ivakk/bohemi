using Classes;
using DTOs;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Data;
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
            string query = $"SELECT Soft.id, picture, name, size, price, carbonated FROM {tableName} " +
                           $"JOIN Drinks ON Soft.id = Drinks.id WHERE Soft.id = @id";

            // Using block for managing the connection
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        // Execute the query
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                newSoft = new Soft(
                                    (int)reader["id"],
                                    (byte[]?)reader["picture"],
                                    (string)reader["name"],
                                    (int)reader["size"],
                                    (decimal)reader["price"],
                                    (string)reader["carbonated"]);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    // Handle SQL-specific errors
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                catch (Exception ex)
                {
                    // Handle general errors
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
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

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                softs.Add(new Soft(
                                    (int)reader["id"],
                                    (byte[]?)reader["picture"],
                                    (string)reader["name"],
                                    (int)reader["size"],
                                    (decimal)reader["price"],
                                    (string)reader["carbonated"]));
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    // Handle SQL-specific errors
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                catch (Exception ex)
                {
                    // Handle general errors
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
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
        public async Task<List<Soft>> GetPaginationSoftsDALAsync(int pageNumber, int pageSize)
        {
            List<Soft> softs = new List<Soft>();
            string query = $@"
                SELECT Soft.id, picture, name, size, price, carbonated 
                FROM {tableName} JOIN Drinks ON Soft.id = Drinks.id
                ORDER BY Soft.id
                OFFSET @Offset ROWS 
                FETCH NEXT @PageSize ROWS ONLY;";

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            softs.Add(new Soft((int)reader["id"], (byte[]?)reader["picture"], (string)reader["name"], (int)reader["size"], (decimal)reader["price"],
                                    (string)reader["carbonated"]));
                        }
                    }
                }
            }
            return softs;
        }
        public async Task<int> GetTotalSoftsCountDALAsync()
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    int count = (int)await command.ExecuteScalarAsync();
                    return count;
                }
            }
        }
        public bool LikeSoftDAL(LikedBeverage likedDrink)
        {
            return base.LikeBeverageDAL(likedDrink);
        }
        public bool RemoveFromLikedSoftsDAL(LikedBeverage likedDrink)
        {
            return base.RemoveFromLikedBeveragesDAL(likedDrink);
        }
        public bool IsSoftLikedDAL(LikedBeverage likedDrink)
        {
            return base.IsBeverageLikedDAL(likedDrink);
        }
    }
}
