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
    public abstract string Info { get; }

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

    public abstract string Greeting(); //Kod wykomentowany z powodu pojawienia sie metody abstrakcyjnej - for reference only
    //{
    //    return $"Hi, I'm {Name}, my level is {Level}.";
    //}

    public void Upgrade()
    {
        if (_level < 10) //Sprawdzenie, że nie ma levelu 10 przed podniesieniem o 1
        {
            _level++;
        }
    }

    public string Go(Direction direction) //Metoda GO na pojedynczy ruch stwora
    {
        return $"{direction.ToString().ToLower()}"; //konwersja na string i ma małe litery
    }

    public string[] Go(Direction[] directions) //Metoda GO na tablicę ruchów 
    {
        string[] goTable = new string[directions.Length];
        for (int i = 0; i < directions.Length; i++)
        {
            goTable[i] = Go(directions[i]);
        }
        return goTable;
    }

    public string[] Go(string directionInputString) //Metoda GO parsująca string na tabelicę ruchów
    {
        Direction[] directions = DirectionParser.Parse(directionInputString);
        return Go(directions); //wejsciem jest tablica kierunków
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Name} [{Level}]{Info}";
    }
}
