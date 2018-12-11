using jonny.AoC.Day8;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day8
{
    public class Day8Tests
    {
        [Fact]
        public void Example1()
        {
            //Given
            string nodeData = @"2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            var systemUnderTest = new Node(nodeData);

            //When
            int result = systemUnderTest.SumMetadata();

            //Then
            Assert.Equal(138, result);
        }

        [Fact]
        public void Example2() {
            //Given
            string nodeData = @"2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            var systemUnderTest = new Node(nodeData);

            //When
            int result = systemUnderTest.SumValue();

            //Then
            Assert.Equal(66, result);
        }
    }
}