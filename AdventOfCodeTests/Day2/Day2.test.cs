using jonny.AoC.Day2;
using Xunit;

namespace jonny.AoCTests.Day2
{
    public class Day2Tests
    {
        [Fact]
        public void FirstExampleCheckSum()
        {
            //Given
            var ids = new[] {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab"
            };
            var systemUnderTest = new IdScanner(ids);

            //When
            var result = systemUnderTest.GetCheckSum();

            //Then
            Assert.Equal(12, result);
        }

        [Fact]
        public void FirstExampleIdDiffer()
        {
            //Given
            var ids = new[] {"abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz"};
            var systemUnderTest = new IdScanner(ids);

            //When
            string result = systemUnderTest.FindCommonId();

            //Then
            Assert.Equal("fgij", result);
        }
    }
}