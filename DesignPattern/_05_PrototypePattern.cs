
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesignPattern._05_Prototype
{
    /// <summary>
    /// 原型模式
    /// </summary>
    public class _05_PrototypePattern
    {
        public static void Run()
        {
            Console.WriteLine(nameof(_05_PrototypePattern));

            ShapeCache.LoadCache();

            Shape shape1 = ShapeCache.GetShape("1");
            Console.WriteLine($"Shape:{shape1.Get_Type()}");
            shape1.Draw();

            Shape shapeA = ShapeCache.GetShape("1");
            Console.WriteLine($"Shape:{shapeA.Get_Type()}");
            shapeA.Draw();

            Shape shapeB = ShapeCache.GetShape("1");
            Console.WriteLine($"Shape:{shapeB.Get_Type()}");
            shapeB.Draw();

            Shape shape2 = ShapeCache.GetShape("2");
            Console.WriteLine($"Shape:{shape2.Get_Type()}");
            shape2.Draw();

            Shape shape3 = ShapeCache.GetShape("3");
            Console.WriteLine($"Shape:{shape3.Get_Type()}");
            shape3.Draw();

            Console.WriteLine();
        }
    }

    public abstract class Shape : ICloneable
    {
        private string _id;
        protected string Type;
        public abstract void Draw();

        public string Get_Type() => Type;

        public string GetId() => _id;

        public void SetId(string id) { _id = id; }
        public object Clone()
        {
            Object clone = null;
            try
            {
                clone = MemberwiseClone();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            return clone;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle() => Type = nameof(Rectangle);
        public override void Draw() => Console.WriteLine($"Inside {nameof(Rectangle)}.Draw() Method");
    }

    public class Square : Shape
    {
        public Square()
        {
            Console.WriteLine("创建对象");
            Type = nameof(Square);
        }
        public override void Draw() => Console.WriteLine($"Inside {nameof(Square)}.Draw() Method");
    }

    public class Circle : Shape
    {
        public Circle() => Type = nameof(Circle);
        public override void Draw() => Console.WriteLine($"Inside {nameof(Circle)}.Draw() Method");
    }

    public class ShapeCache
    {
        private static Dictionary<string, Shape> dictionary = new Dictionary<string, Shape>();
        public static Shape GetShape(string shapeId)
        {
            Shape cacheShape = dictionary[shapeId];
            return cacheShape.Clone() as Shape;
        }

        public static void LoadCache()
        {
            var circle = new Circle();
            circle.SetId("1");
            dictionary.Add(circle.GetId(), circle);

            var square = new Square();
            square.SetId("2");
            dictionary.Add(square.GetId(), square);

            var rectangle = new Rectangle();
            rectangle.SetId("3");
            dictionary.Add(rectangle.GetId(), rectangle);
        }
    }
}