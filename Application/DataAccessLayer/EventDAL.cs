﻿using Classes;
using DTOs;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
        public Event GetEventByIdDAL(int id)
        {
            Event newEvent = null;
            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                newEvent = new Event(
                                    (int)reader["id"],
                                    (string)reader["title"],
                                    (string)reader["description"],
                                    (DateTime)reader["day"],
                                    (byte[]?)reader["picture"]);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine (ex.Message);
            }
            
            return newEvent;
        }

        public bool DeleteEventDAL(int id)
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
        public List<Event> GetAllEventsDAL()
        {
            List<Event> events = new List<Event>();
            string query = $"SELECT * FROM {tableName}";
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                events.Add(new Event(
                                    (int)reader["id"],
                                    (string)reader["title"],
                                    (string)reader["description"],
                                    (DateTime)reader["day"],
                                    (byte[]?)reader["picture"]));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
            }
            catch (Exception ex) 
            {
                Debug.WriteLine (ex.Message);
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
        public bool LikeEventDAL(LikedEvent likedEvent)
        {
            string query = $"INSERT INTO LikedEvents " +
                           $"(userId, eventId) " +
                           $"VALUES (@userId, @eventId)";
            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                // Add the parameters
                command.Parameters.AddWithValue("@userId", likedEvent.UserId);
                command.Parameters.AddWithValue("@eventId", likedEvent.EventId);

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
        public bool RemoveFromLikedEventsDAL(LikedEvent likedEvent)
        {
            string query = $"DELETE FROM LikedEvents " +
                $"WHERE eventId = @eventId AND userId = @userId";

            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                // Add the parameters
                command.Parameters.AddWithValue("@eventId", likedEvent.EventId);
                command.Parameters.AddWithValue("@userId", likedEvent.UserId);
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
        public bool IsEventLikedDAL(LikedEvent likedEvent)
        {
            string query = $"SELECT * FROM LikedEvents " +
                $"WHERE userId = @userId AND eventId = @eventId";

            try
            {
                // Open the connection
                connection.Open();

                // Creating Command string to combine the query and the connection String
                SqlCommand command = new SqlCommand(query, Connection.connection);

                command.Parameters.AddWithValue("@eventId", likedEvent.EventId);
                command.Parameters.AddWithValue("@userId", likedEvent.UserId);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return true;
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
            return false;
        }
        public async Task<List<Event>> GetPaginationEventsDALAsync(int pageNumber, int pageSize, string? searchTerm)
        {
            List<Event> events = new List<Event>();
            string query = $@"
                SELECT * FROM {tableName}
                WHERE Events.title LIKE @searchTerm
                ORDER BY day DESC
                OFFSET @Offset ROWS 
                FETCH NEXT @PageSize ROWS ONLY;";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                        command.Parameters.AddWithValue("@PageSize", pageSize);
                        command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                        await connection.OpenAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                events.Add(new Event(
                                    (int)reader["id"],
                                    (string)reader["title"],
                                    (string)reader["description"],
                                    (DateTime)reader["day"],
                                    (byte[]?)reader["picture"]));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
            return events;
        }
        public async Task<int> GetTotalEventsCountDALAsync(string? searchTerm)
        {
            string query = $"SELECT COUNT(*) FROM {tableName} WHERE Events.title LIKE @searchTerm";
            int count = 0;
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                        count = (int)await command.ExecuteScalarAsync();
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return count;
        }
        public List<Event> GetFirstEventsDAL(int count)
        {
            List<Event> events = new List<Event>();
            string query = $"SELECT TOP {count} * FROM {tableName} ORDER BY day DESC";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                events.Add(new Event(
                                    (int)reader["id"],
                                    (string)reader["title"],
                                    (string)reader["description"],
                                    (DateTime)reader["day"],
                                    (byte[]?)reader["picture"]));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
            return events;
        }
        public List<LikedEvent> GetAllLikedEventsDAL()
        {
            string query = $"SELECT * FROM LikedEvents";
            List<LikedEvent> events = new List<LikedEvent>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                events.Add(new LikedEvent((int)reader["userId"], (int)reader["eventId"]));
                            }
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
            return events;
        }
        public async Task<List<Event>> GetUserLikedEventsDALAsync(int pageNumber, int pageSize, int userId)
        {
            List<Event> events = new List<Event>();
            string query = $@"
                SELECT Events.id, Events.title, Events.description, Events.day, Events.picture 
                FROM {tableName} JOIN LikedEvents ON Events.id = LikedEvents.eventId
                WHERE LikedEvents.userId = @userId
                ORDER BY day DESC
                OFFSET @Offset ROWS 
                FETCH NEXT @PageSize ROWS ONLY;";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                        command.Parameters.AddWithValue("@PageSize", pageSize);
                        command.Parameters.AddWithValue("@userId", userId);

                        await connection.OpenAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                events.Add(new Event(
                                    (int)reader["id"],
                                    (string)reader["title"],
                                    (string)reader["description"],
                                    (DateTime)reader["day"],
                                    (byte[]?)reader["picture"]));
                            }
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
            return events;
        }

        public async Task<int> GetUserLikedEventsCountDALAsync(int userId)
        {
            string query = $"SELECT COUNT(*) FROM LikedEvents WHERE userId = @userId";
            int count = 0;

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        count = (int)await command.ExecuteScalarAsync();
                    }
                }
            }
            catch(SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return count;
        }
    }
}
