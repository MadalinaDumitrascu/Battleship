﻿namespace Battleship.Model
{
    public class Player
    {
        public List<Ship> Ships;
        public bool IsAlive
        {
            get
            {
                if (Ships == null) return false;
                return true;
            }
        }
    }
}

    