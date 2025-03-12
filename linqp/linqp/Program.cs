
using System;
using System.Collections.Generic;
using System.Linq;


class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}
class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>
        {
            new Person { Name = "Anwar", Age = 30, City = "Kottakkal" },
            new Person { Name = "Aisha", Age = 28, City = "Kottakkal" },
            new Person { Name = "John", Age = 22, City = "Kochi" },
            new Person { Name = "Mary", Age = 35, City = "Kottakkal" },
            new Person { Name = "Rahul", Age = 40, City = "Kochi" }
        };

        var filteredPeople = people
            .Where(p => p.Age > 25 && p.City == "Kottakkal")
            .Select(p => new { p.Name, p.Age })
            .ToList();

        Console.WriteLine("People above 25 from Kottakkal:");
        foreach (var person in filteredPeople)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}
