using System;
using System.Linq;

namespace jonny.AoC.Day10 {
    public class StarAligner{

        private LightPoint[] lightPoints;
        public StarAligner(string lightPoints) {
            this.lightPoints = lightPoints.Split("\r")
                .Select(line => new LightPoint(line))
                .ToArray();
        }

        public int MostAlignedSecond() {
            int result = -1;
            int alignment = 0;
            bool goodAlignment = false;
            bool stillLooking = true;

            for (int i = 0; stillLooking; i++) {
                int xMin = lightPoints.Select(p => p.X).Min();
                int xMax = lightPoints.Select(p => p.X).Max();
                int yMin = lightPoints.Select(p => p.Y).Min();
                int yMax = lightPoints.Select(p => p.Y).Max();

                var sky = new LightPoint[yMax - yMin + 1, xMax - xMin + 1];
                foreach(var point in lightPoints) {
                    sky[point.Y - yMin, point.X - xMin] = point;
                }
                var withNeighbours = lightPoints.Where(point => 
                    (point.X != xMax && sky[point.Y - yMin, point.X - xMin + 1] != null)
                    || (point.X != xMin && sky[point.Y - yMin, point.X - xMin - 1] != null)
                    || (point.Y != yMax && sky[point.Y - yMin + 1, point.X - xMin] != null)
                    || (point.Y != yMin && sky[point.Y - yMin - 1, point.X - xMin] != null))
                    .Count();
                if (withNeighbours > alignment) {
                    alignment = withNeighbours;
                    result = i;
                }
                foreach(var point in lightPoints) {
                    point.Tick();
                }

                if (goodAlignment) {
                    if (withNeighbours < (lightPoints.Count() / 2)) {
                        goodAlignment = false;
                        stillLooking = false;
                    } 
                } else {
                    goodAlignment = (withNeighbours > (lightPoints.Count() / 2));
                }
            }
            return result;
        }
    }
}