using System;
using System.Linq;

namespace jonny.AoC.Day16 {
    public abstract class Instruction
    {
        private static Instruction[] all = new Instruction[] {
                new Addr(),
                new Addi(),
                new Mulr(),
                new Muli(),
                new Banr(),
                new Bani(),
                new Borr(),
                new Bori(),
                new Setr(),
                new Seti(),
                new Gtir(),
                new Gtri(),
                new Gtrr(),
                new Eqir(),
                new Eqri(),
                new Eqrr(),
            };

        protected virtual bool source1IsLiteral => false;
        protected virtual bool source2IsLiteral => true;

        protected abstract Func<int, int, int> op {get;}

        public int[] Execute(int source1, int source2, int target, int[] registers) {
            registers = registers.ToArray();
            int arg1 = source1IsLiteral ? source1 : registers[source1];
            int arg2 = source2IsLiteral ? source2 : registers[source2];
            registers[target] = op(arg1, arg2);
            return registers;
        }

        public static Instruction[] GetAllInstruction() {
            return all;
        }
    }

    public class Addr : Addi {
        protected override bool source2IsLiteral => false;
    }

    public class Addi : Instruction {
        protected override Func<int, int, int> op { get { return (a,b) => a+b;}}
    }

    public class Mulr : Muli {
        protected override bool source2IsLiteral => false;
    }

    public class Muli : Instruction {
        protected override Func<int, int, int> op { get { return (a,b) => a*b;}}
    }

    public class Banr : Bani {
        protected override bool source2IsLiteral => false;
    }

    public class Bani : Instruction {
        protected override Func<int, int, int> op { get { return (a,b) => a&b;}}
    }

    public class Borr : Bori {
        protected override bool source2IsLiteral => false;
    }

    public class Bori : Instruction {
        protected override Func<int, int, int> op { get { return (a,b) => a|b;}}
    }

    public class Setr : Seti {
        protected override bool source1IsLiteral => false;
    }

    public class Seti : Instruction {
        protected override bool source1IsLiteral => true;
        protected override Func<int, int, int> op { get { return (a,b) => a;}}
    }

    public class Gtir : Gtri {
        protected override bool source1IsLiteral => true;
        protected override bool source2IsLiteral => false;
    }

    public class Gtri : Instruction {
        protected override Func<int, int, int> op { get { return (a,b) => a>b ? 1 : 0;}}
    }

    public class Gtrr : Gtri {
        protected override bool source2IsLiteral => false;
    }

    public class Eqir : Eqri {
        protected override bool source1IsLiteral => true;
        protected override bool source2IsLiteral => false;
    }

    public class Eqri : Instruction {
        protected override Func<int, int, int> op { get { return (a,b) => a==b ? 1 : 0;}}
    }

    public class Eqrr : Eqri {
        protected override bool source2IsLiteral => false;
    }
}