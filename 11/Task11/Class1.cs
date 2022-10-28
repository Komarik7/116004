using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    public class Tour
    {
        public string Name { get; }
        public readonly int Code;
        public int Dur;
        public List<string> Plan;
        public TransportType Transport;
        public double Price { get; }
        public DateTime Start;
        public string Description;
        public DateTime End 
        { get
            {
                return Start.AddDays(Dur);
            } 
        }
        public Tour(string name, int code, List<string> plan, TransportType transport, int duration)
        {
            Name = name;
            Code = code;
            Plan = plan;
            Transport = transport;
            Dur = duration;
        }
        public override string ToString()
        {
            return $"{Name} {Code}";
        }
        public void PrintInfo()
        {
            Console.WriteLine(this);
            Console.WriteLine($"Даты: {Start} - {End} ({Dur} days)");
            Console.WriteLine($"Цена: {Price}$");
            Console.WriteLine(Description);
            Console.WriteLine("Вы посетите:");
            foreach (string i in Plan)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"Транспорт: {Transport}");
        }
    }
}
