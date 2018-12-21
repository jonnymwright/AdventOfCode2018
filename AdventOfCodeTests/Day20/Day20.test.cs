using jonny.AoC.Day20;
using System.Linq;
using Xunit;

namespace jonny.AoCTests.Day20
{
    public class Day20Tests
    {
        [Fact]
        public void CanWalkInOneDirection()
        {
            //Given
            var systemUnderTest = new DoorWalker();            

            //When
            systemUnderTest.Walk("^N$");
            int result = systemUnderTest.FurthestRoom();
            
            //Then
            Assert.Equal(1, result);
        }

        [Fact]
        public void CanCloseATwoLoop()
        {
            //Given
            var systemUnderTest = new DoorWalker();            

            //When
            systemUnderTest.Walk("^NS$");
            int result = systemUnderTest.FurthestRoom();

            //Then
            Assert.Equal(1, result);
        }
        
        [Fact]
        public void CanCloseABigLoop()
        {
            //Given
            var systemUnderTest = new DoorWalker();            

            //When
            systemUnderTest.Walk("^NNWSSE$");
            int result = systemUnderTest.FurthestRoom();

            //Then
            Assert.Equal(3, result);
        }
        
        [Fact]
        public void CanBranch()
        {
            //Given
            var systemUnderTest = new DoorWalker();            

            //When
            systemUnderTest.Walk("^N(S|W)$");
            int result = systemUnderTest.FurthestRoom();

            //Then
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void CanNestedBranch()
        {
            //Given
            var systemUnderTest = new DoorWalker();            

            //When
            systemUnderTest.Walk("^N(N|S|(NN|WW)N|E)$");
            int result = systemUnderTest.FurthestRoom();

            //Then
            Assert.Equal(4, result);
        }
                
        [Fact]
        public void CanCloseOffABranch()
        {
            //Given
            var systemUnderTest = new DoorWalker();            

            //When
            systemUnderTest.Walk("^(NS|SN|EW)W$");

            //Then
            Assert.Equal(2, systemUnderTest.Closed);
        }
        
        [Fact]
        public void Example1()
        {
            //Given
            var systemUnderTest = new DoorWalker();            

            //When
            systemUnderTest.Walk("^ESSWWN(E|NNENN(EESS(WNSE|)SSS|WWWSSSSE(SW|NNNE)))$");
            int result = systemUnderTest.FurthestRoom();

            //Then
            Assert.Equal(23, result);
        }
        
        [Fact]
        public void Example2()
        {
            //Given
            var systemUnderTest = new DoorWalker();            

            //When
            systemUnderTest.Walk("^WSSEESWWWNW(S|NENNEEEENN(ESSSSW(NWSW|SSEN)|WSWWN(E|WWS(E|SS))))$");
            int result = systemUnderTest.FurthestRoom();

            //Then
            Assert.Equal(31, result);
        }
    }
}