using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._07_Bridge
{
    public class _07_BridgePattern
    {
        public static void Run()
        {
            Console.WriteLine(nameof(_07_BridgePattern));

            var redCircle = new Circle(100, 100, 10, new RedCircle());
            var greenCircle = new Circle(100, 100, 10, new GreenCircle());
            redCircle.Draw();
            greenCircle.Draw();

            Console.WriteLine();
        }
    }

    public interface IDrawApi
    {
        void DrawCircle(int radius, int x, int y);
    }

    public class RedCircle : IDrawApi
    {
        public void DrawCircle(int radius, int x, int y) => Console.WriteLine($"Drawing Circle[cole:red,radius:{radius},x:{x},y:{y}]");
    }

    public class GreenCircle : IDrawApi
    {
        public void DrawCircle(int radius, int x, int y) => Console.WriteLine($"Drawing Circle[cole:green,radius:{radius},x:{x},y:{y}]");
    }

    public abstract class Shape
    {
        protected IDrawApi DrawApi;
        protected Shape(IDrawApi drawApi) => DrawApi = drawApi;

        public abstract void Draw();
    }

    public class Circle : Shape
    {
        private int _x, _y,_radius;
        public Circle(int x, int y, int radius, IDrawApi drawApi)
            : base(drawApi)
        {
            _x = x;
            _y = y;
            _radius = radius;
        }
        public override void Draw() => DrawApi.DrawCircle(_radius, _x, _y);
    }
}
