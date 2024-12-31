using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManagementLibrary
{
    public class EventManager
    {
        private readonly List<Event> _events = new List<Event>();

        public void AddEvent(Event eventInstance)
        {
            if (_events.Any(e => e.Name == eventInstance.Name && e.Date == eventInstance.Date))
                throw new InvalidOperationException("Захід із такою ж назвою і датою вже існує.");
            _events.Add(eventInstance);
        }

        public void RemoveEvent(string eventName)
        {
            var eventToRemove = _events.FirstOrDefault(e => e.Name == eventName);
            if (eventToRemove == null)
                throw new KeyNotFoundException("Захід із заданою назвою не знайдено.");
            _events.Remove(eventToRemove);
        }

        public IReadOnlyList<Event> GetAllEvents()
        {
            return _events.AsReadOnly();
        }
    }
}

