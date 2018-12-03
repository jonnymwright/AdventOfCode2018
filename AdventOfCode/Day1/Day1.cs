using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day1
{
    public class Day1
    {

        private readonly int[] changes;
        public Day1(string frequencyChangeFileName)
        {
            changes = ReadFile(frequencyChangeFileName).ToArray(); ;
        }

        public Day1(int[] changes) {
            this.changes = changes;
        }

        private IEnumerable<int> ReadFile(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                yield return int.Parse(line);
            }
        }

        public int ResultingFrequency()
        {
            return changes.Aggregate((curr, next) => curr + next);
        }

        public int FirstRepeatingFrequency()
        {
            ISet<int> seenFrequencies = new HashSet<int>();
            bool foundMatch = false;
            int i = 0;
            int currentFrequency = 0;

            while (!foundMatch)
            {
                currentFrequency += changes[i];
                i++;
                if (i == changes.Length)
                {
                    i = 0;
                }

                if (seenFrequencies.Contains(currentFrequency)) {
                    foundMatch = true;
                } else {
                    seenFrequencies.Add(currentFrequency);
                }
            }

            return currentFrequency;
        }
    }
}