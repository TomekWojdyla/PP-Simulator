using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int size = 10;
        // Act
        var map = new SmallSquareMap(size);
        // Assert
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(20)]
    public void Constructor_ValidSize_ShouldSetMaxSize(int size)
    {
        // Arrange
        // Act
        var map = new SmallSquareMap(size);
        // Assert
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void
        Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException
        (int size)
    {
        // Act & Assert
        // The way to check if method throws anticipated exception:
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(-1, 0, 5, false)]
    [InlineData(0, 0, 5, true)]
    [InlineData(3, 4, 5, true)]
    [InlineData(6, 1, 5, false)]
    [InlineData(19, 19, 20, true)]
    [InlineData(20, 20, 20, false)]
    [InlineData(0, 7, 8, true)]
    public void Exist_ShouldReturnCorrectValue(int x, int y,
        int size, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        // Act
        var result = map.Exist(point);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(20, 5, 10, Direction.Up, 5, 11)]
    [InlineData(8, 7, 7, Direction.Up, 7, 7)]
    [InlineData(20, 0, 0, Direction.Down, 0, 0)]
    [InlineData(7, 6, 5, Direction.Down, 6, 4)]
    [InlineData(20, 0, 8, Direction.Left, 0, 8)]
    [InlineData(20, 19, 10, Direction.Right, 19, 10)]
    [InlineData(20, 18, 10, Direction.Right, 19, 10)]
    public void Next_ShouldReturnCorrectNextPoint(int size, int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.Next(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(20, 5, 10, Direction.Up, 6, 11)]
    [InlineData(8, 6, 7, Direction.Up, 6, 7)]
    [InlineData(20, 0, 0, Direction.Down, 0, 0)]
    [InlineData(20, 1, 0, Direction.Down, 1, 0)]
    [InlineData(10, 5, 5, Direction.Down, 4, 4)]
    [InlineData(20, 0, 8, Direction.Left, 0, 8)]
    [InlineData(10, 5, 7, Direction.Left, 4, 8)]
    [InlineData(20, 19, 10, Direction.Right, 19, 10)]
    [InlineData(15, 10, 10, Direction.Right, 11, 9)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int size, int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.NextDiagonal(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
