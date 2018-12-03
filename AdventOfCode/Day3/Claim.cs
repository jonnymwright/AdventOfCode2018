using System.Text.RegularExpressions;

namespace jonny.AoC.Day3 {
    internal class Claim {

        public string Id {get; private set;}
        public int X {get; private set;}
        public int Y {get; private set;}
        public int Length {get; private set;}
        public int Height {get; private set;}

        internal Claim(string unparsed) {
            var regexPattern = "#(\\d+) @ (\\d+),(\\d+): (\\d+)x(\\d+)";
            Regex r = new Regex(regexPattern);
            var match = r.Match(unparsed);
            if (match.Groups.Count != 6) {
                throw new System.ArgumentException($"Input {unparsed} does not match regex pattern {regexPattern}");
            }

            Id = match.Groups[1].Value;
            X = int.Parse(match.Groups[2].Value);
            Y = int.Parse(match.Groups[3].Value);
            Length = int.Parse(match.Groups[4].Value);
            Height = int.Parse(match.Groups[5].Value);
        }
    }
}