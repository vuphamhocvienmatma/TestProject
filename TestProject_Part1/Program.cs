using TestProject_Common.Helper;
using TestProject_Common.Models;

public class Program
{
    public static void Main()
    {
        #region Begin part 1
        Console.WriteLine("#Auto Driving Car Simulation");
        Console.WriteLine("#Part 1");
        Console.WriteLine(@"
        Please input parammeter for program 
        The fist line indicates the width and height of the field.
        The second line indicates the current position and facing direction of the car.
        The last line shows the subsequent commands it will execute");
        Console.WriteLine(@"
        Sample:
        10 10
        1 2 N
        FFRFFFRRLF");
        Map map = new Map();
        CurrentPosition currentPosition = new CurrentPosition();
        Position theBoundary = new Position();

    inputParam:
        string widthAndHeightOfTheFieldInput = Console.ReadLine();
        string currentPosAndDirectionInput = Console.ReadLine();
        string paramsubsequentCommands = Console.ReadLine();

        #endregion
        #region Validate and init parameter for project part 1
        if (string.IsNullOrEmpty(widthAndHeightOfTheFieldInput) || string.IsNullOrEmpty(currentPosAndDirectionInput) || string.IsNullOrEmpty(paramsubsequentCommands))
        {
            Console.WriteLine("Please look at sample and input again");
            goto inputParam;
        }

        // the width and height of the map
        var paramWidthAndHeight = widthAndHeightOfTheFieldInput.Split(null);

        int mapWidth = 0;
        int mapHeight = 0;
        var isParseW = int.TryParse(paramWidthAndHeight[0], out mapWidth);
        var isParseH = int.TryParse(paramWidthAndHeight[1], out mapHeight);
        if (!isParseW || !isParseH)
        {
            Console.WriteLine("Please look at sample and input again");
            goto inputParam;
        }
        map.Width = mapWidth;
        map.Height = mapHeight;

        theBoundary = CarHelper.CalculateTheBoundary(map);
        //  the current position and facing direction of the car
        var paramCurrentPosAndDirection = currentPosAndDirectionInput.Split(null);

        int currentX = 0;
        int currentY = 0;

        var isParsecurrentX = int.TryParse(paramCurrentPosAndDirection[0], out currentX);
        var isParsecurrentY = int.TryParse(paramCurrentPosAndDirection[1], out currentY);



        if (!isParsecurrentX || !isParsecurrentY)
        {
            Console.WriteLine("Please look at sample and input again");
            goto inputParam;
        }
        if (paramCurrentPosAndDirection[2] != "N" && paramCurrentPosAndDirection[2] != "S" && paramCurrentPosAndDirection[2] != "W" && paramCurrentPosAndDirection[2] != "E")
        {

            Console.WriteLine("Please look at sample and input again");
            goto inputParam;
        }

        currentPosition.Direction = paramCurrentPosAndDirection[2];
        currentPosition.Position = new Position();
        currentPosition.Position.x = currentX;
        currentPosition.Position.y = currentY;
        #endregion

        #region Result
        foreach (var command in paramsubsequentCommands)
        {
            currentPosition = CarHelper.CalculateCurrentPositionForEachCommand(currentPosition.Position, currentPosition.Direction, command.ToString(), theBoundary);
        }
        Console.WriteLine("Part 1 result");
        Console.WriteLine($"Car has position at: {currentPosition.Position.x} {currentPosition.Position.y} {currentPosition.Direction}");

        #endregion
        Console.ReadLine();
    }

}