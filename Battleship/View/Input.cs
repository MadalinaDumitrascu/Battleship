using System;
using System.Text.RegularExpressions;

namespace Battleship.View
{
    internal class Input
    {
        public static int GetInput()
        {
            int option = 0;
        chooseOption:
            string? input = Console.ReadLine();
            if (input != null && Regex.IsMatch(input, @"^\d+$"))
            {
               option = int.Parse(input);
               
            }
            else goto chooseOption;
            return option;

        }

        public static (int, int) GetCoordinates(int size)
        {
            (int, int) option = (0, 0);
            chooseOption:
            string input = Console.ReadLine().ToUpper();

            if (input.Length < 2)
            {
                goto chooseOption;
            }
            option.Item1 = input[0] - 65;
            option.Item2 = int.Parse(input.Substring(1, input.Length-1)) - 1;
            if (option.Item1 < size && option.Item2 < size) return option;
            goto chooseOption;

        }

    }
}
