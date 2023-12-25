using System;
using System.Collections.Generic;
namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Square mySquare = new Square(){ShapeType = "Square", Side = 5};
            // System.Console.WriteLine(mySquare.GetArea());

            Rectangle myRectangle = new Rectangle(){ShapeType = "Rectangle", Length = 10, Width = 6};
            // System.Console.WriteLine(myRectangle.GetPerimeter());

            Triangle myTriangle = new Triangle(){ShapeType = "Triangle", Side1 = 3, Side2 = 4, Base = 5, Height = 2};
            // System.Console.WriteLine(myTriangle.GetArea());

            List<IShape> myShapes = new List<IShape>();
            myShapes.Add(myRectangle);
            myShapes.Add(mySquare);
            myShapes.Add(myTriangle);

            foreach (IShape shape in myShapes){
                System.Console.WriteLine($"For the {shape.ShapeType}, The area is {shape.GetArea()} and the perimeter is {shape.GetPerimeter()} ");
            }
;
        }
    }
}
