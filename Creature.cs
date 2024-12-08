using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Creature
{
    //Właściwości + gettery/settery
    public string Name { get; set; }
    public int Level { get; set; }

    //Konstruktor parametryczny
    public Creature(string name, int level = 1)
    {
        Name = name; 
        Level = level;
    }

    //Konstruktor bez parametrów
    public Creature()
    {
        //Nic nie wykonuje
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }
}
