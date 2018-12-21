using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace jonny.AoC.Day16 {
    public class InstructionRunner {
        public int Run(Dictionary<int, Instruction> instructions, string[] program) {
            Regex r = new Regex("(\\d+) (\\d+) (\\d+) (\\d+)");
            int[] registers = new int[4];
            foreach(string line in program) {
                Match m = r.Match(line);
                int op = int.Parse(m.Groups[1].Value);
                int source1 = int.Parse(m.Groups[2].Value);
                int source2 = int.Parse(m.Groups[3].Value);
                int target = int.Parse(m.Groups[4].Value);

                var instruction = instructions[op];
                registers = instruction.Execute(source1, source2, target, registers);
            }
            return registers[0];
        }
    }
}