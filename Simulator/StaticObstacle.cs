﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator;

public class StaticObstacle : IMappable
{
    private string _name = "Unknown Obstacle"; //konwencja nazywania pól prywatnych _camelCase
    private NaturalElement _naturalElement; //konwencja nazywania pól prywatnych _camelCase

    public char MapSymbol { get; set; }

    public Map? Map { get; set; }
    public Point Position { get; set; }

    /// <summary>
    /// Obstacles's Name (validation of given string applies).
    /// </summary>
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

    public NaturalElement NaturalElement { get; set; }
    public bool IsLost { get; set; } = false;

    public StaticObstacle(string name, NaturalElement naturalElement)
    {
        Name = name;
        NaturalElement = naturalElement;
        switch (NaturalElement)
        {
            case NaturalElement.Earth:
                MapSymbol = 'H';
                break;
            case NaturalElement.Water:
                MapSymbol = 'W';
                break;
            case NaturalElement.Air:
                MapSymbol = 'M';
                break;
            case NaturalElement.Fire:
                MapSymbol = 'F';
                break;
        }
    }

    public void InitMapAndPosition(Map map, Point position, bool requestFromMap = false)
    {
        Map = map;
        if (requestFromMap == false) // aby utrzymać możliwość zainicjowania bytu z jego poziomu a nie mapy (wzajemne odwołanie metody Add i InitMapAndPosition)
        {
            Map.Add(this, position);
        }
        Position = position;
    }

    public void RemoveFromMap()
    {
        Map = null;
    }

    public string Go(Direction direction)
    {
        throw new NotImplementedException();
    }
}
