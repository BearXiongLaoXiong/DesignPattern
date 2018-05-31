using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._02_AbstractFactory
{
    /// <summary>
    /// 抽象工厂模式
    /// </summary>
    public class _02_AbstractFactoryPattern
    {
        public static void Run()
        {
            Console.WriteLine(nameof(_02_AbstractFactoryPattern));
            var shapeFactory = FactoryProducer.GetFactory("Shape");

            var shape1 = shapeFactory.GetShape("Circle");
            shape1.Draw();

            var shape2 = shapeFactory.GetShape("RectAngle");
            shape2.Draw();

            var shape3 = shapeFactory.GetShape("Square");
            shape3.Draw();


            var colorFactory = FactoryProducer.GetFactory("Color");
            var color1 = colorFactory.GetColor("Red");
            color1.Fill();

            var color2 = colorFactory.GetColor("Green");
            color2.Fill();

            var color3 = colorFactory.GetColor("Blue");
            color3.Fill();
            Console.WriteLine();
        }
    }

    public interface IShape
    {
        void Draw();
    }

    public class RectAngle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Rectangle.Draw() method.");
        }
    }

    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Square.Draw() method.");
        }
    }

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Circle.Draw() method.");
        }
    }


    public interface IColor
    {
        void Fill();
    }

    public class Red : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Red::Fill() method.");
        }
    }

    public class Green : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Green::Fill() method.");
        }
    }

    public class Blue : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Blue::Fill() method.");
        }
    }


    public abstract class AbstractFactory
    {
        public abstract IColor GetColor(string color);
        public abstract IShape GetShape(string shape);
    }

    public class ShapeFactory : AbstractFactory
    {
        public override IColor GetColor(string color)
        {
            throw new NotImplementedException();
        }

        public override IShape GetShape(string shape)
        {
            switch (shape)
            {
                case "RectAngle": return new RectAngle();
                case "Square": return new Square();
                case "Circle": return new Circle();
                default: throw new NotImplementedException();
            }
        }
    }

    public class ColorFactory : AbstractFactory
    {
        public override IColor GetColor(string color)
        {
            switch (color)
            {
                case "Red": return new Red();
                case "Green": return new Green();
                case "Blue": return new Blue();
                default: throw new NotImplementedException();
            }

        }

        public override IShape GetShape(string shape)
        {
            throw new NotImplementedException();
        }
    }

    public class FactoryProducer
    {
        public static AbstractFactory GetFactory(string choice)
        {
            switch (choice)
            {
                case "Shape": return new ShapeFactory();
                case "Color": return new ColorFactory();
                default: throw new NotImplementedException();
            }
        }
    }
}
