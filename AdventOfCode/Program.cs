using System;
using System.Linq;
using jonny.AoC.Day18;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("Day18/input.txt");
            
            var lumberer = new LumberConstuctor(lines);
            Console.WriteLine(lumberer.Run(1000000000));
            
        }
    }
}
