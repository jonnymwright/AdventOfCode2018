using System.Collections.Generic;
using System.Linq;
using System.Text;

using jonny.AoC.Day1;

namespace jonny.AoC.Day18 {
    public class LumberConstuctor
    {
        private enum Acre {
            Open = 1,
            Trees = 10,
            Lumberyard = 100
        }

        private int height=0;
        private int width=0;
        private Acre[,] map;

        public LumberConstuctor(string[] unparsed) {
            height = unparsed.Length;
            width = unparsed[0].Length;
            map = new Acre[height, width];

            for (int y = 0; y < height; y++)
            {
                string row = unparsed[y];
                for (int x = 0; x < width; x++)
                {
                    switch(row[x]){
                        case '.': map[y,x] = Acre.Open;break;
                        case '|': map[y,x] = Acre.Trees;break;
                        case '#': map[y,x] = Acre.Lumberyard;break;
                    }
                }
            }
        }

        public void Tick() {
            Acre[,] nextMap = new Acre[height, width];
             for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int nieghbourSum = Neightbours(x, y).Cast<int>().Sum();
                    switch(map[y,x]){
                        case Acre.Open: 
                            nextMap[y,x] = nieghbourSum % 100 >= 30 ? Acre.Trees : Acre.Open;
                            break;
                        case Acre.Trees: 
                            nextMap[y,x] = nieghbourSum >= 300 ? Acre.Lumberyard : Acre.Trees;
                            break;
                        case Acre.Lumberyard: 
                            nextMap[y,x] = nieghbourSum >= 100 && nieghbourSum % 100 >= 10? Acre.Lumberyard : Acre.Open;
                            break;
                    }
                }
            }
            map = nextMap;
        }

        public int Run(int iterations) {
            int steadyState = 500;
            int i;
            for (i=0; i<iterations && i<steadyState; i++) {
                Tick();
            }
            if (i<steadyState){
                return Hash();
            } else {
                List<int> previous = new List<int>();
                Tick();
                i++;
                previous.Add(Hash());

                bool gotLoop = false;
                for ( ; i<iterations && !gotLoop; i++) {
                    Tick();
                    int hash = Hash();
                    
                    if (previous[0] == hash) {
                        gotLoop = true;
                    } else {
                        previous.Add(hash);
                    }
                }

                if (gotLoop){
                    int loopLength = previous.Count();
                    int remainingSteps = iterations - i;
                    remainingSteps = remainingSteps % loopLength;
                    return previous[remainingSteps];
                } else {
                    return Hash();
                }
            }
        } 

        private int Hash() {
            int trees = map.Cast<Acre>().Count(a => a == Acre.Trees);
            int yards = map.Cast<Acre>().Count(a => a == Acre.Lumberyard);
            return trees * yards;
        }
        private IEnumerable<Acre> Neightbours(int x, int y) {
            if (x > 0) {
                if (y>0) {
                    yield return map[y-1, x-1];
                }
                yield return map[y, x-1];
                if (y<height-1) {
                    yield return map[y+1, x-1];
                }
            }
            
            if (y>0) {
                yield return map[y-1, x];
            }
            if (y<height-1) {
                yield return map[y+1, x];
            }
            
            if (x < width-1) {
                if (y>0) {
                    yield return map[y-1, x+1];
                }
                yield return map[y, x+1];
                if (y<height-1) {
                    yield return map[y+1, x+1];
                }
            }
        }

        public override string ToString(){
            var builder = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    string s="";
                    switch(map[y,x]) {
                        case Acre.Open: s = ".";break;
                        case Acre.Trees: s = "|";break;
                        case Acre.Lumberyard: s = "#";break;
                    }
                    builder.Append(s);
                }
                builder.Append("\r");
            }
            return builder.ToString();
        }
    }
}