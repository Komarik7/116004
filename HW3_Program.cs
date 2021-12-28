using System;

namespace HW3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double x, y;
            Console.WriteLine("Введите х:");
            x = double.Parse(Console.ReadLine());
            y = (Math.Sqrt(Math.Sin(x) * Math.Sin(x) + 4) + Math.Tan(x)) / (Math.Cos(x) * Math.Cos(x) + 4);
            Console.WriteLine("y="+ y);


        }
    }
}
