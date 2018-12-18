using jonny.AoC.Day18;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day18
{
    public class Day18Tests
    {
        [Fact]
        public void CanParseTheInput()
        {
            //Given
            var input = new [] {".#.#...|#.",
                                ".....#|##|",
                                ".|..|...#.",
                                "..|#.....#",
                                "#.#|||#|#|",
                                "...#.||...",
                                ".|....|...",
                                "||...#|.#|",
                                "|.||||..|.",
                                "...#.|..|."};
            var systemUnderTest = new LumberConstuctor(input);

            //When
            var result = systemUnderTest.ToString();

            //Then
            Assert.Equal(
                        ".#.#...|#.\r"+
                        ".....#|##|\r"+
                        ".|..|...#.\r"+
                        "..|#.....#\r"+
                        "#.#|||#|#|\r"+
                        "...#.||...\r"+
                        ".|....|...\r"+
                        "||...#|.#|\r"+
                        "|.||||..|.\r"+
                        "...#.|..|.\r", result);
            
        }

        
        [Fact]
        public void DoesOneTick()
        {
            //Given
            var input = new [] {".#.#...|#.",
                                ".....#|##|",
                                ".|..|...#.",
                                "..|#.....#",
                                "#.#|||#|#|",
                                "...#.||...",
                                ".|....|...",
                                "||...#|.#|",
                                "|.||||..|.",
                                "...#.|..|."};
            var systemUnderTest = new LumberConstuctor(input);

            //When
            systemUnderTest.Tick();
            var result = systemUnderTest.ToString();

            //Then
            Assert.Equal(
                        ".......##.\r"+
                        "......|###\r"+
                        ".|..|...#.\r"+
                        "..|#||...#\r"+
                        "..##||.|#|\r"+
                        "...#||||..\r"+
                        "||...|||..\r"+
                        "|||||.||.|\r"+
                        "||||||||||\r"+
                        "....||..|.\r", result);
            
        }
         
        [Fact]
        public void Example1()
        {
            //Given
            var input = new [] {".#.#...|#.",
                                ".....#|##|",
                                ".|..|...#.",
                                "..|#.....#",
                                "#.#|||#|#|",
                                "...#.||...",
                                ".|....|...",
                                "||...#|.#|",
                                "|.||||..|.",
                                "...#.|..|."};
            var systemUnderTest = new LumberConstuctor(input);

            //When
            var result = systemUnderTest.Run(10);

            //Then
            Assert.Equal(1147, result);
            
        }
    }
}