using TestProject_Common.Models;

namespace TestProject_Common.Helper
{
    public static class CarHelper
    {
        /// <summary>
        /// Change current dicrection when turn left
        /// </summary>
        /// <param name="currentDirection">Current direction of the car</param>
        /// <returns></returns>
        public static string CalculateDirectionTurnLeft(string currentDirection)
        {
            var currentDirec = currentDirection;

            switch (currentDirection)
            {
                case Direction.EAST:
                    currentDirec = Direction.NORTH;
                    break;
                case Direction.WEST:
                    currentDirec = Direction.SOUTH;
                    break;
                case Direction.SOUTH:
                    currentDirec = Direction.EAST;
                    break;
                case Direction.NORTH:
                    currentDirec = Direction.WEST;
                    break;
                default:
                    currentDirec = null;
                    break;
            }

            return currentDirec;
        }

        /// <summary>
        /// Change current dicrection when turn right
        /// </summary>
        /// <param name="currentDirection">Current direction of the car</param>
        /// <returns></returns>
        public static string CalculateDirectionTurnRight(string currentDirection)
        {
            var currentDirec = currentDirection;

            switch (currentDirection)
            {
                case Direction.EAST:
                    currentDirec = Direction.SOUTH;
                    break;
                case Direction.WEST:
                    currentDirec = Direction.NORTH;
                    break;
                case Direction.SOUTH:
                    currentDirec = Direction.WEST;
                    break;
                case Direction.NORTH:
                    currentDirec = Direction.EAST;
                    break;
                default:
                    currentDirec = null;
                    break;
            }

            return currentDirec;
        }

        /// <summary>
        /// calculate current position when moving forward base on current direction
        /// </summary>
        /// <param name="CurrentPosition">x and y of current position</param>
        /// <param name="currentDirection"></param>
        /// <param name="theBoundary">when reach boudary will consider to foward or not</param>
        /// <returns></returns>
        public static Position CalculateCurrentPositionFoward(Position CurrentPosition, string currentDirection, Position theBoundary)
        {

            var currentDirec = CurrentPosition;
            switch (currentDirection)
            {
                case Direction.EAST:
                    if (CurrentPosition.x < theBoundary.x)
                        currentDirec.x++;
                    break;
                case Direction.WEST:
                    if (CurrentPosition.x > 0)
                        currentDirec.x--;
                    break;
                case Direction.SOUTH:
                    if (CurrentPosition.y > 0)
                        currentDirec.y--;
                    break;
                case Direction.NORTH:
                    if (CurrentPosition.y < theBoundary.y)
                        currentDirec.y++;
                    break;
                default:
                    break;
            }

            return currentDirec;
        }



        /// <summary>
        /// Update direction when turn left or right, update position when moving forward
        /// </summary>
        /// <param name="CurrentPosition"></param>
        /// <param name="currentDirection"></param>
        /// <param name="command"></param>
        /// <param name="theBoundary"></param>
        /// <returns></returns>
        public static CurrentPosition CalculateCurrentPositionForEachCommand(Position CurrentPosition, string currentDirection, string command, Position theBoundary)
        {
            var _current = new CurrentPosition();

            switch (command)
            {
                case Command.LEFT:
                    _current.Position = CurrentPosition;
                    _current.Direction = CalculateDirectionTurnLeft(currentDirection);
                    break;
                case Command.RIGHT:
                    _current.Position = CurrentPosition;
                    _current.Direction = CalculateDirectionTurnRight(currentDirection);
                    break;
                case Command.FORWARD:
                    _current.Position = CalculateCurrentPositionFoward(CurrentPosition, currentDirection, theBoundary);
                    _current.Direction = currentDirection;
                    break;
                default:
                    break;
            }

            return _current;
        }


        /// <summary>
        /// Check collision of 2 car, each car will move each step by command, if collision will show crash point, if no will show no collision
        /// </summary>
        /// <param name="cars">List of car need to check collision</param>
        /// <param name="theBoundary">boundary of map</param>
        public static bool CalculateCollision(Car[] cars, Position theBoundary)
        {
            try
            {
                var maxMove = cars.Select(x => x.Commands.Length).Max();
                var collide = false;

                for (var i = 0; i < maxMove; i++)
                {
                    foreach (Car car in cars)
                    {
                        if (i <= car.Commands.Length)
                        {
                            car.CurrentPosition = CarHelper.CalculateCurrentPositionForEachCommand(car.CurrentPosition.Position, car.CurrentPosition.Direction, car.Commands[i].ToString(), theBoundary);
                        }
                    }


                    if (cars[0].CurrentPosition.Position.x == cars[1].CurrentPosition.Position.x && cars[0].CurrentPosition.Position.y == cars[1].CurrentPosition.Position.y)
                    {
                        Console.WriteLine("Collision:");
                        Console.WriteLine($"{cars[0].CarName} {cars[1].CarName}");
                        Console.WriteLine($"{cars[0].CurrentPosition.Position.x} {cars[0].CurrentPosition.Position.y}");
                        Console.WriteLine(i + 1);
                        collide = true;
                        break;
                    }
                }

                if (!collide)
                    Console.WriteLine("No Collision");
                return collide;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: Message: {ex.Message}| Source: {ex.Source} | Inner Exception: {ex.InnerException} |Stack Trace: {ex.StackTrace}");
                throw;
            }

        }


        public static Position CalculateTheBoundary(Map map)
        {
            var theBoundary = new Position();
            theBoundary.x = map.Width - 1;
            theBoundary.y = map.Height - 1;
            return theBoundary;
        }
    }
}
