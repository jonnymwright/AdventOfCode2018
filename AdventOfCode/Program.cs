using System;
using System.Linq;
using jonny.AoC.Day6;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllText("Day6/input.txt");
            CoordinateSpaceFinder finder = new CoordinateSpaceFinder(lines);
            Console.WriteLine(finder.LargestDangerousArea());
            Console.WriteLine(finder.LargestSafeArea(10000));
        }
    }
}
