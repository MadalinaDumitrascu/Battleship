using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.View;

namespace Battleship.Misc
{
    internal class MainMenu
    {
        public const string menu = @"Main Menu

1. Player vs Player
2. Player vs Computer
3. Settings
4. Exit


5. Map Test Area";

        public const string settings = @"Settings

1. Map size
2. Turns limit
3. Back";

        public const string mapSize = @"Map size settings

1. 15 x 15
2. 20 x 20
3. 25 x 25
4. Back";

        public const string turnsLimit = @"Turn Limit Settings

1. 5 turns
2. 10 turns
3. Unlimited
4. Back";

        public const string ChooseShip = @"Choose which ship you want to place

1. Patrol boat (2)
2. Destroyer (3)
3. Submarine (3)
4. Battleship (4)
5. Carrier (5)";

        public const string PlacingType = @"Placing type

1. Manual ship Placing
2. Random ship Placing";


        public const string Direction = @"Choose Direction

1. North
2. East
3. South
4. West";
    }
}
