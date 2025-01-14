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
        Map map = new SmallTorusMap(8, 6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Rabbits" , Size = 40},
                new Birds() { Description = "Eagles"}, new Birds() {Description = "Ostriches", Size = 15, CanFly = false}];
        List<Simulator.Point> creaturePoints = [new(2, 2), new(3, 1), new(5, 5), new(7, 3), new(0, 4)];
        string simulationMoves = "dlrludluddlrulr";

        Simulation = new Simulation(map, creatures, creaturePoints, simulationMoves);


        foreach (IMappable mappable in creatures)
        {
            CreaturesInMap += mappable.ToString() + " ; ";
        };
    }

    public void OnGet()
    {

    }
}
