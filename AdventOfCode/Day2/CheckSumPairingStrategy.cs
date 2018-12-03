using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day2
{
    public class CheckSumPairingStrategy : IPairingStrategy<string>
    {
        public IEnumerable<System.Tuple<string, string>> GetPairs(IEnumerable<string> collection)
        {
            var groups = collection.GroupBy(id => id.GroupBy(character => character)
                    .Where(group => group.Count() == 2)
                    .Count())
                .ToDictionary(group => group.Key);
            int mostPairs = groups.Max(kvp => kvp.Key);

            System.Console.WriteLine(string.Join(" ", groups.Select(g => $"{g.Key}: {g.Value.Count()}")));

            var result = Enumerable.Empty<System.Tuple<string, string>>();
            var niavePairer = new NiavePairingStrategy<string>();
            for (int i = 0; i <= mostPairs; i++)
            {
                IGrouping<int, string> current;
                if (groups.TryGetValue(i, out current))
                {
                    result = result.Concat(niavePairer.GetPairs(current));

                    IGrouping<int, string> next;
                    if (groups.TryGetValue(i+1, out next))
                    {
                        result = result.Concat(niavePairer.GetPairs(current, next));
                    }
                }
            }

            return result;
        }
    }
}