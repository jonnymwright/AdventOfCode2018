using System;
using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day10 {
    public class StarAligner{

        private LightPoint[] lightPoints;
        private LightPoint[] bestArrangement;
        private int bestAlignment;
        public StarAligner(string lightPoints) {
            this.lightPoints = lightPoints.Split("\r")
                .Select(line => new LightPoint(line))
                .ToArray();
        }

        public string CreateWordFromPoints() {
            MostAlignedSecond();
            var (xMin, xMax, yMin, yMax) = GetBounds(bestArrangement);
            xMax -= xMin;
            xMax ++;
            yMax -= yMin;
            yMax ++;

            char[,] points = new char[yMax, xMax];
            for(int y=0; y<yMax; y++) {
                for(int x=0; x<xMax; x++) {
                    points[y,x] = ' ';
                }
            }
            foreach(var point in bestArrangement) {
                points[point.Y - yMin, point.X - xMin] = '#';
            }
            var buidler = new System.Text.StringBuilder();
            for(int y=0; y<yMax; y++) {
                for(int x=0; x<xMax; x++) {
                    buidler.Append(points[y,x]);
                }
                buidler.Append("\r\n");
            }
            return buidler.ToString();
        }

        public int MostAlignedSecond() {
            int result = -1;
            bestAlignment = int.MaxValue;
            int strikes = 10;
            var localCopy = lightPoints.Select(x => new LightPoint(x)).ToArray();

            for (int i = 0; strikes > 0; i++) {
                var (xMin, xMax, yMin, yMax) = GetBounds(localCopy);

                int currentAlignment = (xMax - xMin) + (yMax - yMin);
                if (currentAlignment <= bestAlignment) {
                    bestAlignment = currentAlignment;
                    result = i;
                    bestArrangement = localCopy.Select(x => new LightPoint(x)).ToArray();
                    strikes = 10;
                } else {
                    strikes --;
                }
                
                foreach(var point in localCopy) {
                    point.Tick();
                }
            }
            return result;
        }

        private (int, int, int, int) GetBounds(IEnumerable<LightPoint> points) {
            int xMin = points.Select(p => p.X).Min();
            int xMax = points.Select(p => p.X).Max();
            int yMin = points.Select(p => p.Y).Min();
            int yMax = points.Select(p => p.Y).Max();

            return (xMin, xMax, yMin, yMax);
        }
    }
}