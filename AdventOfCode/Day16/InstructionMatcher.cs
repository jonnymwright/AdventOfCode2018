using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace jonny.AoC.Day16 {
    public class InstructionMatcher
    {
        public int registerSize = 4;

        public Dictionary<int, Instruction> Mapping {get;} = new Dictionary<int, Instruction>();

        public void MatchNumbersToInstruction(string[] operations) {
            foreach (var op in operations)
            {
                var matches = MatchingCodes(op);
                if (matches.Except(Mapping.Values).Count() == 1) {
                    var r = new Regex("Before: \\[(\\d), (\\d), (\\d), (\\d)\\] (\\d?\\d) (\\d) (\\d) (\\d) After:  \\[(\\d), (\\d), (\\d), (\\d)\\]");
                    var match = r.Match(op);
                    int code = int.Parse(match.Groups[registerSize + 1].Value);
                    Mapping[code] = matches.Except(Mapping.Values).Single();
                }
            }
        }

        public Instruction[] MatchingCodes(string input) {
            int[] inputRegister;
            int source1;
            int source2;
            int target;
            int[] outputRegister;
            (inputRegister, outputRegister, _, source1, source2, target) = ParseInput(input);

            return MatchingCodes(inputRegister, outputRegister, source1, source2, target);
        }

        public Instruction[] MatchingCodes(int[] inputRegister, int [] outputRegister, int source1, int source2, int target) {
            var result = Instruction.GetAllInstruction();
            result = result.Where(ins => PredictionMatchesActual(ins.Execute(source1, source2, target, inputRegister), outputRegister))
                .ToArray();
            return result;
        }

        private bool PredictionMatchesActual(int[] prediction, int[] actual) {
            return prediction.Zip(
                actual,
                (p, a) => p == a)
                .Aggregate((a,b)=>a&&b);
        }

        private (int[], int[], int, int, int, int) ParseInput(string input) {
            var r = new Regex("Before: \\[(\\d), (\\d), (\\d), (\\d)\\] (\\d?\\d) (\\d) (\\d) (\\d) After:  \\[(\\d), (\\d), (\\d), (\\d)\\]");
            var match = r.Match(input);
            int[] inputRegister = match.Groups
                .Skip(1)
                .Take(registerSize)
                .Select(g => int.Parse(g.Value))
                .ToArray();
            int code = int.Parse(match.Groups[registerSize + 1].Value);
            int source1 = int.Parse(match.Groups[registerSize + 2].Value);
            int source2 = int.Parse(match.Groups[registerSize + 3].Value);
            int target = int.Parse(match.Groups[registerSize + 4].Value);
            int[] outputRegister = match.Groups
                .Skip(9)
                .Take(registerSize)
                .Select(g => int.Parse(g.Value))
                .ToArray();

            return (inputRegister, outputRegister, code, source1, source2, target);
        }
    }
}