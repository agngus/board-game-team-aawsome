using System;
using System.Collections.Generic;
using System.Text;

namespace Gameengine
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string Email { get; set; }
        public List<Player> testList = new List<Player> { };
    }
}
