using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day16 {
    public class InstructionMatcher
    {
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
    }
}