using jonny.AoC.Day5;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day5
{
    public class Day5Tests
    {
        [Fact]
        public void ExamplePolymer()
        {
            //Given
            string polymer = "dabAcCaCBAcCcaDA";
            var systemUnderTest = new PolymerReducer(polymer);

            //When
            string result = systemUnderTest.Shorten();

            //Then
            Assert.Equal("dabCBAcaDA", result);
        }

        [Fact]
        public void SingleShortening()
        {
            //Given
            string polymer = "dabCBAcCcaDA";
            var systemUnderTest = new PolymerReducer(polymer);

            //When
            string result = systemUnderTest.Shorten();

            //Then
            Assert.Equal("dabCBAcaDA", result);
        }

        [Fact]
        public void FindsExampleTroublePolymer()
        {
            //Given
            string polymer = "dabAcCaCBAcCcaDA";
            var systemUnderTest = new PolymerReducer(polymer);

            //When
            string result = systemUnderTest.RemoveAndShorten();

            //Then
            Assert.Equal("daDA", result);
        }
    }
}