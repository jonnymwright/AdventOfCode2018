using System;
using System.Linq;
using jonny.AoC.Day10;
using jonny.AoC.Day11;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllText("Day10/input.txt");
            //PowerGrid grid = new PowerGrid(300,300,1308);
            var aligner = new StarAligner(lines);
            System.Console.WriteLine(aligner.CreateWordFromPoints());
        }
    }
}
