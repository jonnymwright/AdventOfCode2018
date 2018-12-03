using System;
using jonny.AoC.Day3;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("Day3/input.txt");
            var claimResolver = new ClaimResolver(lines);
            claimResolver.PlaceClaims();
            Console.WriteLine(string.Join(' ', claimResolver.NonOverlappingClaims));
        }
    }
}
