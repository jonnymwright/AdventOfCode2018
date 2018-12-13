using jonny.AoC.Day13;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day13
{
    public class Day13Tests
    {
        [Fact]
        public void CanParseATrackLayout()
        {
            //Given
            string[] track = new[] {"/----\\",
                                    "|    |",
                                    "|    |",
                                    "\\----/"};

            //When
            var systemUnderTest = new TrackTracker(track);

            //Then
            
        }

        [Fact]
        public void CanParseATrackLayoutWithCartAndIntersection()
        {
            //Given
            string[] track = new[] {"/--+-\\",
                                    "|  | |",
                                    "|  v |",
                                    "\\--+-/"};

            //When
            var systemUnderTest = new TrackTracker(track);

            //Then
            Assert.Equal(TrackPiece.Straight, systemUnderTest.Tracks[2,3]);
            Assert.Equal(1, systemUnderTest.Carts.Count());
            Assert.Equal(2, systemUnderTest.Carts[0].Y);
            Assert.Equal(3, systemUnderTest.Carts[0].X);
        }

        [Fact]
        public void CartsMoveForward()
        {
            //Given
            string[] track = new[] {" >-",
                                    "v  ",
                                    "|  "};
            var systemUnderTest = new TrackTracker(track);

            //When
            systemUnderTest.Tick();

            //Then
            Assert.Equal(0, systemUnderTest.Carts[0].Y);
            Assert.Equal(2, systemUnderTest.Carts[0].X);
            Assert.Equal(2, systemUnderTest.Carts[1].Y);
            Assert.Equal(0, systemUnderTest.Carts[1].X);
        }

        [Fact]
        public void CartsMoveAroundCorners()
        {
            //Given
            string[] track = new[] {">\\",
                                    " |"};
            var systemUnderTest = new TrackTracker(track);

            //When
            systemUnderTest.Tick();
            systemUnderTest.Tick();

            //Then
            Assert.Equal(1, systemUnderTest.Carts[0].Y);
            Assert.Equal(1, systemUnderTest.Carts[0].X);
        }
        
        [Fact]
        public void CartsMoveAroundIntersections()
        {
            //Given
            string[] track = new[] {" +<", // turn left
                                    " + ", // then straight
                                    "-+ "};// then right
            var systemUnderTest = new TrackTracker(track);

            //When
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            systemUnderTest.Tick();
            systemUnderTest.Tick();

            //Then
            Assert.Equal(2, systemUnderTest.Carts[0].Y);
            Assert.Equal(0, systemUnderTest.Carts[0].X);
        }
        
        [Fact]
        public void FindsCrash()
        {
            //Given
            string[] track = new[] {">-<"};
            var systemUnderTest = new TrackTracker(track);

            //When
            var result = systemUnderTest.RunUntilCrash();

            //Then
            Assert.Equal(1, result.Item1);
            Assert.Equal(0, result.Item2);
        }
        
        [Fact]
        public void DontMoveThroughEachOther()
        {
            //Given
            string[] track = new[] {">--<"};
            var systemUnderTest = new TrackTracker(track);

            //When
            var result = systemUnderTest.RunUntilCrash();

            //Then
            Assert.Equal(2, result.Item1);
            Assert.Equal(0, result.Item2);
        }
        
        [Fact]
        public void Example1()
        {
            //Given
            string[] track = new[] {"/->-\\        ",
                                    "|   |  /----\\",
                                    "| /-+--+-\\  |",
                                    "| | |  | v  |",
                                    "\\-+-/  \\-+--/",
                                    "  \\------/   "};
            var systemUnderTest = new TrackTracker(track);

            //When
            var result = systemUnderTest.RunUntilCrash();

            //Then
            Assert.Equal(7, result.Item1);
            Assert.Equal(3, result.Item2);
        }
        
        [Fact]
        public void Example2()
        {
            //Given
            string[] track = new[] {"/>-<\\  ",
                                    "|   |  ",
                                    "| /<+-\\",
                                    "| | | v",
                                    "\\>+</ |",
                                    "  |   ^",
                                    "  \\<->/"};
            var systemUnderTest = new TrackTracker(track);

            //When
            var result = systemUnderTest.RunUntilOneLeft();

            //Then
            Assert.Equal(6, result.Item1);
            Assert.Equal(4, result.Item2);
        }
        
        [Fact]
        public void ThreeWayCrash()
        {
            //Given
            string[] track = new[] {">+<",
                                    "v^ ",
                                    "|  "};
            var systemUnderTest = new TrackTracker(track);

            //When
            var result = systemUnderTest.RunUntilOneLeft();

            //Then
            Assert.Equal(0, result.Item1);
            Assert.Equal(2, result.Item2);
        }
    }
}