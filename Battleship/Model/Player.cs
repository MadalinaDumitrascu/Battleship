namespace Battleship.Model
{
    public class Player
    {
        public List<Ship> Ships = new List<Ship>(4);
        public bool IsAlive
        {
            get
            {
                if (Ships.Count <= 0) return false;
                return true;
            }
        }
        public int Id { get; set; }

        public Player(int id)
        {
            Id = id;
        }

        public void Shoot(Board board, (int,int) coords)
        {
            if (board.ocean[coords.Item1, coords.Item2].SquareStatus == SquareStatus.Occupied)
            {
                board.ocean[coords.Item1, coords.Item2].SquareStatus = SquareStatus.Hit;
                foreach (var ship in Ships)
                {
                    foreach (var square in ship.SquareList)
                    {
                        if (square.Position == coords)
                        {
                            square.SquareStatus = SquareStatus.Hit;
                            
                        }
                    }
                }
            }

            else if (board.ocean[coords.Item1, coords.Item2].SquareStatus == SquareStatus.Empty)
            {
                board.ocean[coords.Item1, coords.Item2].SquareStatus = SquareStatus.Missed;
            }
        }

        public void SinkShip(Board board)
        {
            Ship? toBeDeletedShip = null;
            foreach (var ship in Ships)
            {
                if (ship.SunkState(board))
                {
                    toBeDeletedShip = ship;
                }
            }

            if(toBeDeletedShip is not null)Ships.Remove(toBeDeletedShip);
        }
    }
}

    