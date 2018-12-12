using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace jonny.AoC.Day12 {
    public class PlantBreeder{
        private string currentState;
        private IEnumerable<Regex> rules;
        public int Offset {get; private set;}

        public PlantBreeder(string unparsed) {
            Regex r = new Regex("initial state: ([.#]+)");
            currentState = r.Match(unparsed).Groups[1].Value;
            r = new Regex("([.#]+) => #");
            rules = r.Matches(unparsed)
                .Select(m => new Regex(m.Groups[1].Value.Replace(".", "[.]")));
        }

        public PlantBreeder(string initialState, string[] rules) {
            this.currentState = initialState;
            this.rules = rules.Select(rule => new Regex(rule.Replace(".", "[.]")));
        }

        public string Run(long generations) {
            for(long i=0; i<generations; i++) {
                OneGeneration();
            }
            return currentState;
        }
        public string OneGeneration() {
            currentState = $"....{currentState}....";
            var builder = new System.Text.StringBuilder();
            for(int i=0; i< currentState.Length-5; i++) {
                string substring = currentState.Substring(i, 5);
                if (rules.Any(rule => rule.Match(substring).Success)) {
                    builder.Append("#");
                } else {
                    builder.Append(".");
                }
            }
            string nextState = builder.ToString();
            int firstPot = nextState.IndexOf('#');
            Offset += firstPot -2;
            currentState = builder.ToString().Trim('.');
            return currentState;
        }

        public long Value() {
            long result = 0;
            for (int i = 0; i < currentState.Length; i++)
            {
                if (currentState[i] =='#') {
                    result += i + Offset;
                }
            }
            return result;
        }

        public long ValueAfter(long generations) {
            int i;
            bool steadyState = false;
            long previousValue = Value();
            long previousDiff = 0;
            for(i=0; i<generations && ! steadyState; i++) {
                OneGeneration();
                long value = Value();
                long diff = value - previousValue;
                if (diff == previousDiff) {
                    steadyState = true;
                } else {
                    previousValue = value;
                    previousDiff = diff;
                }
            }

            return (generations - i)* previousDiff + Value();
        }
    }
}