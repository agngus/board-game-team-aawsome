using System;
using System.Collections.Generic;
using System.Text;

namespace Gameengine
{
    public class ActiveGame
    {
        public static List<GameSession> Game = new List<GameSession> { };
        
        /// <summary>
        /// Method that returns GameSession depending on cookie value
        /// </summary>
        /// <param name="cookieValue">Beskriving av cookie</param>
        /// <returns>Enspel session</returns>
        public static GameSession GetSession(string cookieValue)
        {
            GameSession foundSession = null;
            for (int i = 0; i < 2; i++)
            {
                var checkNull = Game.Find(x => x.Players[i].PlayerID == cookieValue);
                if (checkNull != null)
                {
                    foundSession = checkNull;
                }                
            }
            return foundSession;
        }
    }
}
