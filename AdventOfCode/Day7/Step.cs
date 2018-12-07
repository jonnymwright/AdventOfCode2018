using System.Text.RegularExpressions;
using System.Linq;

namespace jonny.AoC.Day7
{
    public class Step
    {
        public char Before { get; }
        public char After { get; }

        public Step(string unparsed)
        {
            Regex r = new Regex("Step (.) must be finished before step (.) can begin.");
            Match m = r.Match(unparsed);
            Before = m.Groups[1].Value.First();
            After = m.Groups[2].Value.First();
        }
    }
}