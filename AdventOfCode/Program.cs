using System;
using System.Linq;
using jonny.AoC.Day12;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllText("Day12/input.txt");
            var breeder = new PlantBreeder(lines);
            Console.WriteLine(breeder.ValueAfter(20));
            breeder = new PlantBreeder(lines);
            Console.WriteLine(breeder.ValueAfter(50000000000));
        }
    }
}
