using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern._03_Singleton
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public class _03_SingletonPattern
    {
        public static void Run()
        {
            Console.WriteLine(nameof(_03_SingletonPattern));

            var obj = Signleton.GetInstance();
            obj.ShowMessage();
            Console.WriteLine("Thread.Sleep(2000);");
            Thread.Sleep(2000);
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
