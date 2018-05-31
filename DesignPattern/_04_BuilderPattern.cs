using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._04_Builder
{
    public class _04_BuilderPattern
    {
        public static void Run()
        {
            Console.WriteLine(nameof(_04_BuilderPattern));



            Console.WriteLine();
        }
    }

    public interface Packing
    {
        string Pack();
    }

    public interface Item
    {
        string Name();
        Packing Packing();
        float Price();
    }

    public class Wrapper : Packing
    {
        public string Pack()
        {
            return "Wrapper";
        }
    }

    public class Bottle : Packing
    {
        public string Pack()
        {
            return "Bottle";
        }
    }


}
