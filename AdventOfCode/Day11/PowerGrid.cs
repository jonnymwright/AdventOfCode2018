using System;
using System.Linq;

namespace jonny.AoC.Day11
{
    public class PowerGrid
    {
        private FuelCell[,] grid;
        private int height;
        private int width;
        private int serial;

        public PowerGrid(int width, int height, int serial)
        {
            this.height = height;
            this.width = width;
            this.serial = serial;
            grid = new FuelCell[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[y, x] = new FuelCell(x + 1, y + 1, serial);
                }
            }
        }

        public (int, int) BestLocation()
        {
            int bestX = 0, bestY = 0, bestPower = 0; ;
            for (int y = 0; y < height - 2; y++)
            {
                for (int x = 0; x < width - 2; x++)
                {
                    int power = grid[y, x].PowerLevel + grid[y, x + 1].PowerLevel + grid[y, x + 2].PowerLevel
                        + grid[y + 1, x].PowerLevel + grid[y + 1, x + 1].PowerLevel + grid[y + 1, x + 2].PowerLevel
                        + grid[y + 2, x].PowerLevel + grid[y + 2, x + 1].PowerLevel + grid[y + 2, x + 2].PowerLevel;
                    if (power > bestPower)
                    {
                        bestPower = power;
                        bestX = x + 1;
                        bestY = y + 1;
                    }

                }
            }

            return (bestX, bestY);
        }

        public (int, int, int, int) BestLocationAnySize()
        {
            int bestX = 0, bestY = 0, bestSize = 0, bestPower = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int power = 0;
                    for (int size = 0; size < height - Math.Max(x, y); size++)
                    {
                        for (int i = 0; i <= size; i++)
                        {
                            power += grid[y + size, x + i].PowerLevel;
                            power += grid[y + i, x + size].PowerLevel;
                        }
                        power -= grid[y + size, x + size].PowerLevel;
                        if (power > bestPower)
                        {
                            bestPower = power;
                            bestX = x + 1;
                            bestY = y + 1;
                            bestSize = size + 1;
                        }
                    }

                }
            }

            return (bestX, bestY, bestSize, bestPower);
        }
    }
}