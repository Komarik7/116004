using System;

namespace Task2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int a, b, C, c, P;
            double S;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            C = int.Parse(Console.ReadLine());
            S = a * b / 2 * Math.Sin(C);
            c = (int)Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 2 * a * b * Math.Cos(C));
            P = a + b + c;
            Console.WriteLine("Площадь:"+S);
            Console.WriteLine("Периметр:"+P);
            Console.ReadKey();
        }
    }
}
