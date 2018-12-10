using System;
using System.Linq;
using jonny.AoC.Day10;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllText("Day10/input.txt");
            StarAligner aligner = new StarAligner(lines);
            Console.WriteLine(aligner.MostAlignedSecond());
        }
    }
}
