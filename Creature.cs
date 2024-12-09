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
            string validatedName = value.Trim(); //Ucina białe znaki na początku i na końcu
            if (validatedName == "" || validatedName == null) //Wyłapanie sytuacji w której z nazwy nic nie zostało po Trim()
            {
                _name = "Unknown";
            }
            else
            {
                if (validatedName.Length < 3)
                {
                    validatedName = validatedName.PadRight(3, '#'); //Uzyskanie nazwy na min 3 znaki
                }
                else if (validatedName.Length > 25)
                {
                    validatedName = validatedName.Substring(0, 25).TrimEnd(); //ucięcie stringa do max 25 znaków + ucięcie białych znaków z końca
                    if (validatedName.Length < 3)
                    {
                        validatedName = validatedName.PadRight(3, '#'); //Uzyskanie nazwy na min 3 znaki
                    }
                }
                if (char.IsLower(validatedName[0]))
                {
                    validatedName = char.ToUpper(validatedName[0]) + validatedName.Substring(1); //Ustawienie pierwszej litery na wielka
                }
                _name = validatedName;
            }
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
            if (value < 1)
            {
                _level = 1;
            }
            else if (value > 10)
            {
                _level = 10;
            }
            else
            {
                _level = value;
            }
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
