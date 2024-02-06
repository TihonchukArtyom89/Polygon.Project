namespace Polygon.Library;

public class Point//класс для опредения точки координат вершины многоугольника 
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point(int? x = 0, int? y = 0)
    {
        X = x ?? 0;
        Y = y ?? 0;
    }
}
public abstract class Polygon //класс определения понятия многоугольник, вычисление площади многоугольник (родительский класс для более конкретных фигур), определение выпуклости многоугольника, поле для длины массива
{
    public int Length { get; set; }
    public Point[] Points { get; set; }
    public Polygon(Point[]? points)
    {
        if (points is not null)
        {
            Length = points.Length;
            Points = points;
        }
        else
        {
            throw new NullReferenceException("Не задан массив координат вершин многоугольника.");
        }
    }
    public bool IsConvex()//проверка многоугольника на выпуклость
    {
        if (Length < 4)
        {
            return true;
        }
        bool isConvex = false;
        for (int i = 0; i < Length; i++)
        {
            double dx1 = Points[(i + 2) % Length].X - Points[(i + 1) % Length].X;
            double dy1 = Points[(i + 2) % Length].Y - Points[(i + 1) % Length].Y;
            double dx2 = Points[i].X - Points[(i + 1) % Length].X;
            double dy2 = Points[i].Y - Points[(i + 1) % Length].Y;
            double zcrossproduct = dx1 * dy2 - dy1 * dx2;
            if (i == 0)
            {
                isConvex = zcrossproduct > 0;
            }
            else if (isConvex != (zcrossproduct > 0))
            {
                return false;
            }
        }
        return true;
    }
    public virtual double PolygonSquare()//вычисление площади многугольника по формуле шнуровка гаусса
    {
        double polygonSquare = 0;
        for (int i = 0; i < Length; i++)
        {
            polygonSquare += Points[i].X * Points[i + 1].Y;
        }
        for (int i = Length - 1; i < 0; i++)
        {
            polygonSquare -= Points[i].X * Points[i - 1].Y;
        }
        return polygonSquare;
    }
}
public class Circle : Polygon//класс для вычисления площади круга (pi*r^2), массив вершин имеет длину в 2 элемента (центр окружности и точка на окружности), поле для константы пи, перегрузка метода вычисления площади 
{
    public const double PI = Math.PI;
    public Circle(Point[]? points) : base(points)
    {
        if ((points is not null) && (points.Length == 2))
        {
            Points = points;
        }
        else
        {
            throw new NullReferenceException("Не задан/ы или не верно задан/ы центр окружности и/или точка на окружности .");
        }
    }
    public override double PolygonSquare()// вычисление площади по формуле pi*r^2
    {
        double polygonSquare =  PI * Math.Pow(Math.Sqrt(Math.Pow(Points[1].X - Points[0].X, 2) + Math.Pow(Points[1].Y - Points[0].Y, 2)), 2);
        return polygonSquare;
    }
}
public class Triangle : Polygon//класс для вычисления площади (ф-ла из класса Polygon),массив вершин имеет длину в 3 элемента, проверка треугольника на прямоугольность
{
    public Triangle(Point[]? points) : base(points)
    {
        if ((points is not null) && (points.Length == 3))
        {
            Points = points;
        }
        else
        {
            throw new NullReferenceException("Не заданы точки треугольника.");
        }
    }
    public bool IsRightTriangle()//проверка треугольника на то является ли он прямоугольным
    {
        double[] sides =
        [
            Math.Sqrt(Math.Pow(Points[1].X - Points[0].X, 2) + Math.Pow(Points[1].Y - Points[0].Y, 2)),
            Math.Sqrt(Math.Pow(Points[2].X - Points[0].X, 2) + Math.Pow(Points[2].Y - Points[0].Y, 2)),
            Math.Sqrt(Math.Pow(Points[2].X - Points[1].X, 2) + Math.Pow(Points[2].Y - Points[1].Y, 2)),
        ];
        double max_side = sides.Max();
        double sum_sides = 0;
        foreach (double s in sides)
        {
            if (s != max_side)
            {
                sum_sides += s;
            }
        }
        if (Math.Pow(max_side, 2) == Math.Pow(sum_sides, 2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
