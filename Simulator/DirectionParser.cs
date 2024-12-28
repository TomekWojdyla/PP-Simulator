using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string directionInputString)
    {
        List<Direction> result = new List<Direction>();

        foreach (char letter in directionInputString.ToUpper()) //powiekszamy wszystkie litery żeby zmneijszyć ilość case'ow
        {
            switch (letter)
            {
                case 'U':
                    result.Add(Direction.Up);
                    break;
                case 'R':
                    result.Add(Direction.Right);
                    break;
                case 'D':
                    result.Add(Direction.Down);
                    break;
                case 'L':
                    result.Add(Direction.Left);
                    break;
            }
        }
        return result.ToArray();
    }
}
