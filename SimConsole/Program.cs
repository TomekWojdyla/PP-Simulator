﻿using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.OutputEncoding = Encoding.UTF8; // Wygląda na niepotrzebne?
        Console.WriteLine("SIMULATION!\n");


        //   MAPA SQUARE 5x5 
        //SmallSquareMap map = new(5);
        //List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        //List<Simulator.Point> points = [new(2, 2), new(3, 1)];
        //string moves = "dlrludl";

        //Simulation simulation = new(map, creatures, points, moves);
        //MapVisualizer mapVisualizer = new(simulation.Map);


        //   MAPA TORUS 8x6 -> stwory i ruchy jak w projekie DEMO RAZOR PAGES
        SmallTorusMap map = new(8, 6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"),
            new Animals() { Description = "Rabbits" , Size = 40}, new Birds() { Description = "Eagles"}, new Birds() {Description = "Ostriches", Size = 15, CanFly = false}];
        List<Simulator.Point> points = [new(2, 2), new(3, 1), new(5, 5), new(7, 3), new(0, 4)];
        string moves = "dlrludluddlrulr";

        Simulation simulation = new(map, creatures, points, moves);

        //MapVisualizer mapVisualizer = new(simulation.Map);

        //Console.WriteLine("Created Creatures in map:");
        //foreach (IMappable mappable in creatures)
        //{
        //    Console.WriteLine(mappable.ToString());
        //}
        //Console.WriteLine("\nStarting Positions:");

        //mapVisualizer.Draw();

        //while (!simulation.Finished)
        //{
        //    Console.WriteLine("Press any key to continue...");
        //    Console.ReadKey();
        //    Console.WriteLine($"\nTurn {simulation.CurrentTurnNumber}:");
        //    Console.WriteLine ($"{simulation.CurrentCreature} goes {simulation.CurrentMoveName}:");
        //    simulation.Turn();
        //    mapVisualizer.Draw();
        //}
        //Console.WriteLine("End of simulation!");

        Console.WriteLine("\nSIMULATION LOGBOOK:");
        var logbook = new SimulationHistory(simulation);
        foreach (SimulationTurnLog turn in logbook.TurnLogs)
        {
            Console.WriteLine($"\nTurn # {logbook.TurnLogs.IndexOf(turn)}:");
            Console.WriteLine($"Creature: {turn.Mappable}");
            Console.WriteLine($"Move: {turn.Move}");
            foreach (var symbol in turn.Symbols)
                Console.WriteLine($"{symbol.Key} {symbol.Value}");
        }
        Console.WriteLine();
        Console.WriteLine("\nEND OF LOGBOOK.");

        Console.WriteLine($"\nWhich Turn you would like to see? \nProvide a number between 0 and {logbook.TurnLogs.Count-1}:");
        int selectedTurn = int.Parse(Console.ReadLine());

        Console.WriteLine($"\nTurn # {selectedTurn}:");
        Console.WriteLine($"Creature: {logbook.TurnLogs[selectedTurn].Mappable}");
        Console.WriteLine($"Move: {logbook.TurnLogs[selectedTurn].Move}");
        foreach (var symbol in logbook.TurnLogs[selectedTurn].Symbols)
            Console.WriteLine($"{symbol.Key} {symbol.Value}");

    }
}