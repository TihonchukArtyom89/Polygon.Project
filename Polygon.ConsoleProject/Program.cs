// See https://aka.ms/new-console-template for more information
using Polygon.Library;
Console.WriteLine("Hello, World!");
Point[] triangle_points = { new(3, 5), new(-7, 10), new(9, 6) };
Triangle triangle = new(triangle_points);
Point[] triangle_points1 = { new(0, 0), new(1, 0), new(1, 1) };
Triangle triangle1 = new(triangle_points1);
//Console.WriteLine(triangle.PolygonSquare());
//Console.WriteLine(triangle1.PolygonSquare());
Console.WriteLine(triangle1.IsRightTriangle());