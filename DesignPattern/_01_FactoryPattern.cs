using System;
using System.Runtime.Serialization;

namespace DesignPattern._01_Factory
{
    [DataContract(Name = "工厂模式")]
    class _01_FactoryPattern
    {
        public static void Run()
        {
            Console.WriteLine(typeof(_01_FactoryPattern).GetClassName());

            var shapeFactory = new ShapeFactory();
            var shape1 = shapeFactory.GetShape("Rectangle");
            shape1.Draw();

            var shape2 = shapeFactory.GetShape("Square");
            shape2.Draw();

            var shape3 = shapeFactory.GetShape("Circle");
            shape3.Draw();

            Console.WriteLine();
        }
    }

    public interface Shape
    {
        void Draw();
    }

    public class Rectangle : Shape
    {
        void Shape.Draw()
        {
            Console.WriteLine($"Rectangle.Draw();");
        }
    }

    public class Square : Shape
    {
        public void Draw()
        {
            Console.WriteLine($"Square.Draw();");
        }
    }

    public class Circle : Shape
    {
        public void Draw()
        {
            Console.WriteLine($"Circle.Draw();");
        }
    }

    public class ShapeFactory
    {
        public Shape GetShape(string shapeType)
        {
            if (string.IsNullOrWhiteSpace(shapeType))
                throw new ArgumentNullException(nameof(shapeType));
            switch (shapeType)
            {
                case "Rectangle": return new Rectangle();
                case "Square": return new Square();
                case "Circle": return new Circle();
                default: return null;
            }
        }
    }
}
