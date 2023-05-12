using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class RoverTest
    {
        [Test]
        public void TurnsRightNorthToEast()
        {
            Rover rover = new Rover("N", new int[] {0, 0});
            rover.Go("R");
            Assert.That(rover.Facing, Is.EqualTo("E"));
        }
        
        [Test]
        public void TurnsRightEastToSouth()
        {
            Rover rover = new Rover("E", new int[] {0, 0});
            rover.Go("R");
            Assert.That(rover.Facing, Is.EqualTo("S"));
        }
        
        [Test]
        public void TurnsRightSouthToWest()
        {
            Rover rover = new Rover("S", new int[] {0, 0});
            rover.Go("R");
            Assert.That(rover.Facing, Is.EqualTo("W"));
        }
        
        [Test]
        public void TurnsRightWestToNorth()
        {
            Rover rover = new Rover("W", new int[] {0, 0});
            rover.Go("R");
            Assert.That(rover.Facing, Is.EqualTo("N"));
        }

        [Test]
        public void TurnsLeftNorthToWest()
        {
            Rover rover = new Rover("N", new int[] {0, 0});
            rover.Go("L");
            Assert.That(rover.Facing, Is.EqualTo("W"));
        }
        
        [Test]
        public void TurnsLeftWestToSouth()
        {
            Rover rover = new Rover("W", new int[] {0, 0});
            rover.Go("L");
            Assert.That(rover.Facing, Is.EqualTo("S"));
        }
        
        [Test]
        public void TurnsLeftSouthToEast()
        {
            Rover rover = new Rover("S", new int[] {0, 0});
            rover.Go("L");
            Assert.That(rover.Facing, Is.EqualTo("E"));
        }
        
        [Test]
        public void TurnsLeftEastToNorth()
        {
            Rover rover = new Rover("E", new int[] {0, 0});
            rover.Go("L");
            Assert.That(rover.Facing, Is.EqualTo("N"));
        }

        [TestCase("N", new int[]{5, 5}, new int[]{5, 6})]
        [TestCase("E", new int[]{5, 5}, new int[]{6, 5})]
        [TestCase("S", new int[]{5, 5}, new int[]{5, 4})]
        [TestCase("W", new int[]{5, 5}, new int[]{4, 5})]
        public void MovesForwardInDirectionFacing(string facing, int[] startCoords, int[] endCoords)
        {
            Rover rover = new Rover(facing, startCoords);
            rover.Go("F");
            CollectionAssert.AreEqual(endCoords, rover.Coordinates);
        }
        
        [TestCase("N", new int[]{5, 5}, new int[]{5, 4})]
        [TestCase("E", new int[]{5, 5}, new int[]{4, 5})]
        [TestCase("S", new int[]{5, 5}, new int[]{5, 6})]
        public void MovesBackwardsFromDirectionFacing(string facing, int[] startCoords, int[] endCoords)
        {
            Rover rover = new Rover(facing, startCoords);
            rover.Go("B");
            CollectionAssert.AreEqual(endCoords, rover.Coordinates);
        }

        [Test]
        public void ExecutesSequenceOfInstructions()
        {
            Rover rover = new Rover("N", new int[]{6, 7});
            rover.Go("RFF");
            Assert.That(rover.Facing, Is.EqualTo("E"));
            CollectionAssert.AreEqual(new int[]{8, 7}, rover.Coordinates);
        }
    }
}