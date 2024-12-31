using System;
using Xunit;
using EventManagementLibrary;

namespace EventManagementTests
{
    public class EventTests
    {
        [Fact]
        public void CreateEvent_ShouldInitializeCorrectly()
        {
            // Arrange
            var name = "Conference";
            var date = new DateTime(2024, 12, 25, 10, 0, 0);
            var location = "Kyiv";

            // Act
            var eventInstance = new Event(name, date, location);

            // Assert
            Assert.Equal(name, eventInstance.Name);
            Assert.Equal(date, eventInstance.Date);
            Assert.Equal(location, eventInstance.Location);
        }

        [Theory]
        [InlineData(null, "Kyiv")]
        [InlineData("", "Kyiv")]
        [InlineData("Conference", null)]
        [InlineData("Conference", "")]
        public void CreateEvent_ShouldThrowException_WhenNameOrLocationIsInvalid(string name, string location)
        {
            // Arrange
            var date = new DateTime(2024, 12, 25, 10, 0, 0);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Event(name, date, location));
        }
    }
}