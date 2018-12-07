using jonny.AoC.Day7;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day7
{
    public class Day7Tests
    {
        [Fact]
        public void Example1()
        {
            //Given
            string dependencies = @"Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin.";
            StepOrderer systemUnderTest = new StepOrderer(dependencies);

            //When
            string result = systemUnderTest.GetOrder();

            //Then
            Assert.Equal("CABDFE", result);
        }

[Fact]
        public void Example2()
        {
            //Given
            string dependencies = @"Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin.";
            StepOrderer systemUnderTest = new StepOrderer(dependencies);

            //When
            int result = systemUnderTest.GetTimings(0, 2);

            //Then
            Assert.Equal(15, result);
        }
    }
}