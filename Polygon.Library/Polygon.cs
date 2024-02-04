namespace Polygon.Library
{
    public class Point//класс для опредения точки координат вершины многоугольника 
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int? x=0,int? y=0)
        {
            X = x ?? 0;
            Y = y ?? 0;
        }
    }
    public abstract class Polygon //класс определения понятия многоугольник, вычисление площади многоугольник по формуле шнуровка гаусса (родительский класс для более конкретных фигур), определение выпуклости многоугольника, поле для длины массива
    {
        public int Length { get; set; }
        public Point[] Points { get; set; }
        public Polygon(Point[]? points)
        {
            if(points is not null)
            {
                Length = points.Length;
                Points = new Point[points.Length];
            }
            else
            {
                throw new NullReferenceException("Не задан массив координат вершин многоугольника.");
            }
        }
        public bool IsConvex()//проверка многоугольника на выпуклость
        {
            bool convexFlag=false;
            //основной код здесь
            return convexFlag;
        }
        public double PolygonSquare()//вычисление площади многугольника
        {
            double polygonSquare=0;
            //основной код здесь
            return polygonSquare;
        }
    }
    public class Circle : Polygon//класс для вычисления площади круга (2*pi*r),массив вершин имеет длину в 1 элемент, поле для константы пи,поле для радиуса ,перегрузка метода вычисления площади 
    {

    }
    public class Triangle : Polygon//класс для вычисления площади (ф-ла из класса Polygon),массив вершин имеет длину в 3 элемента, проверка треугольника на прямоугольность
    {

    }
}
