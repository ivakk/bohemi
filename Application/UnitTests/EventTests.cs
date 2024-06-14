using Classes;
using DTOs;
using InterfacesDAL;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockDAL;

namespace UnitTests
{
    public class EventTests
    {
        [Fact]
        public void CreateEvent_ValidEvent_ReturnsTrue()
        {
            // Arrange
            var newEvent = new EventDTO(1, "New Event", "Event Description", DateTime.Now, new byte[0]);
            IEventDAL _mockEventDAL = new MockEventDAL();
            EventService _eventService = new EventService(_mockEventDAL);

            // Act
            var result = _eventService.CreateEvent(newEvent);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CreateEvent_InvalidEvent_ReturnsFalse()
        {
            // Arrange
            EventDTO newEvent = null;
            IEventDAL _mockEventDAL = new MockEventDAL();
            EventService _eventService = new EventService(_mockEventDAL);

            // Act
            var result = _eventService.CreateEvent(newEvent);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DeleteEvent_ValidId_ReturnsTrue()
        {
            // Arrange
            int eventId = 1;
            IEventDAL _mockEventDAL = new MockEventDAL();
            EventService _eventService = new EventService(_mockEventDAL);

            // Act
            var result = _eventService.DeleteEvent(eventId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteEvent_InvalidId_ReturnsFalse()
        {
            // Arrange
            int eventId = -1;
            IEventDAL _mockEventDAL = new MockEventDAL();
            EventService _eventService = new EventService(_mockEventDAL);

            // Act
            var result = _eventService.DeleteEvent(eventId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAllEvents_ReturnsListOfEvents()
        {
            // Arrange
            IEventDAL _mockEventDAL = new MockEventDAL();
            EventService _eventService = new EventService(_mockEventDAL);

            // Act
            var result = _eventService.GetAllEvents();

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetEventById_ValidId_ReturnsEvent()
        {
            // Arrange
            int eventId = 1;
            var eventObj = new Event(eventId, "Title", "Description", DateTime.Now, new byte[0]);
            IEventDAL _mockEventDAL = new MockEventDAL();
            EventService _eventService = new EventService(_mockEventDAL);

            // Act
            var result = _eventService.GetEventById(eventId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(eventId, result.Id);
        }

        [Fact]
        public void GetEventById_InvalidId_ThrowsException()
        {
            // Arrange
            int eventId = -1;
            IEventDAL _mockEventDAL = new MockEventDAL();
            EventService _eventService = new EventService(_mockEventDAL);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _eventService.GetEventById(eventId));
        }

        [Fact]
        public void UpdateEvent_ValidEvent_ReturnsTrue()
        {
            // Arrange
            var updateEvent = new EventDTO(1, "Updated Event", "Updated Description", DateTime.Now, new byte[0]);
            IEventDAL _mockEventDAL = new MockEventDAL();
            EventService _eventService = new EventService(_mockEventDAL);

            // Act
            var result = _eventService.UpdateEvent(updateEvent);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateEvent_InvalidEvent_ReturnsFalse()
        {
            // Arrange
            EventDTO updateEvent = null;
            IEventDAL _mockEventDAL = new MockEventDAL();
            EventService _eventService = new EventService(_mockEventDAL);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _eventService.UpdateEvent(updateEvent));
        }
    }
}
