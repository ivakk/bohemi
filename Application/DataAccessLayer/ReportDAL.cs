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
    public class ReportDAL : Connection, IReportDAL
    {
        private readonly string tableName = "Reports";

        public Report GetReportByIdDAL(int id)
        {
            string query = $"SELECT * FROM {tableName} WHERE id = @id";
            Report report = null;

            try
            {
                // Open the connection
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand(query, Connection.connection);
                // Add the parameters
                command.Parameters.AddWithValue("@id", id);
                using SqlDataReader reader = command.ExecuteReader();
                // Execute the query and get the data
                while (reader.Read())
                {
                    report = new Report((int)reader["id"], (int)reader["commentId"], (int)reader["reporterId"], (string)reader["reader"]);
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
            return report;
        }

        /**
        * Query that gets all reports
        */
        public List<Report> GetAllReportsDAL()
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
                List<Report> reports = new List<Report>();

                while (reader.Read())
                {
                    reports.Add(new Report((int)reader["id"], (int)reader["commentId"], (int)reader["reporterId"], (string)reader["information"]));
                }
                return reports;
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
            return new List<Report>();
        }

        public bool CreateReportDAL(Report report)
        {
            // Set up the query
            string query = $"INSERT INTO {tableName} " +
                           $"(id, commentId, reporterId, information) " +
                           $"VALUES (@id, @commentId, @reporterId, @information)";

            try
            {
                // Open the connection
                connection.Open();
                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                command.Parameters.AddWithValue("@id", report.Id);
                command.Parameters.AddWithValue("@commentId", report.CommentId);
                command.Parameters.AddWithValue("@reporterId", report.ReporterId);
                command.Parameters.AddWithValue("@information", report.Information);

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

        public bool DeleteReportDAL(int id)
        {
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
    }
}
