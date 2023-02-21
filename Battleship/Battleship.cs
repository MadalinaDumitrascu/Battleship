using Battleship.Controller;


namespace Battleship
{
    public class Battleship
    {

        public static void Main()
        {
            
            bool isGameon = true;
            Game game = new Game();
            game.Start();
            while (isGameon)
            {
                game.Round();
                if (game.IsWinning())
                {
                    isGameon = false;
                }
            }



        }
    }
} 

//To do - have to display the board after the last boat is placed for each player