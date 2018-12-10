using System.Text.RegularExpressions;

namespace jonny.AoC.Day10 {
    public class LightPoint{
        public int X {get; private set;}
        public int Y {get; private set;}

        private int velX;
        private int velY;
        public LightPoint(string unparsed) {
            //position=< 9,  1> velocity=< 0,  2>
            Regex r = new Regex("position=<\\s*(-?\\d+),\\s*(-?\\d+)> velocity=<\\s*(-?\\d+),\\s*(-?\\d+)>");
            var match = r.Match(unparsed);
            X = int.Parse(match.Groups[1].Value);
            Y = int.Parse(match.Groups[2].Value);
            velX = int.Parse(match.Groups[3].Value);
            velY = int.Parse(match.Groups[4].Value);
        }

        internal void Tick() {
            X += velX;
            Y += velY;
        }
    }
}