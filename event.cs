using System;

namespace EventManagementLibrary
{
    public class Event
    {
        public string Name { get; }
        public DateTime Date { get; }
        public string Location { get; }

        public Event(string name, DateTime date, string location)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва не може бути порожньою.", nameof(name));

            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Локація не може бути порожньою.", nameof(location));

            Name = name;
            Date = date;
            Location = location;
        }
    }
}


