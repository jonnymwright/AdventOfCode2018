using jonny.AoC.Day17;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day17
{
    public class Day17Tests
    {
        [Fact]
        public void CanParseATrackLayout()
        {
            //Given
            var input = new [] {"x=495, y=2..7",
                                "y=7, x=495..501",
                                "x=501, y=3..7",
                                "x=498, y=2..4",
                                "x=506, y=1..2",
                                "x=498, y=10..13",
                                "x=504, y=10..13",
                                "y=13, x=498..504"};
            var systemUnderTest = new WaterSettler(input);

            //When
            var result = systemUnderTest.ToString();

            //Then
            Assert.Equal(
                        "......+.....#.\r" +
                        ".#..#.......#.\r" +
                        ".#..#..#......\r" +
                        ".#..#..#......\r" +
                        ".#.....#......\r" +
                        ".#.....#......\r" +
                        ".#######......\r" +
                        "..............\r" +
                        "..............\r" +
                        "....#.....#...\r" +
                        "....#.....#...\r" +
                        "....#.....#...\r" +
                        "....#######...\r", result);
            
        }

        [Fact]
        public void CanAddADropOfWater()
        {
            //Given
            var input = new [] {"x=495, y=2..7",
                                "y=7, x=495..501",
                                "x=501, y=3..7",
                                "x=498, y=2..4",
                                "x=506, y=1..2",
                                "x=498, y=10..13",
                                "x=504, y=10..13",
                                "y=13, x=498..504"};
            var systemUnderTest = new WaterSettler(input);

            //When
            systemUnderTest.Tick();
            var result = systemUnderTest.ToString();

            //Then
            Assert.Equal(
                        "......+.....#.\r" +
                        ".#..#.|.....#.\r" +
                        ".#..#.|#......\r" +
                        ".#..#.|#......\r" +
                        ".#....|#......\r" +
                        ".#....|#......\r" +
                        ".#######......\r" +
                        "..............\r" +
                        "..............\r" +
                        "....#.....#...\r" +
                        "....#.....#...\r" +
                        "....#.....#...\r" +
                        "....#######...\r", result);
            
        }

        [Fact]
        public void CanMakeAPoolOfWater()
        {
            //Given
            var input = new [] {"x=495, y=2..7",
                                "y=7, x=495..501",
                                "x=501, y=3..7",
                                "x=498, y=2..4",
                                "x=506, y=1..2",
                                "x=498, y=10..13",
                                "x=504, y=10..13",
                                "y=13, x=498..504"};
            var systemUnderTest = new WaterSettler(input);

            //When
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            var result = systemUnderTest.ToString();

            //Then
            Assert.Equal(
                        "......+.....#.\r" +
                        ".#..#.|.....#.\r" +
                        ".#..#.|#......\r" +
                        ".#..#.|#......\r" +
                        ".#....|#......\r" +
                        ".#~~~~~#......\r" +
                        ".#######......\r" +
                        "..............\r" +
                        "..............\r" +
                        "....#.....#...\r" +
                        "....#.....#...\r" +
                        "....#.....#...\r" +
                        "....#######...\r", result);
            
        }
        
        [Fact]
        public void CanOverflowAPool()
        {
            //Given
            var input = new [] {"x=495, y=2..7",
                                "y=7, x=495..501",
                                "x=501, y=3..7",
                                "x=498, y=2..4",
                                "x=506, y=1..2",
                                "x=498, y=10..13",
                                "x=504, y=10..13",
                                "y=13, x=498..504"};
            var systemUnderTest = new WaterSettler(input);

            //When
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            var result = systemUnderTest.ToString();

            //Then
            Assert.Equal(
                        "......+.....#.\r" +
                        ".#..#||||...#.\r" +
                        ".#..#~~#......\r" +
                        ".#..#~~#......\r" +
                        ".#~~~~~#......\r" +
                        ".#~~~~~#......\r" +
                        ".#######......\r" +
                        "..............\r" +
                        "..............\r" +
                        "....#.....#...\r" +
                        "....#.....#...\r" +
                        "....#.....#...\r" +
                        "....#######...\r", result);
            
        }
    
        [Fact]
        public void CanReachASink(){
            //Given
            var input = new [] {"x=499, y=1..3",
                                "x=501, x=1..3"};
            var systemUnderTest = new WaterSettler(input);

            //When
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            var result = systemUnderTest.ToString();

            //Then
            Assert.Equal(
                        ".#+#.\r" +
                        ".#|#.\r" +
                        ".#|#.\r", result);
        }
    
        [Fact]
        public void MergesWaterStreamsVertically(){
            //Given
            var input = new [] {"y=0, x=493..493",
                                "x=495, y=10..10",
                                "y=11, y=495..503",
                                "x=497, y=6..7",
                                "x=498, y=7..7",
                                "x=499, y=3..7",
                                "x=500, y=4..4",
                                "x=501, y=3..4",
                                "x=503, y=10..10",
                                "x=505, y=0..0"
                                };
            var systemUnderTest = new WaterSettler(input);

            //When
            systemUnderTest.RunUntilFull();
            var result = systemUnderTest.ToString();

            //Then
            Assert.Equal(
                        ".#......+....#.\r"+
                        "........|......\r"+
                        "......|||||....\r"+
                        "......|#~#|....\r"+
                        "......|###|....\r"+
                        "....|||#..|....\r"+
                        "....|#~#..|....\r"+
                        "....|###..|....\r"+
                        "....|.....|....\r"+
                        "..|||||||||||..\r"+
                        "..|#~~~~~~~#|..\r"+
                        "..|#########|..\r", result);
        }

        [Fact]
        public void MergesWaterStreamsHorizontally(){
            //Given
            var input = new [] {"y=0, x=493..493",
                                "x=499, y=3..5",
                                "x=500, y=4..5",
                                "x=501, y=5..5",
                                "x=502, y=3..5",
                                "x=505, y=0..0"
                                };
            var systemUnderTest = new WaterSettler(input);

            //When
            systemUnderTest.RunUntilFull();
            var result = systemUnderTest.ToString();

            //Then
            Assert.Equal(
                        ".#......+....#.\r"+
                        "........|......\r"+
                        "......||||||...\r"+
                        "......|#~~#|...\r"+
                        "......|##~#|...\r"+
                        "......|####|...\r", result);
        }

        [Fact]
        public void CanCountNumberOfWaterTiles()
        {
            //Given
            var input = new [] {"x=495, y=2..7",
                                "y=7, x=495..501",
                                "x=501, y=3..7",
                                "x=498, y=2..4",
                                "x=506, y=1..2",
                                "x=498, y=10..13",
                                "x=504, y=10..13",
                                "y=13, x=498..504"};
            var systemUnderTest = new WaterSettler(input);

            //When
            var (all, still) = systemUnderTest.RunUntilFull();

            //Then
            Assert.Equal(57, all);
            Assert.Equal(29, still);
            
        }
    }
}