using System;
using System.Collections.Generic;
using System.Text;

namespace Gameengine
{
    public class GameSession
    {
        public int GameID { get; set; }
        public Player[] Players { get; set; }
        public Player[] Board = new Player[9];       

    }
}
