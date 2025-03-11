
using System;

class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Speak()
    {
        Console.WriteLine($"My name is {Name} and I am {Age} years old.");
    }
}

class Dog : Animal
{
    public string Breed { get; set; }

    public Dog(string name, int age, string breed) : base(name, age)
    {
        Breed = breed;
    }

    public override void Speak()
    {
        Console.WriteLine($"My name is {Name}, I am {Age} years old, and I am a {Breed}.");
    }
}

class Cat : Animal
{
    public Cat(string name, int age) : base(name, age) { }

    public void Meow()
    {
        Console.WriteLine("Meow!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog("puppy", 6, "pit bull");
        dog.Speak(); 
        Cat cat = new Cat("tom", 3);
        cat.Speak(); 
        cat.Meow();  
    }
}
