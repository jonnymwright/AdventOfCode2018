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
        public void CanMultiplyTwoRegisters()
        {
            //Given
            var registers = new[] {1,2,3,4};
            var systemUnderTest = new Mulr();

            //When
            var result = systemUnderTest.Execute(1,2,3, registers);

            //Then
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
            Assert.Equal(6, result[3]);
        }
        
        [Fact]
        public void CanMultiplyARegisterAndLiteral()
        {
            //Given
            var registers = new[] {1,2,3,4};
            var systemUnderTest = new Muli();

            //When
            var result = systemUnderTest.Execute(1,2,3, registers);

            //Then
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
            Assert.Equal(4, result[3]);
        }
        
        [Fact]
        public void CanAndTwoRegisters()
        {
            //Given
            var registers = new[] {1,7,3,4};
            var systemUnderTest = new Banr();

            //When
            var result = systemUnderTest.Execute(1,2,3, registers);

            //Then
            Assert.Equal(1, result[0]);
            Assert.Equal(7, result[1]);
            Assert.Equal(3, result[2]);
            Assert.Equal(3, result[3]);
        }
        
        [Fact]
        public void CanAndARegisterAndLiteral()
        {
            //Given
            var registers = new[] {0,3,0,0};
            var systemUnderTest = new Bani();

            //When
            var result = systemUnderTest.Execute(1,7,3, registers);

            //Then
            Assert.Equal(0, result[0]);
            Assert.Equal(3, result[1]);
            Assert.Equal(0, result[2]);
            Assert.Equal(3, result[3]);
        }
        [Fact]
        public void CanOrTwoRegisters()
        {
            //Given
            var registers = new[] {1,5,3,4};
            var systemUnderTest = new Borr();

            //When
            var result = systemUnderTest.Execute(1,2,3, registers);

            //Then
            Assert.Equal(1, result[0]);
            Assert.Equal(5, result[1]);
            Assert.Equal(3, result[2]);
            Assert.Equal(7, result[3]);
        }
        
        [Fact]
        public void CanOrARegisterAndLiteral()
        {
            //Given
            var registers = new[] {1,3,3,4};
            var systemUnderTest = new Bori();

            //When
            var result = systemUnderTest.Execute(1,5,3, registers);

            //Then
            Assert.Equal(1, result[0]);
            Assert.Equal(3, result[1]);
            Assert.Equal(3, result[2]);
            Assert.Equal(7, result[3]);
        }
        
        [Fact]
        public void CanSetFromARegister()
        {
            //Given
            var registers = new[] {0,6,0,0};
            var systemUnderTest = new Setr();

            //When
            var result = systemUnderTest.Execute(1,2,3, registers);

            //Then
            Assert.Equal(0, result[0]);
            Assert.Equal(6, result[1]);
            Assert.Equal(0, result[2]);
            Assert.Equal(6, result[3]);
        }
        
        [Fact]
        public void CanSetFromALiteral()
        {
            //Given
            var registers = new[] {0,0,0,0};
            var systemUnderTest = new Seti();

            //When
            var result = systemUnderTest.Execute(1,2,3, registers);

            //Then
            Assert.Equal(0, result[0]);
            Assert.Equal(0, result[1]);
            Assert.Equal(0, result[2]);
            Assert.Equal(1, result[3]);
        }
        
        [Fact]
        public void CanCheckLiteralIsGreterThanRegister()
        {
            //Given
            var registers = new[] {1,2,3,4};
            var systemUnderTest = new Gtir();

            //When
            var result1 = systemUnderTest.Execute(1,2,3, registers);
            var result2 = systemUnderTest.Execute(6,2,3, registers);

            //Then
            Assert.Equal(1, result1[0]);
            Assert.Equal(2, result1[1]);
            Assert.Equal(3, result1[2]);
            Assert.Equal(0, result1[3]);
            Assert.Equal(1, result2[3]);
        }
        
        [Fact]
        public void CanCheckRegisterIsGreterThanLiteral()
        {
            //Given
            var registers = new[] {1,2,3,4};
            var systemUnderTest = new Gtri();

            //When
            var result1 = systemUnderTest.Execute(1,2,3, registers);
            var result2 = systemUnderTest.Execute(1,0,3, registers);

            //Then
            Assert.Equal(1, result1[0]);
            Assert.Equal(2, result1[1]);
            Assert.Equal(3, result1[2]);
            Assert.Equal(0, result1[3]);
            Assert.Equal(1, result2[3]);
        }
        
        [Fact]
        public void CanCheckRegisterIsGreterThanRegister()
        {
            //Given
            var registers = new[] {1,2,3,4};
            var systemUnderTest = new Gtrr();

            //When
            var result1 = systemUnderTest.Execute(1,2,3, registers);
            var result2 = systemUnderTest.Execute(1,0,3, registers);

            //Then
            Assert.Equal(1, result1[0]);
            Assert.Equal(2, result1[1]);
            Assert.Equal(3, result1[2]);
            Assert.Equal(0, result1[3]);
            Assert.Equal(1, result2[3]);
        }
                
        [Fact]
        public void CanCheckLiteralIsEqualRegister()
        {
            //Given
            var registers = new[] {1,2,3,4};
            var systemUnderTest = new Eqir();

            //When
            var result1 = systemUnderTest.Execute(1,2,3, registers);
            var result2 = systemUnderTest.Execute(3,2,3, registers);

            //Then
            Assert.Equal(1, result1[0]);
            Assert.Equal(2, result1[1]);
            Assert.Equal(3, result1[2]);
            Assert.Equal(0, result1[3]);
            Assert.Equal(1, result2[3]);
        }
        
        [Fact]
        public void CanCheckRegisterIsEqualLiteral()
        {
            //Given
            var registers = new[] {1,2,3,4};
            var systemUnderTest = new Eqri();

            //When
            var result1 = systemUnderTest.Execute(1,2,3, registers);
            var result2 = systemUnderTest.Execute(1,0,3, registers);

            //Then
            Assert.Equal(1, result1[0]);
            Assert.Equal(2, result1[1]);
            Assert.Equal(3, result1[2]);
            Assert.Equal(1, result1[3]);
            Assert.Equal(0, result2[3]);
        }
        
        [Fact]
        public void CanCheckRegisterIEqualRegister()
        {
            //Given
            var registers = new[] {2,2,3,4};
            var systemUnderTest = new Eqrr();

            //When
            var result1 = systemUnderTest.Execute(1,2,3, registers);
            var result2 = systemUnderTest.Execute(1,0,3, registers);

            //Then
            Assert.Equal(2, result1[0]);
            Assert.Equal(2, result1[1]);
            Assert.Equal(3, result1[2]);
            Assert.Equal(0, result1[3]);
            Assert.Equal(1, result2[3]);
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
        public void Example1a()
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
        
        [Fact]
        public void Example1b()
        {
            //Given
            int[] before = new[] {3,2,1,1};
            int[] after = new[] {3,2,2,1};
            InstructionMatcher systemUnderTest = new InstructionMatcher();

            //When
            var result = systemUnderTest.MatchingCodes("Before: [3, 2, 1, 1] 9 2 1 2 After:  [3, 2, 2, 1]").Count();

            //Then
            Assert.Equal(3, result);
        }


    }
}