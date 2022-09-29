namespace TestProject_Common.Models
{
    public class Position
    {
        public Position()
        {

        }
        public Position(int X, int Y)
        {
            x = X;
            y = Y;
        }
        public int x { get; set; }
        public int y { get; set; }
    }

    public class CurrentPosition
    {
        public CurrentPosition()
        {

        }
        public CurrentPosition(Position position, string direction)
        {
            Position = position;
            Direction = direction;
        }
        public Position Position { get; set; }
        public string Direction { get; set; }
    }

    public static class Command
    {
        public const string RIGHT = "R";
        public const string LEFT = "L";
        public const string FORWARD = "F";
    }

    public static class Direction
    {
        public const string NORTH = "N";
        public const string SOUTH = "S";
        public const string EAST = "E";
        public const string WEST = "W";
    }
}
