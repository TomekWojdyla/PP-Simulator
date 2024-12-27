namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Point p = new(10, 25);
        Console.WriteLine(p); // (10, 25)
        Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)
        Console.WriteLine(p.NextDiagonal(Direction.Left));  // (9, 26)
    }
}
