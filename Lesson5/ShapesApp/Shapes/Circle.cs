using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Shapes
{
    public class Circle : Shape
    {
        private double _radius;
        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Радиус должен быть положительным.");
                _radius = value;
            }
        }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус должен быть положительным.");
            _radius = radius;
        }

        public bool TrySetRadius(double radius)
        {
            if (radius > 0)
            {
                _radius = radius;
                return true;
            }
            return false;
        }


        public override double CalculateSquare() => Math.PI * Math.Pow(_radius, 2);

        public override double CalculatePerimeter() => 2 * Math.PI * _radius;

        public override void PrintType()
        {
            Console.WriteLine("Фигура: Круг");
        }
    }
}
