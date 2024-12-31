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

        [Fact]
        public void AddEvent_ShouldThrowException_WhenDuplicateEventAdded() // Тест для перевірки дублювання.
        {
            var eventInstance = new Event("Conference", new DateTime(2024, 12, 25, 10, 0, 0), "Kyiv"); // Захід.
            _eventManager.AddEvent(eventInstance); // Додаємо захід.

            var exception = Assert.Throws<InvalidOperationException>(() => _eventManager.AddEvent(eventInstance)); // Перевіряємо дублювання.
            Assert.Equal("Захід із такою ж назвою і датою вже існує.", exception.Message); // Перевіряємо повідомлення виключення.
        }
        [Fact]
        public void RemoveEvent_ShouldRemoveEventFromLibrary() // Тест для перевірки видалення заходу.
        {
            var eventInstance = new Event("Conference", new DateTime(2024, 12, 25, 10, 0, 0), "Kyiv"); // Захід.
            _eventManager.AddEvent(eventInstance); // Додаємо захід.

            _eventManager.RemoveEvent("Conference"); // Видаляємо захід.

            var events = _eventManager.GetAllEvents(); // Отримуємо список заходів.
            Assert.DoesNotContain(eventInstance, events); // Перевіряємо, що захід видалено.
        }
        [Fact]
        public void RemoveEvent_ShouldThrowException_WhenEventDoesNotExist() // Тест для перевірки видалення неіснуючого заходу.
        {
            var exception = Assert.Throws<KeyNotFoundException>(() => _eventManager.RemoveEvent("NonExistentEvent")); // Перевіряємо виключення.
            Assert.Equal("Захід із заданою назвою не знайдено.", exception.Message); // Перевіряємо повідомлення виключення.
        }
    }
}