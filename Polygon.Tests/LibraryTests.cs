using Polygon.Library;
namespace Polygon.Tests;

public class LibraryTests
{
    public const double PI = Math.PI;
    [Fact]
    public void Can_Calculate_Square_Circle()
    {
        //arrange
        Point[] circle_points = {new Point(0,0),new Point (1,0) };
        Circle circle = new(circle_points);
        double expected_circle_square = PI;
        //act
        double actual_circle_square = circle.PolygonSquare();
        //assert
        Assert.Equal(expected_circle_square, actual_circle_square);
    }
}