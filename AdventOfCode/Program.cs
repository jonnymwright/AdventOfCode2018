using System;
using jonny.AoC.Day4;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllText("Day4/input.txt");
            WatchWatcher watchWatcher = new WatchWatcher(lines);
            Console.WriteLine(watchWatcher.SleepiestMinute());
        }
    }
}
