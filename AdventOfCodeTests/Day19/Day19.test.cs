using jonny.AoC.Day19;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day19
{
    public class Day19Tests
    {
        [Fact]
        public void HaltsForAnEmptyProgram()
        {
            //Given#
            string[] program = new [] {"#ip 0"};
            var systemUnderTest = new JumpingInstructionRunner();

            //When
            int result = systemUnderTest.Run(program);
            
            //Then
            Assert.Equal(0, result);
        }

        [Fact]
        public void Example1()
        {
            //Given#
            string[] program = new [] {"#ip 0",
"seti 5 0 1",
"seti 6 0 2",
"addi 0 1 0",
"addr 1 2 3",
"setr 1 0 0",
"seti 8 0 4",
"seti 9 0 5"};
            var systemUnderTest = new JumpingInstructionRunner();

            //When
            int result = systemUnderTest.Run(program);
            
            //Then
            Assert.Equal(7, result);
        }
    }
}