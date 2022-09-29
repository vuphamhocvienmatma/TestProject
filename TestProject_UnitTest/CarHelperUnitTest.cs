using TestProject_Common.Helper;
using TestProject_Common.Models;
using Xunit;

namespace TestProject_UnitTest
{
    public class CarHelperUnitTest
    {
        [Fact]
        public void CarHelper_CalculateTheBoundary()
        {
            // Arrange
            Map map = new Map(10, 10);

            // Act
            var theBoudary = CarHelper.CalculateTheBoundary(map);

            // Assert
            Assert.NotNull(theBoudary);
            Assert.Equal(9, theBoudary.x);
            Assert.Equal(9, theBoudary.y);
        }

        [Fact]
        public void CarHelper_CalculateDirectionTurnLeft()
        {
            // Assert
            Assert.Null(CarHelper.CalculateDirectionTurnLeft(""));

            Assert.Equal(Direction.NORTH, CarHelper.CalculateDirectionTurnLeft(Direction.EAST));
            Assert.Equal(Direction.SOUTH, CarHelper.CalculateDirectionTurnLeft(Direction.WEST));
            Assert.Equal(Direction.EAST, CarHelper.CalculateDirectionTurnLeft(Direction.SOUTH));
            Assert.Equal(Direction.WEST, CarHelper.CalculateDirectionTurnLeft(Direction.NORTH));

        }

        [Fact]
        public void CarHelper_CalculateDirectionTurnRight()
        {
            // Assert
            Assert.Null(CarHelper.CalculateDirectionTurnRight(""));

            Assert.Equal(Direction.SOUTH, CarHelper.CalculateDirectionTurnRight(Direction.EAST));
            Assert.Equal(Direction.NORTH, CarHelper.CalculateDirectionTurnRight(Direction.WEST));
            Assert.Equal(Direction.WEST, CarHelper.CalculateDirectionTurnRight(Direction.SOUTH));
            Assert.Equal(Direction.EAST, CarHelper.CalculateDirectionTurnRight(Direction.NORTH));

        }


        [Fact]
        public void CarHelper_CalculateCurrentPositionFoward()
        {
            // Arrange                   
            Position theBoundary = new Position(9, 9);

            // Act
            var result = CarHelper.CalculateCurrentPositionFoward(new Position(5, 5), Direction.NORTH, theBoundary);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.x);
            Assert.Equal(6, result.y);


            result = CarHelper.CalculateCurrentPositionFoward(new Position(5, 5), Direction.SOUTH, theBoundary);
            Assert.Equal(5, result.x);
            Assert.Equal(4, result.y);

            result = CarHelper.CalculateCurrentPositionFoward(new Position(5, 5), Direction.EAST, theBoundary);
            Assert.Equal(6, result.x);
            Assert.Equal(5, result.y);

            result = CarHelper.CalculateCurrentPositionFoward(new Position(5, 5), Direction.WEST, theBoundary);
            Assert.Equal(4, result.x);
            Assert.Equal(5, result.y);

            // get out of map
            result = CarHelper.CalculateCurrentPositionFoward(new Position(9, 9), Direction.NORTH, theBoundary);
            Assert.Equal(9, result.x);
            Assert.Equal(9, result.y);
        }

        [Fact]
        public void CarHelper_CalculateCurrentPositionForEachCommand()
        {
            // Arrange                   
            Position theBoundary = new Position(9, 9);
            string commands = "LFF";
            // Act
            var result = CarHelper.CalculateCurrentPositionForEachCommand(new Position(5, 5), Direction.NORTH, Command.LEFT, theBoundary);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Position.x);
            Assert.Equal(5, result.Position.x);
            Assert.Equal(Direction.WEST, result.Direction);

            result = CarHelper.CalculateCurrentPositionForEachCommand(new Position(5, 5), Direction.NORTH, Command.RIGHT, theBoundary);
            Assert.Equal(5, result.Position.x);
            Assert.Equal(5, result.Position.y);
            Assert.Equal(Direction.EAST, result.Direction);

            result = CarHelper.CalculateCurrentPositionForEachCommand(new Position(5, 5), Direction.NORTH, Command.FORWARD, theBoundary);
            Assert.Equal(5, result.Position.x);
            Assert.Equal(6, result.Position.y);
            Assert.Equal(Direction.NORTH, result.Direction);
        }


        [Fact]
        public void CarHelper_CalculateCollision()
        {
            // Arrange                   
            Position theBoundary = new Position(9, 9);
            var Car1 = new Car("A", new CurrentPosition(new Position(1, 2), Direction.NORTH), "FFRFFFFRRL");
            var Car2 = new Car("B", new CurrentPosition(new Position(7, 8), Direction.WEST), "FFLFFFFFFF");
            // Act
            var result = CarHelper.CalculateCollision(new Car[] { Car1, Car2 }, theBoundary);
            // Assert
            Assert.True(result);

            var Car3 = new Car("A", new CurrentPosition(new Position(1, 1), Direction.NORTH), "LLLL");
            var Car4 = new Car("B", new CurrentPosition(new Position(2, 2), Direction.WEST), "RRRR");

            result = CarHelper.CalculateCollision(new Car[] { Car3, Car4 }, theBoundary);

            Assert.True(!result);
        }
    }
}