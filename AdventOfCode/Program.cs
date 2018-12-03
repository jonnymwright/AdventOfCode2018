using System;
using jonny.AoC.Day2;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("Day2/input.txt");
            Console.WriteLine(new IdScanner(lines).FindCommonId());
        }
    }
}
