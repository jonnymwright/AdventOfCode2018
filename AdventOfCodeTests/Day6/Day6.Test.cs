using jonny.AoC.Day6;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day6
{
    public class Day6Tests
    {
        [Fact]
        public void Example1()
        {
            //Given
            string coordinates = @"1, 1
1, 6
8, 3
3, 4
5, 5
8, 9";
            CoordinateSpaceFinder systemUnderTest = new CoordinateSpaceFinder(coordinates);

            //When
            int result = systemUnderTest.LargestDangerousArea();

            //Then
            Assert.Equal(17, result);
        }

                [Fact]
        public void Example2()
        {
            //Given
            string coordinates = @"1, 1
1, 6
8, 3
3, 4
5, 5
8, 9";
            CoordinateSpaceFinder systemUnderTest = new CoordinateSpaceFinder(coordinates);

            //When
            int result = systemUnderTest.LargestSafeArea(32);

            //Then
            Assert.Equal(16, result);
        }
    
    }
}