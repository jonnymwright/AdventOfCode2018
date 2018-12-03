using System;
using jonny.AoC.Day2;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("Day2/input.txt");
            IdScanner scanner = new IdScanner(lines);
            Console.WriteLine(string.Join(' ', scanner.FindCommonId()));
            //scanner.PairGenerator = new NiavePairingStrategy<string>();
            //Console.WriteLine(string.Join(' ', scanner.FindCommonId()));
        }
    }
}
