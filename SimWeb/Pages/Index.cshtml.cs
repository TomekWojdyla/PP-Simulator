using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;


namespace SimWeb.Pages;

public class IndexModel : PageModel
{
    //private readonly ILogger<IndexModel> _logger;

    public Simulation Simulation { get; }

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
        //List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Rabbits" }];
        //List<Simulator.Point> creaturePoints = [new Simulator.Point(2, 1), new Simulator.Point(2, 3), new Simulator.Point(4, 4)];
        //string simulationMoves = "rdlrrruuuurrr";

        //List<IMappable> staticObstacles = [new StaticObstacle("Mountain", NaturalElement.Earth), new StaticObstacle("River", NaturalElement.Water),
        //    new StaticObstacle("River", NaturalElement.Water), new StaticObstacle("River", NaturalElement.Water),new StaticObstacle("Mist", NaturalElement.Air)];
        //List<Simulator.Point> obstaclePoints = [new(2, 2), new(3, 5), new(3, 4), new(3, 3), new(5, 4)];
        List<IMappable> creatures = [new Orc("Gorbag")];
        List<Simulator.Point> creaturePoints = [new Simulator.Point(2, 1)];
        string simulationMoves = "uuuuuuu";

        List<IMappable> staticObstacles = [new StaticObstacle("Mist", NaturalElement.Air)];
        List<Simulator.Point> obstaclePoints = [new(2, 2)];

        Simulation = new Simulation(map, creatures, creaturePoints, simulationMoves, staticObstacles, obstaclePoints);


        foreach (IMappable mappable in creatures)
        {
            CreaturesInMap += mappable.ToString() + " ; ";
        };
    }

    public void OnGet()
    {

    }
}
