using ShapesApp.Shapes;
namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Круг
            var circle = new Circle(5);
            Console.WriteLine("Попытка установить радиус 10:");
            Console.WriteLine(circle.TrySetRadius(10) ? "Успешно" : "Ошибка");
            Console.WriteLine($"Радиус: {circle.Radius}");
            PrintShapeInfo(circle);

            // Прямоугольник
            var rectangle = new Rectangle(4, 7);
            Console.WriteLine("\nПопытка изменить размеры на 3 и 8:");
            Console.WriteLine(rectangle.TrySetDimensions(3, 8) ? "Успешно" : "Ошибка");
            Console.WriteLine($"Ширина: {rectangle.Width}, Высота: {rectangle.Height}");
            PrintShapeInfo(rectangle);
            // Треугольник
            var triangle = new Triangle(3, 4, 5);
            Console.WriteLine("\nПопытка установить стороны 2, 2 и 10:");
            Console.WriteLine(triangle.TrySetSides(2, 2, 10) ? "Успешно" : "Ошибка");
            Console.WriteLine($"Стороны: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}");
            PrintShapeInfo(triangle);
            var trapezoid = new Trapezoid(6, 4, 5, 5, 4);
            Console.WriteLine("\nИнформация о трапеции:");
            PrintShapeInfo(trapezoid);


            static void PrintShapeInfo(Shape shape)
            {
                Console.WriteLine("\nИнформация о фигуре:");
                shape.PrintType();
                shape.PrintSquare();
                shape.PrintPerimeter();
            }

        }
    }
}