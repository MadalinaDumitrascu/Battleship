using System.Text;


namespace Battleship.Model
{
    public class Board
    {
        public static int Size { get; set; } = 15;
        public int ID { get; set; }

        public Square[,] ocean { get; set; }
        public List<List<Square>> Places = new List<List<Square>>();

        public bool IsPlacementOk()
        {
            return false;
        }

        public Board(int identificator)
        {
            ID = identificator;
        }
        public void CreateBoard()
        {
            ocean = new Square[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    ocean[i, j] = new Square();
                    ocean[i, j].Position = (i, j);
                    ocean[i, j].SquareStatus = SquareStatus.Empty;
                }
            }

        }

        public string ToString(bool isConcealed)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" ");
            for (int i = 1; i <= Size; i++)
            {
                if (i < 10)
                {
                    sb.Append($"  {i}");
                }
                else
                {
                    sb.Append($" {i}");
                }

            }

            sb.Append("\n");

            for (char x = 'A'; x - 'A' < Size; x++)
            {
                sb.Append($"{x}");
                for (int i = 0; i < Size; i++)
                {
                    if (isConcealed)
                    {
                        if (ocean[x - 'A', i].SquareStatus == SquareStatus.Empty ||
                            ocean[x - 65, i].SquareStatus == SquareStatus.Occupied)
                        {
                            sb.Append("  .");
                        }
                    }
                    else
                    {
                        if (ocean[x - 'A', i].SquareStatus == SquareStatus.Empty) sb.Append("  .");
                        else if (ocean[x - 65, i].SquareStatus == SquareStatus.Occupied) sb.Append("  █");
                    }


                    if (ocean[x - 65, i].SquareStatus == SquareStatus.Hit) sb.Append("  H");

                    else if (ocean[x - 65, i].SquareStatus == SquareStatus.Missed) sb.Append("  M");

                    else if (ocean[x - 65, i].SquareStatus == SquareStatus.Sunk) sb.Append("  S");
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}


