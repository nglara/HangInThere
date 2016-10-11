using System;
using System.Threading;

namespace HangInThere
{
    public static class Car
    {
        public static void Run()
        {
            Console.WriteLine("Running...");
            Thread.Sleep(3000);
            Console.WriteLine("Stopped!");
        }

        public static void ChangeOil()
        {
            Console.WriteLine("Changing Oil...");
            Thread.Sleep(5000);
            Console.WriteLine("Oil Level is now 100%");
        }

        public static void Wash()
        {
            Console.WriteLine("Washing...");
            Thread.Sleep(8000);
            Console.WriteLine("Car Wash Complete!");
        }
    }
}
