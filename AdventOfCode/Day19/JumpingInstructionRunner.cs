using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using jonny.AoC.Day16;

namespace jonny.AoC.Day19 {
    public class JumpingInstructionRunner {
        public int Run(string[] program) {
            Regex r = new Regex("#ip (\\d)");
            Match m = r.Match(program[0]);
            int instructionPointer = int.Parse(m.Groups[1].Value);
            program = program.Skip(1)
                .ToArray();

            r = new Regex("(\\w+) (\\d+) (\\d+) (\\d+)");
            Dictionary<string, Instruction> instructions =
                Instruction.GetAllInstruction().ToDictionary(ins => ins.GetType().Name.ToLower());
            int[] registers = new int[6];
            while(0 <= registers[instructionPointer] && registers[instructionPointer] < program.Length) {
                m = r.Match(program[registers[instructionPointer]]);
                string op = m.Groups[1].Value;
                int source1 = int.Parse(m.Groups[2].Value);
                int source2 = int.Parse(m.Groups[3].Value);
                int target = int.Parse(m.Groups[4].Value);

                var instruction = instructions[op];
                registers = instruction.Execute(source1, source2, target, registers);
                registers[instructionPointer]++;
            }
            return registers[0];
        }
    }
}