using System;
using Xunit;
using EventManagementLibrary;

namespace EventManagementTests
{
    public class EventManagerTests
    {
        private readonly EventManager _eventManager;

        public EventManagerTests()
        {
            _eventManager = new EventManager();
        }

        [Fact]
        public void AddEvent_ShouldAddEventToLibrary()
        {
            // Arrange
            var eventInstance = new Event("Conference", new DateTime(2024, 12, 25, 10, 0, 0), "Kyiv");

            // Act
            _eventManager.AddEvent(eventInstance);

            // Assert
            var events = _eventManager.GetAllEvents();
            Assert.Contains(eventInstance, events);
        }
    }
}