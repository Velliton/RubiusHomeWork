using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Shapes
{
    public class Rectangle : Shape
    {
        private double _width;
        private double _height;

        public double Width
        {
            get => _width;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Ширина должна быть положительной.");
                _width = value;
            }
        }
        public double Height
        {
            get => _height;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Высота должна быть положительной.");
                _height = value;
            }
        }

        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Ширина и высота должны быть положительными.");
            _width = width;
            _height = height;
        }

        public bool TrySetDimensions(double width, double height)
        {
            if (width > 0 && height > 0)
            {
                _width = width;
                _height = height;
                return true;
            }
            return false;
        }



        public override double CalculateSquare() => _width * _height;

        public override double CalculatePerimeter() => 2 * (_width + _height);

        public override void PrintType()
        {
            Console.WriteLine("Фигура: Прямоугольник");
        }
    }
}
