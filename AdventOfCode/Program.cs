using System;
using System.Linq;
using jonny.AoC.Day16;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("Day16/Input1.txt");
            lines = lines.Select((line, i) => new {Line = line, I = i})
                .GroupBy(pair => pair.I/4)
                .Select(group => string.Join(" ", group.Select(pair => pair.Line)))
                .ToArray();
            
            var matcher = new InstructionMatcher();
            var result = lines.Where(line => matcher.MatchingCodes(line).Count() == 3);
            Console.WriteLine(result.Count());
            matcher.MatchNumbersToInstruction(lines);
            lines = System.IO.File.ReadAllLines("Day16/Input2.txt");
            Console.WriteLine(new InstructionRunner().Run(matcher.Mapping, lines));
        }
    }
}
