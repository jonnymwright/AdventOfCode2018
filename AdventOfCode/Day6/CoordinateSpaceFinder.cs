using System;
using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day6
{
    public class CoordinateSpaceFinder
    {
        private Coordinate[] coordinates;
        public int maxX, minX, maxY, minY;

        public CoordinateSpaceFinder(string coordinatesList)
        {
            coordinates = coordinatesList.Split("\r")
                .Select(line => new Coordinate(line))
                .ToArray();
        }

        public int LargestDangerousArea()
        {
            FindBounds();

            Dictionary<Coordinate, int> numberOfNearSpaces
                = coordinates.ToDictionary(c => c, c => 0);

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    int smallestDistance = int.MaxValue;
                    Coordinate nearestCoordinate = null;
                    bool isTie = false;
                    foreach (var c in coordinates)
                    {
                        int distance = Math.Abs(x - c.X)
                            + Math.Abs(y - c.Y);
                        if (distance == smallestDistance)
                        {
                            isTie = true;
                        }

                        if (distance < smallestDistance)
                        {
                            smallestDistance = distance;
                            isTie = false;
                            nearestCoordinate = c;
                        }
                    }

                    if (!isTie)
                    {
                        numberOfNearSpaces[nearestCoordinate]++;
                    }
                }
            }

            int result = numberOfNearSpaces.Values.Max();
            return result;
        }

        public int LargestSafeArea(int safeDistance)
        {
            FindBounds();

            int result = 0;
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    int distance = 0;
                    foreach (var c in coordinates)
                    {
                        distance += Math.Abs(x - c.X)
                            + Math.Abs(y - c.Y);
                    }
                    if (distance < safeDistance)
                        result++;
                }
            }

            return result;
        }

        private void FindBounds()
        {
            maxX = 0;
            maxY = 0;
            minX = int.MaxValue;
            minY = int.MaxValue;
            foreach (var c in coordinates)
            {
                if (c.X > maxX) maxX = c.X;
                if (c.X < minX) minX = c.X;
                if (c.Y > maxY) maxY = c.Y;
                if (c.Y < minY) minY = c.Y;
            }
        }
    }
}