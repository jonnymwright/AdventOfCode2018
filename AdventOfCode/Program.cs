using System;
using System.Linq;
using jonny.AoC.Day14;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("Day13/input.txt");
            var board = new RecipeBoard(new[] {3, 7});
            Console.WriteLine(board.Score(640441));
            Console.WriteLine(board.BeforeScore("640441"));
            
        }
    }
}
