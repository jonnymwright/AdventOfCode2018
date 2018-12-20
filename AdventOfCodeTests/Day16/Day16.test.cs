using jonny.AoC.Day16;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day16
{
    public class Day16Tests
    {
        [Fact]
        public void CanAddTwoRegisters()
        {
            //Given
            var registers = new[] {1,2,3,4};
            var systemUnderTest = new Addr();

            //When
            var result = systemUnderTest.Execute(1,2,3, registers);

            //Then
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
            Assert.Equal(5, result[3]);
        }

        [Fact]
        public void CanAddARegisterAndLiteral()
        {
            //Given
            var registers = new[] {1,2,3,4};
            var systemUnderTest = new Addi();

            //When
            var result = systemUnderTest.Execute(1,2,3, registers);

            //Then
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
            Assert.Equal(4, result[3]);
        }
        
        [Fact]
        public void CanGet16DifferentOps()
        {
            //Given

            //When
            var result = Instruction.GetAllInstruction()
                .Select(i => i.GetType())
                .Distinct();

            //Then
            Assert.Equal(16, result.Count());
        }
        
        [Fact]
        public void Example1()
        {
            //Given
            int[] before = new[] {3,2,1,1};
            int[] after = new[] {3,2,2,1};
            InstructionMatcher systemUnderTest = new InstructionMatcher();

            //When
            var result = systemUnderTest.MatchingCodes(before, after, 2, 1, 2);

            //Then
            Assert.Equal(3, result.Count());
        }


    }
}