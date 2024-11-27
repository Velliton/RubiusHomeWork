using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Shapes
{
    public class Trapezoid : Shape
    {
        public double Base1 { get; }
        public double Base2 { get; }
        public double Side1 { get; }
        public double Side2 { get; }
        public double Height { get; }

        public Trapezoid(double base1, double base2, double side1, double side2, double height)
        {
            Base1 = base1;
            Base2 = base2;
            Side1 = side1;
            Side2 = side2;
            Height = height;
        }

        public override double CalculateSquare() => ((Base1 + Base2) / 2) * Height;

        public override double CalculatePerimeter() => Base1 + Base2 + Side1 + Side2;

        public override void PrintType()
        {
            Console.WriteLine("Фигура: Трапеция");
        }
    }
}
