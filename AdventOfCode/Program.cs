using System;
using System.Linq;
using jonny.AoC.Day20;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("Day20/input.txt");
            
            DoorWalker walker = new DoorWalker();
            walker.Walk(lines[0]);
            new MapOutput().ToBitMap(
                walker.ToDistanceArray()
            );
        }
    }
}
