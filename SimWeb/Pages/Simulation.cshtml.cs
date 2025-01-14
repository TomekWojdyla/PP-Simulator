using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    public Simulation Simulation { get; }

    public SimulationHistory Logbook { get; }

    public int TurnCounter { get; }

    public int CurrentTurnIndex { get; set; }

    public SimulationModel()
    {
        Map map = new SmallTorusMap(8, 6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Rabbits" , Size = 40},
                new Birds() { Description = "Eagles"}, new Birds() {Description = "Ostriches", Size = 15, CanFly = false}];
        List<Simulator.Point> creaturePoints = [new(2, 2), new(3, 1), new(5, 5), new(7, 3), new(0, 4)];
        string simulationMoves = "dlrludluddlrulr";

        Simulation = new Simulation(map, creatures, creaturePoints, simulationMoves);


        //SmallTorusMap map = new(8, 6);
        //List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Rabbits" }];
        //List<Simulator.Point> points = [new Simulator.Point(2, 1), new Simulator.Point(2, 3), new Simulator.Point(4, 4)];
        //string moves = "rdlrrruuuurrr";

        //List<IMappable> staticObstacles = [new StaticObstacle("Mountain", NaturalElement.Earth), new StaticObstacle("River", NaturalElement.Water),
        //    new StaticObstacle("River", NaturalElement.Water), new StaticObstacle("River", NaturalElement.Water),new StaticObstacle("Mist", NaturalElement.Air)];
        //List<Simulator.Point> obstaclePoints = [new(2, 2), new(3, 5), new(3, 4), new(3, 3), new(5, 4)];


        //Simulation Simulation = new(map, creatures, points, moves, staticObstacles, obstaclePoints);


        Logbook = new SimulationHistory(Simulation);

        TurnCounter = Logbook.TurnLogs.Count - 1;
        CurrentTurnIndex = 0;
    }

    public void OnGet()
    {
        int turn;
        if (!int.TryParse(Request.Query["turn"], out turn))
        {
            turn = 0;
        }
        CurrentTurnIndex = turn;
    }
}
