﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gameengine
{
    class GameBoard
    {
        public int GameID { get; set; }
        public Player[] Players { get; set; }
        public CellState[] BoardCells { get; set; }
    }
}
