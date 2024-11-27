using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesApp.Interfaces;

namespace ShapesApp.Shapes
{
    public abstract class Shape : IPrintableShape
    {
        public abstract double CalculateSquare();
        public abstract double CalculatePerimeter();
        public abstract void PrintType();

        public void PrintSquare()
        {
            Console.WriteLine($"Площадь: {CalculateSquare()}");
        }

        public void PrintPerimeter()
        {
            Console.WriteLine($"Периметр: {CalculatePerimeter()}");
        }
    }
}
