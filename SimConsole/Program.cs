using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.OutputEncoding = Encoding.UTF8; // Wygląda na niepotrzebne?
        Console.WriteLine("SIMULATION!\n");

        SmallSquareMap map = new(5);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Simulator.Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        Console.WriteLine("Created Creatures in map:");
        foreach (Creature creature in creatures)
        {
            Console.WriteLine(creature.ToString());
        }
        Console.WriteLine("\nStarting Positions:");

        mapVisualizer.Draw();

        while (!simulation.Finished)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine($"\nTurn {simulation.CurrentTurnNumber}:");
            Console.WriteLine ($"{simulation.CurrentCreature} goes {simulation.CurrentMoveName}:");
            simulation.Turn();
            mapVisualizer.Draw();
        }
        Console.WriteLine("End of simulation!");
    }
}
