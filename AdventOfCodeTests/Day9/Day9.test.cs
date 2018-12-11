using jonny.AoC.Day9;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day9
{
    public class Day9Tests
    {
        [Fact]
        public void IsInitialised()
        {
            //Given
            var systemUnderTest = new MarblesGame(2);

            //When
            string result = systemUnderTest.GameState();

            //Then
            Assert.Equal("0 ", result);
        }

        [Fact]
        public void CanInsertInCorrectPlace()
        {
            //Given
            var systemUnderTest = new MarblesGame(2);

            //When
            systemUnderTest.TakeTurn();
            systemUnderTest.TakeTurn();
            systemUnderTest.TakeTurn();
            string result = systemUnderTest.GameState();

            //Then
            Assert.Equal("3 0 2 1 ", result);
        }

        [Fact]
        public void HasTheCorrectGameBoardAfter23Turns()
        {
            //Given
            var systemUnderTest = new MarblesGame(2);

            //When
            for (int i=1; i<=23; i++) {
                systemUnderTest.TakeTurn();
            }
            string result = systemUnderTest.GameState();

            //Then
            Assert.Equal("19 2 20 10 21 5 22 11 1 12 6 13 3 14 7 15 0 16 8 17 4 18 ", result);
        }

        [Fact]
        public void HasTheCorrectScoreAfter23Turns()
        {
            //Given
            var systemUnderTest = new MarblesGame(9);

            //When
            for (int i=1; i<=23; i++) {
                systemUnderTest.TakeTurn();
            }
            var result = systemUnderTest.Scores();

            //Then
            Assert.Equal(0, result[0]);
            Assert.Equal(0, result[1]);
            Assert.Equal(0, result[2]);
            Assert.Equal(0, result[3]);
            Assert.Equal(32, result[4]);
            Assert.Equal(0, result[5]);
            Assert.Equal(0, result[6]);
            Assert.Equal(0, result[7]);
            Assert.Equal(0, result[8]);
        }

        [Fact]
        public void Example2()
        {
            //Given
            var systemUnderTest = new MarblesGame(10);

            //When
            var result = systemUnderTest.Play(1618);

            //Then
            Assert.Equal(8317, result.Max());
        }

        [Fact]
        public void Example3()
        {
            //Given
            var systemUnderTest = new MarblesGame(13);

            //When
            var result = systemUnderTest.Play(7999);

            //Then
            Assert.Equal(146373, result.Max());
        }
    }
}