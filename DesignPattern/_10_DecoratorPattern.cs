using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._10_Decorator
{
    [DataContract(Name = "装饰器模式")]
    public class _10_DecoratorPattern
    {
        public static void Run()
        {
            Console.WriteLine(typeof(_10_DecoratorPattern).GetClassName());

            IShape circle = new Circle();

            IShape redCircle = new RedShapeDecorator(new Circle());

            IShape redRectangle = new RedShapeDecorator(new Rectangle());

            Console.WriteLine("Circle with normal border");
            circle.Draw();

            Console.WriteLine("\nCircle of red border");
            redCircle.Draw();

            Console.WriteLine("\nRectangle of red border");
            redRectangle.Draw();

            Console.WriteLine();
        }
    }

    public interface IShape
    {
        void Draw();
    }

    public class Rectangle : IShape
    {
        public void Draw() => Console.WriteLine("IShap=>Rectangle");
    }

    public class Circle : IShape
    {
        public void Draw() => Console.WriteLine("IShap=>Circle");
    }

    public abstract class ShapeDecorator : IShape
    {
        protected IShape _shape;
        public ShapeDecorator(IShape shape) => _shape = shape;
        public virtual void Draw() => _shape.Draw();
    }

    public class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(IShape shape) : base(shape) { }

        public override void Draw()
        {
            _shape.Draw();
            SetRedBorder(_shape);
        }

        private void SetRedBorder(IShape shape) => Console.Write("Border Color:Red");
    }

    public class A
    {
        public virtual  void Method() => Console.WriteLine("A");
    }

    public class B:A
    {
        public new void Method() => Console.WriteLine("B");
    }
}
