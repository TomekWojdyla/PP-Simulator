using Simulator;
using Simulator.Maps;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab3a();
        Lab3b();
        Lab4a();
        Lab4b();
    }

    public static void Lab3a()
    {
        Elf c = new() { Name = "   Shrek    ", Level = 20 };
        Console.WriteLine(c.Greeting());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  ", -5);
        Console.WriteLine(c.Greeting());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  donkey ") { Level = 7 };
        Console.WriteLine(c.Greeting());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("Puss in Boots – a clever and brave cat.");
        Console.WriteLine(c.Greeting());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("a                            troll name", 5);
        Console.WriteLine(c.Greeting());
        c.Upgrade();
        Console.WriteLine(c.Info);

        var a = new Animals() { Description = "   Cats " };
        Console.WriteLine(a.Info);

        a = new() { Description = "Mice           are great", Size = 40 };
        Console.WriteLine(a.Info);
    }

    public static void Lab3b()
    {
        Elf c = new("Shrek", 7);
        Console.WriteLine(c.Greeting());

        Console.WriteLine("\n* Up");
        Console.WriteLine(c.Go(Direction.Up));

        Console.WriteLine("\n* Right, Left, Left, Down");
        Direction[] directions = {
            Direction.Right, Direction.Left, Direction.Left, Direction.Down
            };
        string[] goTable = c.Go(directions);
        foreach (var go in goTable)
        {
            Console.WriteLine(go);
        }

        Console.WriteLine("\n* LRL");
        string[] goTable2 = c.Go("LRL");
        foreach (var go in goTable2)
        {
            Console.WriteLine(go);
        }

        Console.WriteLine("\n* xxxdR lyyLTyu");
        string[] goTable3 = c.Go("xxxdR lyyLTyu");
        foreach (var go in goTable3)
        {
            Console.WriteLine(go);
        }
    }

    public static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        Console.WriteLine(o.Greeting());
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            Console.WriteLine(o.Greeting());
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        Console.WriteLine(e.Greeting());
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            Console.WriteLine(e.Greeting());
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }


    public static void Lab4b()
    {
        object[] myObjects = {
            new Animals() { Description = "dogs"},
            new Birds { Description = "  eagles ", Size = 10 },
            new Elf("e", 15, -3),
            new Orc("morgash", 6, 4)
           };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }
}
