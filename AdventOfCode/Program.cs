using System;
using System.Linq;
using jonny.AoC.Day19;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("Day19/input.txt");
             var slowRunner = new JumpingInstructionRunner();
            Console.WriteLine(slowRunner.Run(lines));
            var fastRunner = new DecompiledRunner();
            Console.WriteLine(fastRunner.Run(1017));
            Console.WriteLine(fastRunner.Run(10551417));
        }
    }
}
