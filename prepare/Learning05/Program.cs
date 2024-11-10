using System;

class Program
{
    static void Main(string[] args)
    {
        Square sqr = new Square(3, "Red");
        Rectangle rect = new Rectangle(3, 4, "Blue");
        Circle circle = new Circle(3, "Yellow");

        List<Shape> shapes = new List<Shape>();
        shapes.Add(sqr);
        shapes.Add(rect);
        shapes.Add(circle);

        foreach(Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
            Console.WriteLine();
        }
    }
}