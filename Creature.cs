using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public abstract class Creature
{
    //Pola Prywatne
    private string _name = "Unknown"; //konwencja nazywania pól prywatnych _camelCase
    private int _level;

    //Właściwości + gettery/settery
    public abstract int Power {  get; }

    public string Name
    {
        get
        {
            return _name;
        }
        init
        {
            _name = Validator.Shortener(value, 3, 25, '#');
        }
    }
    public int Level
    {
        get
        {
            return _level;
        }
        init
        {
            _level = Validator.Limiter(value, 1, 10);
        }
    }

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

    public abstract void SayHi(); //Kod wykomentowany z powodu pojawienia sie metody abstrakcyjnej - for reference only
    //{
    //    Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    //}

    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }

    public void Upgrade()
    {
        if (_level < 10) //Sprawdzenie, że nie ma levelu 10 przed podniesieniem o 1
        {
            _level++;
        }
    }

    public void Go(Direction direction) //Metoda GO na pojedynczy ruch stwora
    {
        string textToSentense = direction.ToString().ToLower(); //konwersja na string i ma małe litery
        Console.WriteLine($"{Name} goes {textToSentense}.");
    }

    public void Go(Direction[] directions) //Metoda GO na tablicę ruchów 
    {
        foreach (var direction in directions)
        {
            Go(direction); //wejsciem jest pojedynczy kierunek
        }
    }

    public void Go(string directionInputString) //Metoda GO parsująca string na tabelicę ruchów
    {
        Direction[] directions = DirectionParser.Parse(directionInputString);
        Go(directions); //wejsciem jest tablica kierunków
    }
}
