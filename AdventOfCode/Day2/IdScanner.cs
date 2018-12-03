using System.Linq;
namespace jonny.AoC.Day2
{
    public class IdScanner
    {
        private readonly string[] ids;
        public IPairingStrategy<string> PairGenerator { get; set; }

        public IdScanner(string[] ids)
        {
            this.ids = ids;
            PairGenerator = new CheckSumPairingStrategy();
            //PairGenerator = new NiavePairingStrategy<string>();
        }

        public int GetCheckSum()
        {
            int doubles = 0, triples = 0;

            foreach (string id in ids)
            {
                var counts = id.GroupBy(character => character)
                    .Select(group => group.Count());
                if (counts.Contains(2))
                {
                    doubles++;
                }
                if (counts.Contains(3))
                {
                    triples++;
                }
            }

            return doubles * triples;
        }

        public string FindCommonId()
        {
            int length = ids[0].Length;
            var pairs = PairGenerator.GetPairs(ids);
            System.Console.WriteLine(pairs.Count());
            foreach (var pair in pairs)
            {
                string candidate1 = pair.Item1;
                string candidate2 = pair.Item2;

                var matches = candidate1.Zip(candidate2, (a, b) => new { char1 = a, char2 = b })
                    .Where(characterPair => characterPair.char1 == characterPair.char2);
                if (matches.Count() == length - 1)
                {
                    return string.Concat(matches.Select(characterPair => characterPair.char1));
                }
            }
            return "";
        }
    }
}