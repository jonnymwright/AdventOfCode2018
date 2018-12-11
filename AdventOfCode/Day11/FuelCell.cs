

namespace jonny.AoC.Day11 {
    public class FuelCell{
        public int X {get;}
        public int Y {get;}
        private int serial;

        public int PowerLevel {get;}

        public FuelCell(int x, int y, int serial) {
            this.X = x;
            this.Y = y;
            this.serial = serial;

            PowerLevel = CalculatePower();
        }

        public int CalculatePower() {
            int rackId = X + 10;
            int result = rackId * Y;
            result += serial;
            result *= rackId;
            result = result/100;
            result = result%10;
            result -= 5;
            return result;
        }
    }
}