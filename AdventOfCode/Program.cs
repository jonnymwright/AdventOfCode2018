using System;
using System.Linq;
using jonny.AoC.Day13;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("Day13/input.txt");
            var tracker = new TrackTracker(lines);
            var survivor = tracker.RunUntilOneLeft();
            Console.WriteLine($"{survivor.Item1}, {survivor.Item2}");
        }
    }
}
