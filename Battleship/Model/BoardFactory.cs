using Battleship.Misc;
using Battleship.Model;
using Battleship.View;

namespace Battleship
{
    public class BoardFactory
    {
        public static void ManualPlacement(Board board, Player player)
        {
            while (player.Ships.Count < 4)
            {
                int shipSize = 0;
                Display.Clear();
                Display.ShowBoard(board.ToString(false));
                Display.ShowText(MainMenu.ChooseShip);
                switch (Input.GetInput())
                {
                    case 1:
                        shipSize = (int)ShipType.PatrolBoat;
                        break;
                    case 2:
                        shipSize = (int)ShipType.Destroyer;
                        break;
                    case 3:
                        shipSize = (int)ShipType.Submarine;
                        break;
                    case 4:
                        shipSize = (int)ShipType.Battleship;
                        break;
                    case 5:
                        shipSize = (int)ShipType.Carrier;
                        break;
                    default:
                        Display.ShowText(Errors.invalidInput);
                        break;
                }
                Display.ShowText(Messages.ChooseCoordinates);
                (int, int) coordinates = Input.GetCoordinates(Board.Size);


                Display.ShowText(MainMenu.Direction);
                switch (Input.GetInput())
                {
                    case 1:
                        if (CheckDirection(coordinates.Item1, coordinates.Item2, shipSize, board, 1))
                        {
                            Ship ship = new Ship();
                            ship.SquareList = new List<Square>(shipSize);
                            for (int i = 0; i < shipSize; i++)
                            {

                                ship.SquareList.Add(board.ocean[coordinates.Item1 - i, coordinates.Item2]);
                                board.ocean[coordinates.Item1 - i, coordinates.Item2].SquareStatus = SquareStatus.Occupied;
                            }
                            player.Ships.Add(ship);
                            

                        }
                        break;
                    case 2:
                        if (CheckDirection(coordinates.Item1, coordinates.Item2, shipSize, board, 2))
                        {
                            Ship ship = new Ship();
                            ship.SquareList = new List<Square>(shipSize);
                            for (int i = 0; i < shipSize; i++)
                            {

                                ship.SquareList.Add(board.ocean[coordinates.Item1, coordinates.Item2 + i]);
                                board.ocean[coordinates.Item1, coordinates.Item2 + i].SquareStatus = SquareStatus.Occupied;
                            }
                            player.Ships.Add(ship);
                            
                        }
                        break;
                    case 3:
                        if (CheckDirection(coordinates.Item1, coordinates.Item2, shipSize, board, 3))
                        {
                            Ship ship = new Ship();
                            ship.SquareList = new List<Square>(shipSize);
                            for (int i = 0; i < shipSize; i++)
                            {

                                ship.SquareList.Add(board.ocean[coordinates.Item1 + i, coordinates.Item2]);
                                board.ocean[coordinates.Item1 + i, coordinates.Item2].SquareStatus = SquareStatus.Occupied;
                            }
                            player.Ships.Add(ship);
                            
                        }
                        break;
                    case 4:
                        if (CheckDirection(coordinates.Item1, coordinates.Item2, shipSize, board, 4))
                        {
                            Ship ship = new Ship();
                            ship.SquareList = new List<Square>(shipSize);
                            for (int i = 0; i < shipSize; i++)
                            {

                                ship.SquareList.Add(board.ocean[coordinates.Item1, coordinates.Item2 - i]);
                                board.ocean[coordinates.Item1, coordinates.Item2 - i].SquareStatus = SquareStatus.Occupied;
                            }
                            player.Ships.Add(ship);
                            
                        }
                        break;
                    default:
                        Display.Clear();
                        Display.ShowText(Errors.invalidInput);
                        break;
                }
            }
        }

        public static void RandomPLacement(Board board, Player player)
        {

        }

        public static bool CheckDirection(int i, int j, int shipLength, Board board, int direction)
        {
            bool isEmpty = false;
            if (board.ocean[i, j].SquareStatus == SquareStatus.Empty && direction == 1)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    if (board.ocean[i - k, j].SquareStatus == SquareStatus.Empty && i - k > 0) isEmpty = true;
                    else return false;
                }
            }
            else if (board.ocean[i, j].SquareStatus == SquareStatus.Empty && direction == 2)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    if (board.ocean[i, j == Board.Size-1?Board.Size-1:j + k].SquareStatus == SquareStatus.Empty && j + k < Board.Size) isEmpty = true;
                    else return false;
                }
            }
            else if (board.ocean[i, j].SquareStatus == SquareStatus.Empty && direction == 3)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    if (board.ocean[i == Board.Size-1?Board.Size-1:i + k, j].SquareStatus == SquareStatus.Empty && i + k < Board.Size) isEmpty = true;
                    else return false;
                }
            }
            else if (board.ocean[i, j].SquareStatus == SquareStatus.Empty && direction == 4)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    if (board.ocean[i, j - k].SquareStatus == SquareStatus.Empty && j - k > 0) isEmpty = true;
                    else return false;
                }
            }
            return isEmpty;
        }

    }

}
