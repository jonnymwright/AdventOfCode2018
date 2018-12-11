using System;
using System.Linq;
using jonny.AoC.Day8;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllText("Day8/input.txt");
            Node node = new Node(lines);
            Console.WriteLine(node.SumValue());
        }
    }
}
