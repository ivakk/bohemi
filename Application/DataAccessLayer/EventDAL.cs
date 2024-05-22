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
    public class EventDAL : Connection, IEventDAL
    {
        private readonly string tableName = "Events";

        public bool CreateEventDAL(EventDTO newEvent)
        {
            // Set up the query
            string query = $"INSERT INTO {tableName} " +
                           $"(title, description, day, picture) " +
                           $"VALUES (@title, @description, @day, @picture)";

            try
            {
                // Open the connection
                connection.Open();
                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);
                command.Parameters.AddWithValue("@title", newEvent.Title);
                command.Parameters.AddWithValue("@description", newEvent.Description);
                command.Parameters.AddWithValue("@day", newEvent.Day);
                command.Parameters.AddWithValue("@picture", newEvent.Picture);

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
        public Event GetEventByIdDAL(int id)
        {
            Event newEvent = null;
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
                    newEvent = new Event((int)reader["id"], (string)reader["title"], (string)reader["description"], (DateTime)reader["day"], (byte[]?)reader["picture"]);
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
            return newEvent;
        }
        public void DeleteEventDAL(int id)
        {
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
        public List<Event> GetAllEventsDAL()
        {
            string query = $"SELECT * FROM {tableName}";
            List<Event> events = new List<Event>();

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
                    events.Add(new Event((int)reader["id"], (string)reader["title"], (string)reader["description"], (DateTime)reader["day"], (byte[]?)reader["picture"]));
                }
                reader.Close();
                return events;
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
            return events;
        }
        public bool UpdateEventDAL(EventDTO updateEvent)
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
