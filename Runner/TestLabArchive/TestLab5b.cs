using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using Simulator;

namespace Runner.TestLabArchive;

public class TestLab5b
{
    public static void Lab5b()
    {
        SmallSquareMap smallMap1 = new(13); // no exception
        Console.WriteLine($"Small map1 created. Size {smallMap1.Size}.");

        SmallSquareMap smallMap2 = new(7); // no exception
        Console.WriteLine($"Small map2 created. Size {smallMap2.Size}.");

        Point testPoint1 = new(1, 1); // punkt wewnątrz mapy
        Console.WriteLine(testPoint1);
        Console.WriteLine($"Test Point 1 exist in the map1? {smallMap1.Exist(testPoint1)}.");
        Console.WriteLine($"Test Point 1 exist in the map2? {smallMap2.Exist(testPoint1)}.");
        Point movedTestPoint1 = smallMap1.Next(testPoint1, Direction.Right);
        Console.WriteLine(movedTestPoint1);
        Console.WriteLine($"Test Point 1 exist in the map1? {smallMap1.Exist(movedTestPoint1)}.");
        movedTestPoint1 = smallMap1.NextDiagonal(movedTestPoint1, Direction.Up);
        Console.WriteLine(movedTestPoint1);
        Console.WriteLine($"Test Point 1 exist in the map1? {smallMap1.Exist(movedTestPoint1)}.");



        Point testPoint2 = new(12, 12); //punkt wejsciowy na krawedzi mapy
        Console.WriteLine(testPoint2);
        Console.WriteLine($"Test Point 2 exist in the map1? {smallMap1.Exist(testPoint2)}.");
        Console.WriteLine($"Test Point 2 exist in the map2? {smallMap2.Exist(testPoint2)}.");
        Point movedTestPoint2 = smallMap1.NextDiagonal(testPoint2, Direction.Up);
        Console.WriteLine(movedTestPoint2);
        Console.WriteLine($"Test Point 2 exist in the map1? {smallMap1.Exist(movedTestPoint2)}.");

        Point testPoint3 = new(-2, 10); //Punkt wejsciowy poza mapą
        Console.WriteLine(testPoint3);
        Console.WriteLine($"Test Point 3 exist in the map1? {smallMap1.Exist(testPoint3)}.");
        Console.WriteLine($"Test Point 3 exist in the map2? {smallMap2.Exist(testPoint3)}.");
        Point movedTestPoint3 = smallMap1.NextDiagonal(testPoint3, Direction.Left);
        Console.WriteLine(movedTestPoint3);
        Console.WriteLine($"Test Point 3 exist in the map1? {smallMap1.Exist(movedTestPoint3)}.");


        try
        {
            SmallSquareMap smallMap3 = new(7); //no exception
            Console.WriteLine($"Small map3 created. Size {smallMap3.Size}.");
            Console.WriteLine($"Test Point 1 exist in the map3? {smallMap3.ExistAlternative(testPoint1)}.");
            Console.WriteLine($"Test Point (-1,2) exist in the map3? {smallMap3.ExistAlternative(new Point(-1, 2))}.");
            Console.WriteLine($"Test Point (7,6) exist in the map3? {smallMap3.ExistAlternative(new Point(7, 6))}.");

            SmallSquareMap smallMap4 = new(4); //exception expected -> too small
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            try
            {
                SmallSquareMap smallMap5 = new(33); //exception expected -> too big
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // the same exception
            }
        }

        /*
        Expected output:
        Small map1 created. Size 13.
        Small map2 created. Size 7.
        (1, 1)
        Test Point 1 exist in the map1? True.
        Test Point 1 exist in the map2? True.
        (2, 1)
        Test Point 1 exist in the map1? True.
        (3, 2)
        Test Point 1 exist in the map1? True.
        (12, 12)
        Test Point 2 exist in the map1? True.
        Test Point 2 exist in the map2? False.
        (12, 12)
        Test Point 2 exist in the map1? True.
        (-2, 10)
        Test Point 3 exist in the map1? False.
        Test Point 3 exist in the map2? False.
        (-2, 10)
        Test Point 3 exist in the map1 False.
        Small map3 created. Size 7.
        Test Point 1 exist in the map3? True.
        Test Point (-1,2) exist in the map3? False.
        Test Point (7,6) exist in the map3? False.
        For SmallSquareMap size needs to be in the range [5, 20]. (Parameter 'Size')
        For SmallSquareMap size needs to be in the range [5, 20]. (Parameter 'Size')
        */
    }
}
