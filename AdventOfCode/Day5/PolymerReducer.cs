using System;
using System.Linq;

namespace jonny.AoC.Day5
{
    public class PolymerReducer
    {

        private string polymer;
        public PolymerReducer(string polymer)
        {

            this.polymer = polymer;
        }


        public string Shorten()
        {
            polymer = RemovePairs(polymer);
            return polymer;
        }

        public string RemoveAndShorten() {
            Shorten();

            string bestString = "";
            int bestLength = int.MaxValue;
            for (char c = 'a'; c <= 'z'; c++) {
                string candidate = string.Concat(
                    polymer.Where(character => character != c && character != c - 32));
                candidate = RemovePairs(candidate);
                if (candidate.Length < bestLength) {
                    bestLength = candidate.Length;
                    bestString = candidate;
                }
            }

            return bestString;
        }

        private string RemovePairs(string input) {
            bool matchFound = true;
            while (matchFound)
            {
                var match = input.Select((c, i) => new { Character = c, Index = i })
                    .Zip(input.Skip(1), (a, b) => new { First = a.Character, Second = b, Index = a.Index })
                    .FirstOrDefault(pair => System.Math.Abs(pair.First - pair.Second) == 32);

                if (match != null)
                {
                    input = input.Remove(match.Index, 2);
                } else {
                    matchFound = false;
                }
            }
            return input;
        } 
    }
}