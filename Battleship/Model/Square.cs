
namespace Battleship.Model
{
    public class Square
    {
        public (int, int) Position { get; set; }
        public SquareStatus SquareStatus { get; set; }
        public string ShowSquareStatus(SquareStatus status)
        {
            return status.ToString();
        }
    }
}

