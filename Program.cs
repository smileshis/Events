using System;
using EventManagementLibrary;

class Program
{
    static void Main(string[] args)
    {
        // Створюємо об'єкти Event
        Event event1 = new Event("Conference", new DateTime(2024, 12, 25, 10, 0, 0), "Kyiv");
        Event event2 = new Event("Workshop", new DateTime(2024, 12, 26, 14, 0, 0), "Lviv");

        // Створюємо менеджер подій
        EventManager eventManager = new EventManager();

        // Додаємо заходи
        eventManager.AddEvent(event1);
        eventManager.AddEvent(event2);

        // Отримуємо список заходів через GetAllEvents
        foreach (Event @event in eventManager.GetAllEvents())
        {
            Console.WriteLine($"Name = {@event.Name}, Date = {@event.Date}, Location = {@event.Location}");
        }
    }
}
