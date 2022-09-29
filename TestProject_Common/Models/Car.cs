namespace TestProject_Common.Models
{
    public class Car
    {
        public Car()
        {

        }
        public Car(string carName, CurrentPosition currentPosition, string commands)
        {
            CarName = carName;
            CurrentPosition = currentPosition;
            Commands = commands;
        }
        public string CarName { get; set; }
        public CurrentPosition CurrentPosition { get; set; }
        public string Commands { get; set; }
    }
}
