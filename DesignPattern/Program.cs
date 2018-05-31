using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern._01_Factory;
using DesignPattern._02_AbstractFactory;
using DesignPattern._03_Singleton;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建型模式
            _01_FactoryPattern.Run();
            _02_AbstractFactoryPattern.Run();
            _03_SingletonPattern.Run();

            //结构型模式

            //行为型模式
            Console.ReadLine();
        }
    }
}
