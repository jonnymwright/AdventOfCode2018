using System.Drawing;
using System.Linq;

namespace jonny.AoC.Day20 {
    public class MapOutput
    {
        private int max;
        public void ToBitMap(int[,] input) {
            max = input.Cast<int>().Max();
            int height = input.GetLength(0);
            int width = input.GetLength(1);

            Bitmap b = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    b.SetPixel(x, y, Transfer(input[x,y]));
                }
            }

            b.Save("distance.bmp");
        }

        private Color Transfer(int val) {
            int r = val * 255 / max;
            int g = System.Math.Min(val * 511 / max, 255);
            int b = System.Math.Max((val * 511 / max)-256, 0);
            Color c = Color.FromArgb(r, g, b);
            return c;
        }
    }
}