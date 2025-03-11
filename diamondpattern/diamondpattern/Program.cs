using System;

class DiamondPattern
{
    static void Main()
    {
        Console.Write("Enter the number of rows for the diamond: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i += 2)
        {
            PrintSpaces((n - i) / 2);
            PrintStars(i);
        }

        for (int i = n - 2; i >= 1; i -= 2)
        {
            PrintSpaces((n - i) / 2);
            PrintStars(i);
        }
    }

    static void PrintSpaces(int count)
    {
        for (int i = 0; i < count; i++)
            Console.Write(" ");
    }

    static void PrintStars(int count)
    {
        for (int i = 0; i < count; i++)
            Console.Write("*");
        Console.WriteLine();
    }
}
