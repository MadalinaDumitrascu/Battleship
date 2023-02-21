namespace Battleship.Model
{
    public class Ship
    {
        
        public List<Square> SquareList;

        public bool SunkState(Board board)
        {
            int shipLength = SquareList.Count;
            foreach (Square square in SquareList)
                if (square.SquareStatus == SquareStatus.Hit) 
                    shipLength -= 1;

            if (shipLength == 0)
            {
                foreach (Square square in SquareList)
                {
                    square.SquareStatus = SquareStatus.Sunk;
                    board.ocean[square.Position.Item1, square.Position.Item2].SquareStatus = SquareStatus.Sunk;
                }

                return true;
            }

            return false;
        }
    }
}

