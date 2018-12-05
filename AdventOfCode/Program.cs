using System;
using System.Linq;
using jonny.AoC.Day5;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllText("Day5/input.txt");
            PolymerReducer watchWatcher = new PolymerReducer(lines);
            Console.WriteLine(watchWatcher.RemoveAndShorten().Count());
        }
    }
}
