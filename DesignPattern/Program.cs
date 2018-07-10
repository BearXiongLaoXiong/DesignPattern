using System;
using DesignPattern._01_Factory;
using DesignPattern._02_AbstractFactory;
using DesignPattern._03_Singleton;
using DesignPattern._04_Builder;
using DesignPattern._05_Prototype;
using DesignPattern._06_Adapter;
using DesignPattern._07_Bridge;
using DesignPattern._08_Filter;
using DesignPattern._09_Composite;
using DesignPattern._10_Decorator;

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
            _04_BuilderPattern.Run();
            _05_PrototypePattern.Run();

            //结构型模式
            _06_AdapterPattern.Run();
            _07_BridgePattern.Run();
            _08_FilterPattern.Run();
            _09_CompositePattern.Run();
            _10_DecoratorPattern.Run();
            //行为型模式
        Console.ReadLine();
        }
    }
}
