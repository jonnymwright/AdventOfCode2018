using System;
using System.Linq;
using jonny.AoC.Day17;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("Day17/input.txt");
            
            var settler = new WaterSettler(lines);
            System.IO.File.WriteAllText("day17/empty.txt", settler.ToString());
            Console.WriteLine(settler.RunUntilFull());
            System.IO.File.WriteAllText("day17/full.txt", settler.ToString());
            
        }
    }
}
