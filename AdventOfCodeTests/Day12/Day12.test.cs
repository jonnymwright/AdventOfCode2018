using jonny.AoC.Day12;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day12
{
    public class Day12Tests
    {
        [Fact]
        public void OneGeneration()
        {
            //Given
            string initialState = "#..#.#..##......###...###";
            string[] rules = {"...##",
                "..#..",
                ".#...",
                ".#.#.",
                ".#.##",
                ".##..",
                ".####",
                "#.#.#",
                "#.###",
                "##.#.",
                "##.##",
                "###..",
                "###.#",
                "####."};
            var systemUnderTest = new PlantBreeder(initialState, rules);

            //When
            string result = systemUnderTest.OneGeneration();

            //Then
            Assert.Equal("#...#....#.....#..#..#..#", result);
        }

        [Fact]
        public void Example1()
        {
            //Given
            string initialState = "#..#.#..##......###...###";
            string[] rules = {"...##",
                "..#..",
                ".#...",
                ".#.#.",
                ".#.##",
                ".##..",
                ".####",
                "#.#.#",
                "#.###",
                "##.#.",
                "##.##",
                "###..",
                "###.#",
                "####."};
            var systemUnderTest = new PlantBreeder(initialState, rules);

            //When
            string result = systemUnderTest.Run(20);

            //Then
            Assert.Equal("#....##....#####...#######....#.#..##", result);
        }
        
        [Fact]
        public void Example1KnowsTheFirstPotIsMinusOne()
        {
            //Given
            string initialState = "#..#.#..##......###...###";
            string[] rules = {"...##",
                "..#..",
                ".#...",
                ".#.#.",
                ".#.##",
                ".##..",
                ".####",
                "#.#.#",
                "#.###",
                "##.#.",
                "##.##",
                "###..",
                "###.#",
                "####."};
            var systemUnderTest = new PlantBreeder(initialState, rules);

            //When
            systemUnderTest.Run(3);
            int result = systemUnderTest.Offset;

            //Then
            Assert.Equal(-1, result);
        }

        [Fact]
        public void GetSimpleValue()
        {
            //Given
            string initialState = "##";
            string[] rules = {};
            var systemUnderTest = new PlantBreeder(initialState, rules);

            //When
            long result = systemUnderTest.Value();

            //Then
            Assert.Equal(1, result);
        }

        [Fact]
        public void Example1Value()
        {
            //Given
            string initialState = "#..#.#..##";
            string[] rules = {"...##",
                "..#..",
                ".#...",
                ".#.#.",
                ".#.##",
                ".##..",
                ".####",
                "#.#.#",
                "#.###",
                "##.#.",
                "##.##",
                "###..",
                "###.#",
                "####."};
            var systemUnderTest = new PlantBreeder(initialState, rules);

            //When
            systemUnderTest.Run(3);
            long result = systemUnderTest.Value();

            //Then
            Assert.Equal(23, result);
        }
    }
}