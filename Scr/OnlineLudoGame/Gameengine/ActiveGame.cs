using System;
using System.Collections.Generic;
using System.Text;

namespace Gameengine
{
    public class ActiveGame
    {
        public static List<GameSession> Game = new List<GameSession> { };

        public static GameSession GetSession(string cookieValue)
        {
            GameSession foundSession = null;
            for (int i = 0; i < 2; i++)
            {
                foundSession = Game.Find(x => x.Players[i].PlayerID == cookieValue);
                break;
            }
            return foundSession;
        }
    }

}
