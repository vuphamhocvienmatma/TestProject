namespace TestProject_Common.Models
{
    public class Map
    {
        public Map()
        {

        }
        public Map(int x, int y)
        {
            Width = x;
            Height = y;
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
