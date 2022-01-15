using System;

namespace Зачёт_В25
{
    class MainClass
    {
        public static void Main(string[] args)
        {


            Console.WriteLine("Проверка работы функции S(n):");
            long sn1 = 1;
            for (long i = 2; i <= 6; i++)
            {
                sn1 += Qn(i);
                Console.WriteLine(i + " - " + sn1);
            }
            Console.WriteLine("Выполнение программы:");
            long sn = 1;
            for (long i = 2; i <= 1000000; i++)
            {
                sn += Qn(i);
            }
            Console.WriteLine(sn % 1000000000);
        }

            static long Qn(long n)
            {
                long result = 1;
                for (long i = 2; i <= n; i++)
                {
                    if (n % i == 0)
                    { result += i * i; }
                }
                return result;
            }




        
    }
}
