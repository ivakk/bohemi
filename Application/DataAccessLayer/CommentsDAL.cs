using Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesDAL;
using DTOs;

namespace DataAccessLayer
{
    public class CommentsDAL : Connection, ICommentsDAL
    {
        private readonly string tableName = "Comments";

        public Comments GetCommentByIdDAL(int id)
        {
            string query = $"SELECT * FROM {tableName} WHERE id = @id";
            Comments comment = null;

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
                    comment = new Comments((int)reader["id"], (int)reader["userId"], (int)reader["eventId"], (DateTime)reader["comDate"], (string)reader["information"]);
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
            return comment;
        }

        /**
        * Query that gets all comments
        */
        public List<Comments> GetAllCommentsDAL(int eventId)
        {
            string query = $"SELECT {tableName}.id, userId, eventId, comDate, information FROM {tableName} " +
                $"JOIN Events ON Events.id = {tableName}.eventId " +
                $"WHERE Comments.eventId = @id";


            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                command.Parameters.AddWithValue("@id", eventId);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                List<Comments> comments = new List<Comments>();

                while (reader.Read())
                {
                    comments.Add(new Comments((int)reader["id"], (int)reader["userId"], (int)reader["eventId"], (DateTime)reader["comDate"], (string)reader["information"]));
                }
                return comments;
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
            return new List<Comments>();
        }

        public bool CreateCommentDAL(CommentsDTO comment)
        {
            // Set up the query
            string query = $"INSERT INTO {tableName} " +
                           $"(userId, eventId, information, comDate) " +
                           $"VALUES (@userId, @eventId, @information, @comDate)";

            try
            {
                // Open the connection
                connection.Open();
                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                command.Parameters.AddWithValue("@userId", comment.UserId);
                command.Parameters.AddWithValue("@mediaId", comment.EventId);
                command.Parameters.AddWithValue("@information", comment.Information);
                command.Parameters.AddWithValue("@comDate", comment.CommentDate);

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

        public bool DeleteCommentDAL(int id)
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

        public string GetCommentUserDAL(int id)
        {
            string query = $"SELECT Users.username FROM {tableName} JOIN Users ON Users.id = {tableName}.userId WHERE {tableName}.id = @id";
            string commenter = null;

            try
            {
                connection.Open();
                

                SqlCommand command = new SqlCommand(query, Connection.connection);
                command.Parameters.AddWithValue("@id", id);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    commenter = new string((string)reader["username"]);
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
            return commenter;
        }
    }
}
