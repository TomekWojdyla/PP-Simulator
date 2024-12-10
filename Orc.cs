using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    //Pola prywatne
    private int _rage;
    private int _huntCounter = 0; // licznik polowan: początkowo = 0
    private int _rageByHuntModifier = 2; // modyfikator: co ile polowan rośnie rage

    //Właściwości + gettery/settery
    public override int Power
    {
        get { return 7 * Level + 3 * Rage; }
    }

    public int Rage
    {
        get
        {
            return _rage;
        }
        init
        {
            _rage = Validator.Limiter(value, 0, 10);
        }
    }


    public void Hunt()
    {
        _huntCounter++; //licznik polowan +1
        if (_huntCounter % _rageByHuntModifier == 0 && Rage < 10) //jeżeli ilość polowan podzielna przez modyfikator i rage < max
        {
            _rage++;
            Console.WriteLine($"{Name} is hunting. You gained +1 in rage. Your rage is now {Rage}.");
            _huntCounter = 0; //zerowanie licznika polowan
        }
        else if ((_huntCounter % _rageByHuntModifier == 0 && Rage >= 10) || Rage >= 10) //jeżeli ilość polowan podzielna przez modyfikator ale rage >= max
        {
            Console.WriteLine($"{Name} is hunting. You reached max rage.");
            _huntCounter = 0; //zerowanie licznika polowan
        }
        else
        {
            Console.WriteLine($"{Name} is hunting. Hunt {_rageByHuntModifier - _huntCounter} more time(s) to +1 in rage.");
        }
    }

    //Konstruktor bezparametrowy
    public Orc() : base("Unknown Orc", 1)
    {
        //Brak działań
    }

    //konstruktor z parametrami
    public Orc(string name, int level = 1, int rage = 0) : base(name, level)
    {
        Rage = rage;
    }


    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    }
}
