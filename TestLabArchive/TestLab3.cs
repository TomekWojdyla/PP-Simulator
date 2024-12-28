using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.TestLabArchive
{
    public class TestLab3
    {
        public static void Lab3a()
        {
            Elf c = new() { Name = "   Shrek    ", Level = 20 };
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

        public static void Lab3b()
        {
            Elf c = new("Shrek", 7);
            c.SayHi();

            Console.WriteLine("\n* Up");
            c.Go(Direction.Up);

            Console.WriteLine("\n* Right, Left, Left, Down");
            Direction[] directions = {
            Direction.Right, Direction.Left, Direction.Left, Direction.Down
            };
            c.Go(directions);

            Console.WriteLine("\n* LRL");
            c.Go("LRL");

            Console.WriteLine("\n* xxxdR lyyLTyu");
            c.Go("xxxdR lyyLTyu");
        }
    }
}
