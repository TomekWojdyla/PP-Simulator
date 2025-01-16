using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    public bool IsGeneratable = true;
    public int SizeX { get; set; }
    public int SizeY { get; set; }
    public int TurnCounter { get; set; }
    public int CurrentTurnIndex { get; set; }
    public Dictionary<Point, char> Symbols { get; set; }
    public string Move { get; set; }
    public string Mappable { get; set; }
    public string SimulationMessage { get; set; }

    /*    public SimulationModel()
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
            List<Simulator.Point> creaturePoints = [new Simulator.Point(2, 1), new Simulator.Point(2, 3), new Simulator.Point(4, 4)];
            string simulationMoves = "rdlrrruuuurrr";

            List<IMappable> staticObstacles = [new StaticObstacle("Mountain", NaturalElement.Earth), new StaticObstacle("River", NaturalElement.Water),
                new StaticObstacle("River", NaturalElement.Water), new StaticObstacle("River", NaturalElement.Water),new StaticObstacle("Mist", NaturalElement.Air)];
            List<Simulator.Point> obstaclePoints = [new(2, 2), new(3, 5), new(3, 4), new(3, 3), new(5, 4)];

            //List<IMappable> creatures = [new Orc("Gorbag")];
            //List<Simulator.Point> creaturePoints = [new Simulator.Point(2, 1)];
            //string simulationMoves = "uuuuuuu";

            //List<IMappable> staticObstacles = [new StaticObstacle("Mist", NaturalElement.Air)];
            //List<Simulator.Point> obstaclePoints = [new(2, 2)];

            Simulation = new Simulation(map, creatures, creaturePoints, simulationMoves, staticObstacles, obstaclePoints);


            Logbook = new SimulationHistory(Simulation);

            TurnCounter = Logbook.TurnLogs.Count - 1;
            CurrentTurnIndex = 0;
        }*/

    public void OnGet()
    {
        int turn;
        if (!int.TryParse(Request.Query["Turn"], out turn))
        {
            turn = 0;
        }
        CurrentTurnIndex = turn;


        TurnCounter = HttpContext.Session.GetInt32("MaxTurn") ?? -1;
        string str = HttpContext.Session.GetString($"Turn{turn}.Symbols");
        Mappable = HttpContext.Session.GetString($"Turn{turn}.Mappable");
        Move = HttpContext.Session.GetString($"Turn{turn}.Move");
        SimulationMessage = HttpContext.Session.GetString($"Turn{turn}.Message");
        SizeX = HttpContext.Session.GetInt32("SizeX") ?? -1;
        SizeY = HttpContext.Session.GetInt32("SizeY") ?? -1;
        if (SizeX == -1 || SizeY == -1 || str == null || Mappable == null || Move == null || SimulationMessage == null)
        {
            IsGeneratable = false;
        }
        else
        {
            Symbols = SimulationTurnLog.DestrigifySymbols(str);
        }
    }
}
