using jonny.AoC.Day11;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day11
{
    public class Day11Tests
    {
        [Fact]
        public void PowerLevelExample1()
        {
            //Given
            int x = 3;
            int y = 5;
            int serial = 8;

            //When
            var cell = new FuelCell(x, y, serial);

            //Then
            Assert.Equal(4, cell.PowerLevel);
        }
        
        [Fact]
        public void PowerLevelExample2()
        {
            //Given
            int x = 122;
            int y = 79;
            int serial = 57;

            //When
            var cell = new FuelCell(x, y, serial);

            //Then
            Assert.Equal(-5, cell.PowerLevel);
        }

        [Fact]
        public void PowerLevelExample3()
        {
            //Given
            int x = 217;
            int y = 196;
            int serial = 39;

            //When
            var cell = new FuelCell(x, y, serial);

            //Then
            Assert.Equal(0, cell.PowerLevel);
        }

        [Fact]
        public void BestSquareLocationExample1() {
            // Given
            var systemUnderTest = new PowerGrid(50, 50, 18);

            // When 
            (int x, int y) = systemUnderTest.BestLocation();

            // Then
            Assert.Equal(33, x);
            Assert.Equal(45, y);
        }

        [Fact]
        public void BestSquareLocationExample2() {
            // Given
            var systemUnderTest = new PowerGrid(100, 100, 42);

            // When 
            (int x, int y) = systemUnderTest.BestLocation();

            // Then
            Assert.Equal(21, x);
            Assert.Equal(61, y);
        }

        [Fact]
        public void BestGenericSquareLocationExample1() {
            // Given
            var systemUnderTest = new PowerGrid(4, 4, 1);

            // When 
            (int x, int y, int size, int bestPower) = systemUnderTest.BestLocationAnySize();

            // Then
            Assert.Equal(3, x);
            Assert.Equal(3, y);
            Assert.Equal(2, size);
        }
    }
}