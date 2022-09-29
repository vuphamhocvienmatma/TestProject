using TestProject_Common.Helper;
using TestProject_Common.Models;
public class Program
{
    public static void Main()
    {
        #region Begin part 2
        Console.WriteLine("#Auto Driving Car Simulation");
        Console.WriteLine("#Part 2");
        Console.WriteLine(@"
        Please input parammeter for program 
        Similar to Par 1, the sample input consists the field width and height. 
        But this time, it contains multiple sections for each car:");
        Console.WriteLine(@"
        Sample:
        10 10
        A
        1 2 N
        FFRFFFFRRL
        
        B
        7 8 W
        FFLFFFFFFF");
        Map map = new Map();
        Position theBoundary = new Position();
        Car Car1 = new Car();
        Car Car2 = new Car();

    #endregion
    #region Validate and init parameter for project part 2
    inputMap:

        var widthAndHeightOfTheFieldInput = Console.ReadLine();
        if (string.IsNullOrEmpty(widthAndHeightOfTheFieldInput))
        {
            Console.WriteLine("Please look at sample and input param for map again");
            goto inputMap;
        }
        var paramWidthAndHeight = widthAndHeightOfTheFieldInput.Split(null);
        int mapWidthPart2 = 0;
        int mapHeightPart2 = 0;
        var isParseWPart2 = int.TryParse(paramWidthAndHeight[0], out mapWidthPart2);
        var isParseHPart2 = int.TryParse(paramWidthAndHeight[1], out mapHeightPart2);
        if (!isParseWPart2 || !isParseHPart2)
        {
            Console.WriteLine("Please look at sample and input param for map again");
            goto inputMap;
        }
        map.Width = mapWidthPart2;
        map.Height = mapHeightPart2;
        theBoundary = CarHelper.CalculateTheBoundary(map);

    inputParamPart2Car1:
        string car1Name = Console.ReadLine();
        string currentPosAndDirectionInputCar1 = Console.ReadLine();
        string paramsubsequentCommandsCar1 = Console.ReadLine();
        if (string.IsNullOrEmpty(car1Name) || string.IsNullOrEmpty(currentPosAndDirectionInputCar1) || string.IsNullOrEmpty(paramsubsequentCommandsCar1))
        {
            Console.WriteLine("Please look at sample and input param for map again");
            goto inputParamPart2Car1;
        }
        Car1.CarName = car1Name;


        var paramCurrentPosAndDirectionCar1 = currentPosAndDirectionInputCar1.Split(null);

        int currentX1 = 0;
        int currentY1 = 0;

        var isParsecurrentX1 = int.TryParse(paramCurrentPosAndDirectionCar1[0], out currentX1);
        var isParsecurrentY1 = int.TryParse(paramCurrentPosAndDirectionCar1[1], out currentY1);



        if (!isParsecurrentX1 || !isParsecurrentY1)
        {
            Console.WriteLine("Please look at sample and input param for car 1 again");
            goto inputParamPart2Car1;
        }
        if (paramCurrentPosAndDirectionCar1[2] != "N" && paramCurrentPosAndDirectionCar1[2] != "S" && paramCurrentPosAndDirectionCar1[2] != "W" && paramCurrentPosAndDirectionCar1[2] != "E")
        {

            Console.WriteLine("Please look at sample and input param for car 1 again");
            goto inputParamPart2Car1;
        }
        Car1.CurrentPosition = new CurrentPosition();
        Car1.CurrentPosition.Direction = paramCurrentPosAndDirectionCar1[2];
        Car1.CurrentPosition.Position = new Position();
        Car1.CurrentPosition.Position.x = currentX1;
        Car1.CurrentPosition.Position.y = currentY1;

        Car1.Commands = paramsubsequentCommandsCar1;


    inputParamPart2Car2:
        string car2Name = Console.ReadLine();
        string currentPosAndDirectionInputCar2 = Console.ReadLine();
        string paramsubsequentCommandsCar2 = Console.ReadLine();
        if (string.IsNullOrEmpty(car2Name) || string.IsNullOrEmpty(currentPosAndDirectionInputCar2) || string.IsNullOrEmpty(paramsubsequentCommandsCar2))
        {
            Console.WriteLine("Please look at sample and input param for car 2 again");
            goto inputParamPart2Car2;
        }
        Car2.CarName = car2Name;

        var paramCurrentPosAndDirectionCar2 = currentPosAndDirectionInputCar2.Split(null);

        int currentX2 = 0;
        int currentY2 = 0;

        var isParsecurrentX2 = int.TryParse(paramCurrentPosAndDirectionCar2[0], out currentX2);
        var isParsecurrentY2 = int.TryParse(paramCurrentPosAndDirectionCar2[1], out currentY2);

        if (!isParsecurrentX2 || !isParsecurrentY2)
        {
            Console.WriteLine("Please look at sample and input param for car 2 again");
            goto inputParamPart2Car1;
        }
        if (paramCurrentPosAndDirectionCar2[2] != "N" && paramCurrentPosAndDirectionCar2[2] != "S" && paramCurrentPosAndDirectionCar2[2] != "W" && paramCurrentPosAndDirectionCar2[2] != "E")
        {

            Console.WriteLine("Please look at sample and input param for car 2 again");
            goto inputParamPart2Car1;
        }
        Car2.CurrentPosition = new CurrentPosition();
        Car2.CurrentPosition.Direction = paramCurrentPosAndDirectionCar2[2];
        Car2.CurrentPosition.Position = new Position();
        Car2.CurrentPosition.Position.x = currentX2;
        Car2.CurrentPosition.Position.y = currentY2;

        Car2.Commands = paramsubsequentCommandsCar2;

        #endregion

        #region Result
        bool result = CarHelper.CalculateCollision(new Car[] { Car1, Car2 }, theBoundary);
        #endregion

        Console.ReadLine();
    }

}