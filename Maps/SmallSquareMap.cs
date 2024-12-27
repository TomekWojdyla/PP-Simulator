using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    internal class SmallSquareMap : Map
    {
        //Właściwości
        public int Size { get; }

        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "For SmallSquareMap size needs to be in the range [5, 20]"); //wyjątek -> wymiar mapy nie pasuje do założeń
            }
            Size = size;

        }

        /// <summary>
        /// Check if given point belongs to the map.
        /// Map contains points from (0,0) to (Size-1, Size-1). Coordinates that equals 'Size' are outside the map!
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns>Bool: True/False</returns>
        public override bool Exist(Point p)
        {
            Rectangle tempRectangle = new(new Point(0, 0), new Point(Size-1, Size-1));
            //Console.WriteLine(tempRectangle.ToString()); // Kontrolny druk rozmiaru prostokąta
            return tempRectangle.Contains(p);
        }

        /// <summary>
        /// Check if given point belongs to the map.
        /// Map contains points from (0,0) to (Size-1, Size-1). Coordinates that equals 'Size' are outside the map!
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns>Bool: True/False</returns>
        public bool ExistAlternative(Point p) // No override -> this method not existed in class Map -> w zasadzie jest zbędna ale stworzona jako pierwsza ;) 
        {
            return 0 <= p.X && p.X <= Size - 1 && 0 < p.Y && p.Y <= Size - 1; // This one doesn't use Rectangle class
        }

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point after move or input point if given move takes it outside the map.</returns>
        public override Point Next(Point p, Direction d)
        {
            // brak sprawdzenia czy podany punkt jest wewnątrz mapy
            Point pointAfterMove = p.Next(d);
            if (Exist(pointAfterMove))
            {
                return pointAfterMove;
            }
            else
            {
                return p;
            }
        }

        /// <summary>
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point after move or input point if given move takes it outside the map.</returns>
        public override Point NextDiagonal(Point p, Direction d)
        {
            // brak sprawdzenia czy podany punkt jest wewnątrz mapy
            Point pointAfterMove = p.NextDiagonal(d);
            if (Exist(pointAfterMove))
            {
                return pointAfterMove;
            }
            else
            {
                return p;
            }
        }
    }
}
