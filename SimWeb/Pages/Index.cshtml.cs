using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;


namespace SimWeb.Pages;

public class IndexModel : PageModel
{
    //private readonly ILogger<IndexModel> _logger;

    public Simulation Simulation { get; }

    public SimulationHistory History { get; }

    public string CreaturesInMap { get; } = "";


    public IndexModel()
    {
        //Map map = new SmallTorusMap(8, 6);
        //List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Rabbits" , Size = 40},
        //        new Birds() { Description = "Eagles"}, new Birds() {Description = "Ostriches", Size = 15, CanFly = false}];
        //List<Simulator.Point> creaturePoints = [new(2, 2), new(3, 1), new(5, 5), new(7, 3), new(0, 4)];
        //string simulationMoves = "dlrludluddlrulr";
        //List<IMappable> staticObstacles = [new StaticObstacle("Mountain", NaturalElement.Earth)];
        //List<Simulator.Point> obstaclePoints = [new(0, 0)];

        //Simulation = new Simulation(map, creatures, creaturePoints, simulationMoves, staticObstacles, obstaclePoints);


        Map map = new SmallTorusMap(8, 6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Rabbits" }];
        List<Simulator.Point> creaturePoints = [new Simulator.Point(2, 1), new Simulator.Point(2, 3), new Simulator.Point(4, 2)];
        string simulationMoves = "rdlruuruuuuuulr";

        List<IMappable> staticObstacles = [new StaticObstacle("Mountain", NaturalElement.Earth), new StaticObstacle("River", NaturalElement.Water),
            new StaticObstacle("River", NaturalElement.Water), new StaticObstacle("River", NaturalElement.Water),new StaticObstacle("Mist", NaturalElement.Air)];
        List<Simulator.Point> obstaclePoints = [new(2, 2), new(3, 5), new(3, 4), new(3, 3), new(5, 4)];

        List<Item> items = Enumerable.Repeat((Item)new Coin(), 10).ToList();
        List<Point> itemPositions = [new(1, 0), new(0, 1), new(5, 0), new(7, 5), new(6, 2), new(4, 1), new(3, 2), new(0, 3), new(6, 3), new(1, 4)];
        
        //List<IMappable> creatures = [new Orc("Gorbag")];
        //List<Simulator.Point> creaturePoints = [new Simulator.Point(2, 1)];
        //string simulationMoves = "uuuuuuu";

        //List<IMappable> staticObstacles = [new StaticObstacle("Mist", NaturalElement.Air)];
        //List<Simulator.Point> obstaclePoints = [new(2, 2)];

        Simulation = new Simulation(map, creatures, creaturePoints, simulationMoves, staticObstacles, obstaclePoints, items, itemPositions);
        History = new SimulationHistory(Simulation);

        foreach (IMappable mappable in creatures)
        {
            CreaturesInMap += mappable.ToString() + " ; ";
        };
    }

    public void OnGet()
    {
        HttpContext.Session.SetInt32("MaxTurn", History.TurnLogs.Count - 1);
        HttpContext.Session.SetInt32("SizeX", History.SizeX);
        HttpContext.Session.SetInt32("SizeY", History.SizeY);
        for (int i = 0; i < History.TurnLogs.Count; i++)
        {
            HttpContext.Session.SetString($"Turn{i}.Mappable", History.TurnLogs[i].Mappable);
            HttpContext.Session.SetString($"Turn{i}.Move", History.TurnLogs[i].Move);
            HttpContext.Session.SetString($"Turn{i}.Symbols", History.TurnLogs[i].StrigifySymbols());
            HttpContext.Session.SetString($"Turn{i}.Message", History.TurnLogs[i].SimulationMessage);
        }
    }
}
