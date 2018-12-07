using System;
using System.Linq;
using jonny.AoC.Day7;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllText("Day7/input.txt");
            StepOrderer orderer = new StepOrderer(lines);
            Console.WriteLine(orderer.GetTimings(60,5));
        }
    }
}
