using System;
using kalkulator;

namespace ConsoleApplication1
{
    class Logger : INterfejs
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Class1 c = new Class1();
            Console.WriteLine(c.Dodaj(2, 5));
        }
    }
}