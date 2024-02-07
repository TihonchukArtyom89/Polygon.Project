using Polygon.Library;
namespace Polygon.Tests;

public class LibraryTests
{
    public const double PI = Math.PI;
    [Fact]
    public void Can_Calculate_Square_Circle()
    {
        //arrange
        Point[] circle_points = {new (0,0),new (1,0) };
        Circle circle = new(circle_points);
        double expected_circle_square = PI;
        //act
        double actual_circle_square = circle.PolygonSquare();
        //assert
        Assert.Equal(expected_circle_square, actual_circle_square);
    }
    [Fact]
    public void Can_Calculate_Square_Triangle()
    {
        //arrange
        Point[] triangle_points = { new(3, 5), new(-7, 10), new(9, 6) };
        Triangle triangle = new(triangle_points);
        double expected_triangle_square = 20;
        //act
        double actual_triangle_square = triangle.PolygonSquare();
        //assert
        Assert.Equal(expected_triangle_square, actual_triangle_square);
    }
    [Fact]
    public void Can_Calculate_Is_Right_Triangle()
    {
        //arrange
        Point[] triangle_points = { new(0, 0), new(1, 0), new(1, 1) };
        Triangle triangle = new(triangle_points);
        //act
        bool isRigthTriangle = triangle.IsRightTriangle();
        //assert
        Assert.True(isRigthTriangle);
    }
}