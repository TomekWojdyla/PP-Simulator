namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        //test pkt.2
        //Creature a = new("Shrek", 8);
        //a.SayHi();
        //Console.WriteLine(a.Info);
        //Creature b = new("Fiona");
        //b.SayHi();
        //Console.WriteLine(b.Info);
        //Animals z = new() { Description = "Wombats" };
        //Console.WriteLine(z.Info);

        static void Lab3a()
        {
            Creature c = new() { Name = "   Shrek    ", Level = 20 };
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("  ", -5);
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("  donkey ") { Level = 7 };
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("Puss in Boots – a clever and brave cat.");
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("a                            troll name", 5);
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            var a = new Animals() { Description = "   Cats " };
            Console.WriteLine(a.Info);

            a = new() { Description = "Mice           are great", Size = 40 };
            Console.WriteLine(a.Info);
        }

        //test pkt.3
        Lab3a();
    }
}
