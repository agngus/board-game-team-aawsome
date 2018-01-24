using System;
using System.Collections.Generic;
using System.Text;

namespace Gameengine
{
    public class GameSession
    {
        public string GameID { get; set; }
        public Player[] Players { get; set; }
        public Player[] Board = new Player[9];
        //public GameBoard GameBoard { get; set; }
    }
}
