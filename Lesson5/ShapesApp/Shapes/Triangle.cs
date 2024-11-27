using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Shapes
{
    public class Triangle : Shape
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;

        public double SideA
        {
            get => _sideA;
            set
            {
                if (!IsValid(value, _sideB, _sideC))
                    throw new ArgumentException("Стороны не образуют треугольник.");
                _sideA = value;
            }
        }

        public double SideB
        {
            get => _sideB;
            set
            {
                if (!IsValid(_sideA, value, _sideC))
                    throw new ArgumentException("Стороны не образуют треугольник.");
                _sideB = value;
            }
        }

        public double SideC
        {
            get => _sideC;
            set
            {
                if (!IsValid(_sideA, _sideB, value))
                    throw new ArgumentException("Стороны не образуют треугольник.");
                _sideC = value;
            }
        }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (!IsValid(sideA, sideB, sideC))
                throw new ArgumentException("Стороны не образуют треугольник.");
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }

        public bool TrySetSides(double sideA, double sideB, double sideC)
        {
            if (IsValid(sideA, sideB, sideC))
            {
                _sideA = sideA;
                _sideB = sideB;
                _sideC = sideC;
                return true;
            }
            return false;
        }

        public override double CalculateSquare()
        {
            double p = CalculatePerimeter() / 2;
            return Math.Sqrt(p * (p - _sideA) * (p - _sideB) * (p - _sideC));
        }

        public override double CalculatePerimeter() => _sideA + _sideB + _sideC;

        public override void PrintType()
        {
            Console.WriteLine("Фигура: Треугольник");
        }

        private static bool IsValid(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}
