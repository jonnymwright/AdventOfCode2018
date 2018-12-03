using System.Linq;
namespace jonny.AoC.Day2 {
    public class IdScanner {

        private readonly string[] ids;
        public IdScanner(string[] ids) {
            this.ids = ids;
        }

        public int GetCheckSum() {
            int doubles = 0, triples = 0;

            foreach(string id in ids) {
                var counts = id.GroupBy(character => character)
                    .Select(group => group.Count());
                if (counts.Contains(2)) {
                    doubles++;
                }
                if (counts.Contains(3)) {
                    triples++;
                }
            }

            return doubles * triples;
        }

        public string FindCommonId() {
            int length = ids[0].Length;
            for (int i = 0; i < ids.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    string candidate1 = ids[i];
                    string candidate2 = ids[j];

                    var matches = candidate1.Zip(candidate2, (a, b) => new {char1 = a, char2 = b})
                        .Where(pair => pair.char1 == pair.char2);
                    if (matches.Count() == length - 1) {
                        return string.Concat(matches.Select(pair => pair.char1));
                    }
                }
            }
            return "";
        }
    }
}