using Xunit;

namespace jonny.AoCTests.Day1 {
    public class Day1Tests {

        [Fact]
        public void FindsFirstFrequencyExample2() {
        //Given
        int[] changes = new[] {3,3,4,-2,-4};
        var systemUnderTest = new jonny.AoC.Day1.Day1(changes);

        //When
        int result = systemUnderTest.FirstRepeatingFrequency();

        //Then
        Assert.Equal(10, result);
        }

        [Fact]
        public void FindsFirstFrequencyExample4() {
        //Given
        int[] changes = new[] {7,7,-2,-7,-4};
        var systemUnderTest = new jonny.AoC.Day1.Day1(changes);

        //When
        int result = systemUnderTest.FirstRepeatingFrequency();

        //Then
        Assert.Equal(14, result);
        }
    }
}