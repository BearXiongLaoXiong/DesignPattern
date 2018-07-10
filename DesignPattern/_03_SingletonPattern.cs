using System;
using System.Runtime.Serialization;

namespace DesignPattern._03_Singleton
{
    [DataContract(Name = "单例模式")]
    public class _03_SingletonPattern
    {
        public static void Run()
        {
            Console.WriteLine(typeof(_03_SingletonPattern).GetClassName());

            var obj = Signleton.GetInstance();
            obj.ShowMessage();
            Console.WriteLine("Thread.Sleep(2000);");
            //Thread.Sleep(2000);
            obj.ShowMessage();
            Console.WriteLine();
        }
    }

    public class Signleton
    {
        private static readonly Signleton instance = new Signleton();
        private DateTime time = DateTime.Now;
        private Signleton() { }
        public static Signleton GetInstance()
        {
            return instance;
        }

        public void ShowMessage()
        {
            Console.WriteLine("Hellow World");
            Console.WriteLine(time.ToString("yyyy-MM-dd HH:mm:ss:sss"));
        }
    }
}
