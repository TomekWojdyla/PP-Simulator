using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    //Pola prywatne
    private int _agility;
    private int _singCounter = 0; // licznik śpiewu: początkowo = 0
    private int _agilityBySingModifier = 3; // modyfikator: co ile śpiewów rośnie agility

    //Właściwości + gettery/settery
    public override int Power
    {
        get { return 8 * Level + 2 * Agility; }
    }

    public int Agility
    {
        get
        {
            return _agility;
        }
        init
        {
            if (value < 0)
            {
                _agility = 0;
            }
            else if (value > 10)
            {
                _agility = 10;
            }
            else
            {
                _agility = value;
            }
        }
    }
    public void Sing()
    {
        _singCounter++; //licznik śpiewu +1
        if (_singCounter % _agilityBySingModifier == 0 && Agility < 10) //jeżeli ilość śpiewów podzielna przez modyfikator i agility < max
        {
            _agility++;
            Console.WriteLine($"{Name} is singing. You gained +1 in agility. Your agility is now {Agility}.");
            _singCounter = 0; //zerowanie licznika śpiewu
        }
        else if ((_singCounter % _agilityBySingModifier == 0 && Agility >= 10) || Agility >= 10) //jeżeli ilość śpiewów podzielna przez modyfikator ale agility >= max
        {
            Console.WriteLine($"{Name} is singing. You reached max agility.");
            _singCounter = 0; //zerowanie licznika śpiewu
        }
        else // Śpiew bez modyfikacji agility
        {
            Console.WriteLine($"{Name} is singing. Sing {_agilityBySingModifier - _singCounter} more time(s) to +1 in agility.");
        }
    }

    //Konstruktor bezparametrowy
    public Elf() : base("Unknown Elf", 1)
    {
        //Brak działań
    }

    //konstruktor z parametrami
    public Elf(string name, int level = 1, int agility = 0) : base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    }
}
