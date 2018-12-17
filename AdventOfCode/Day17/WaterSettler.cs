using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace jonny.AoC.Day17
{
    public class WaterSettler
    { 
        private int output = -1;
        int xMin = int.MaxValue;
        int xMax = 0;
        int yMin = int.MaxValue;
        int yMax = 0;

        private MapTile[,] map;

        private IEnumerable<MapTile> activeTiles;

        public WaterSettler(string[] scans) {
            Regex r = new Regex("([xy])=(\\d+), [xy]=(\\d+)..(\\d+)");
            foreach(var match in scans.Select(s => r.Match(s))) {
                int firstNumber = int.Parse(match.Groups[2].Value);
                int secondNumber = int.Parse(match.Groups[3].Value);
                int thirdNumber = int.Parse(match.Groups[4].Value);
                if (match.Groups[1].Value == "x") {
                    if (firstNumber > xMax) xMax = firstNumber;
                    if (firstNumber < xMin) xMin = firstNumber;
                    if (secondNumber < yMin) yMin = secondNumber;
                    if (thirdNumber > yMax) yMax = thirdNumber;
                } else {
                    if (firstNumber > yMax) yMax = firstNumber;
                    if (firstNumber < yMin) yMin = firstNumber;
                    if (secondNumber < xMin) xMin = secondNumber;
                    if (thirdNumber > xMax) xMax = thirdNumber;
                }
            }

            xMax+=2;
            xMin--;
            yMax++;
            map = new MapTile[yMax - yMin, xMax - xMin];

            for (int y = 0; y < yMax-yMin; y++)
            {
                for (int x = 0; x < xMax-xMin; x++)
                {
                    map[y,x] = new MapTile(MapTile.MapType.Sand, x, y, map);
                }
            }

            foreach(var match in scans.Select(s => r.Match(s))) {
                int firstNumber = int.Parse(match.Groups[2].Value);
                int secondNumber = int.Parse(match.Groups[3].Value);
                int thirdNumber = int.Parse(match.Groups[4].Value);
                if (match.Groups[1].Value == "x") {
                    for (int y = secondNumber; y <= thirdNumber; y++)
                    {
                        map[y-yMin, firstNumber-xMin] = new MapTile(MapTile.MapType.Clay, firstNumber-xMin, y-yMin, map);
                    }
                } else {
                    for (int x = secondNumber; x <= thirdNumber; x++)
                    {
                        map[firstNumber-yMin, x-xMin] = new MapTile(MapTile.MapType.Clay, x-xMin, firstNumber-yMin, map);
                    }
                }
            }
            map[0, 500 -xMin] = new MapTile(MapTile.MapType.Source, 500-xMin, 0, map);
            activeTiles = new [] { map[0, 500 -xMin] };
        }

        
        public (int, int) RunUntilFull() {
            while(activeTiles.Any()) {
                Tick();
            }

            int allWater = map.Cast<MapTile>().Where(tile => tile.IsWater).Count();
            int stillWater = map.Cast<MapTile>().Where(tile => tile.IsStillWater).Count();
            return (allWater, stillWater);
        }


        public void Tick() {
            List<MapTile> next = new List<MapTile>();
            foreach(var tile in activeTiles) {
                next.AddRange(tile.Tick());
                if (output > 0) {
                    System.IO.File.WriteAllText($"day17/progress{output}.txt", ToString());
                    output++;
                }
            }
            activeTiles = next.Distinct();
        }

        public override string ToString() {
            StringBuilder s = new StringBuilder();
            for (int y = 0; y < yMax - yMin; y++)
            {
                for (int x = 0; x < xMax-xMin; x++)
                {
                    s.Append(map[y,x].ToString());
                }
                s.Append('\r');
            }
            return s.ToString();
        }
    }
}