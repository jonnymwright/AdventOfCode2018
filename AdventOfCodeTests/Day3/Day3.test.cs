using jonny.AoC.Day3;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day3
{
    public class Day3Tests
    {
        [Fact]
        public void FirstExampleGetOverlappingSquares()
        {
            //Given
            var claims = new[] {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };
            var systemUnderTest = new ClaimResolver(claims);
            systemUnderTest.PlaceClaims();

            //When
            var result = systemUnderTest.Overlapping;

            //Then
            Assert.Equal(4, result);
        }

        [Fact]
        public void FirstExampleGetNonOverlappingClaim()
        {
            //Given
            var claims = new[] {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };
            var systemUnderTest = new ClaimResolver(claims);
            systemUnderTest.PlaceClaims();

            //When
            var result = systemUnderTest.NonOverlappingClaims;

            //Then
            Assert.Equal("3", result.Single());
        }

        [Fact]
        public void WhenAClaimIsEntirelySurroundedInContestedCloth()
        {
            //Given
            // 1 1 4 . 
            // 1 X 2 . - 1, 2 and 3 claim this spot
            // . 2 2 .
             var claims = new[] {
                "#1 @ 0,0: 2x2",
                "#2 @ 1,1: 2x2",
                "#3 @ 1,1: 1x1",
                "#4 @ 0,2: 1x1",
            };
            var systemUnderTest = new ClaimResolver(claims);
            systemUnderTest.PlaceClaims();

            //When
            var result = systemUnderTest.NonOverlappingClaims;

            //Then
            Assert.Equal("4", result.Single());
        }
    }
}