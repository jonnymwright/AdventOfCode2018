using System;
using System.Linq;
using jonny.AoC.Day9;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //var lines = System.IO.File.ReadAllText("Day8/input.txt");
            MarblesGame game = new MarblesGame(418);
            Console.WriteLine(game.Play(7076900).Max());
        }
    }
}
