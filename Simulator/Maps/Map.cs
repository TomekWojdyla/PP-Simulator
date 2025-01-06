using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    /// <summary>
    /// Horizontal map size.
    /// </summary>
    public int SizeX { get; init; }

    /// <summary>
    /// Vertical map size.
    /// </summary>
    public int SizeY { get; init; }

    /// <summary>
    /// Rectangle created out of map dimensions. Always start in (0,0) and ends in (SizeX-1, SizeY-1).
    /// </summary>
    private readonly Rectangle _map;

    /// <summary>
    /// Map constructor. Map cannot be smaller than 5 units each direction.
    /// </summary>
    public Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Map size cannot be smaller than 5"); //wyjątek -> wymiar mapy nie pasuje do założeń
        }
        else if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Map size cannot be smaller than 5"); //wyjątek -> wymiar mapy nie pasuje do założeń
        }
        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    /// <summary>
    /// Check if given point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public bool Exist(Point p)
    {
        return _map.Contains(p);
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}
