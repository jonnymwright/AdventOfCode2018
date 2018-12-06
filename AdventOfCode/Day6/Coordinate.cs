using System;
using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day6
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(string unparsed)
        {
            string[] parts = unparsed.Split(",");
            Y = int.Parse(parts[1].Trim());
            X = int.Parse(parts[0].Trim());
        }
    }
}