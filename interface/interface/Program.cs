using System;

interface Shape
{
    double GetArea();
}

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }
}

class Square : Shape
{
    public double Side { get; set; }

    public Square(double side)
    {
        Side = side;
    }

    public double GetArea()
    {
        return Side * Side;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Circle circle = new Circle(5);
        Console.WriteLine("Area of Circle: " + circle.GetArea());

        Rectangle rectangle = new Rectangle(4, 6);
        Console.WriteLine("Area of Rectangle: " + rectangle.GetArea());

        Square square = new Square(5);
        Console.WriteLine("Area of Square: " + square.GetArea());
    }
}