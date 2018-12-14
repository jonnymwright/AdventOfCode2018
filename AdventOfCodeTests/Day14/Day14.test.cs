using jonny.AoC.Day14;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day14
{
    public class Day14Tests
    {
        [Fact]
        public void CanParseATrackLayout()
        {
            //Given
            var systemUnderTest = new RecipeBoard(new []{1,2});

            //When
            

            //Then
            Assert.Equal(1, systemUnderTest.Board[0]);
            Assert.Equal(2, systemUnderTest.Board[1]);
        }
    
        [Fact]
        public void CanAddARecipieToTheEnd()
        {
            //Given
            var systemUnderTest = new RecipeBoard(new []{1,2});

            //When
            systemUnderTest.Cook();

            //Then
            Assert.Equal(1, systemUnderTest.Board[0]);
            Assert.Equal(2, systemUnderTest.Board[1]);
            Assert.Equal(3, systemUnderTest.Board[2]);
        }
    
        [Fact]
        public void ElvesChooseTheCorrectRecipe()
        {
            //Given
            var systemUnderTest = new RecipeBoard(new []{1,2});

            //When
            systemUnderTest.Cook();
            systemUnderTest.Cook();

            //Then
            Assert.Equal(1, systemUnderTest.Board[0]);
            Assert.Equal(2, systemUnderTest.Board[1]);
            Assert.Equal(3, systemUnderTest.Board[2]);
            Assert.Equal(5, systemUnderTest.Board[3]);
        }
    
        [Fact]
        public void Creates2RecipesFor2DigitNumbers()
        {
            //Given
            var systemUnderTest = new RecipeBoard(new []{7,3});

            //When
            systemUnderTest.Cook();

            //Then
            Assert.Equal(1, systemUnderTest.Board[2]);
            Assert.Equal(0, systemUnderTest.Board[3]);
        }
    
        [Fact]
        public void Example1()
        {
            //Given
            var systemUnderTest = new RecipeBoard(new []{3,7});

            //When
            var result = systemUnderTest.Score(9);

            //Then
            Assert.Equal("5158916779", result);
        }
    
        [Fact]
        public void Example2()
        {
            //Given
            var systemUnderTest = new RecipeBoard(new []{3,7});

            //When
            var result = systemUnderTest.Score(5);

            //Then
            Assert.Equal("0124515891", result);
        }
    
        [Fact]
        public void Example3()
        {
            //Given
            var systemUnderTest = new RecipeBoard(new []{3,7});

            //When
            var result = systemUnderTest.Score(18);

            //Then
            Assert.Equal("9251071085", result);
        }
    
        [Fact]
        public void Example4()
        {
            //Given
            var systemUnderTest = new RecipeBoard(new []{3,7});

            //When
            var result = systemUnderTest.Score(2018);

            //Then
            Assert.Equal("5941429882", result);
        }

        [Fact]
        public void Example5() {
            //Given
            var systemUnderTest = new RecipeBoard(new []{3,7});

            //When
            var result = systemUnderTest.BeforeScore("51589");

            //Then
            Assert.Equal(9, result);
        }

        [Fact]
        public void Example6() {
            //Given
            var systemUnderTest = new RecipeBoard(new []{3,7});

            //When
            var result = systemUnderTest.BeforeScore("59414");

            //Then
            Assert.Equal(2018, result);
        }
    
    }
}