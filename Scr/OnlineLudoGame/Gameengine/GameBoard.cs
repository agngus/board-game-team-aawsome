using System;
using System.Collections.Generic;
using System.Text;

namespace Gameengine
{
    public class GameBoard
    {
        public CellState[] Board { get; set; }

        public GameBoard()
        {
            Board = new CellState[9];
        }
    }
}
