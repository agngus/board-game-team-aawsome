using System;
using System.Collections.Generic;
using System.Text;
using System.Web;


namespace Gameengine
{
    public class Lobby
    {
        public static List<GameSession> PendingGame = new List<GameSession>();

        // Creates new game
        public static void CreateGame(int id, User p)
        {
            GameSession gameSession = new GameSession
            {
                GameID = id,
                Players = new User[2],
                Board = new User[9]
                {
                    new User {Side = "-" },
                    new User { Side = "-" },
                    new User { Side = "-" },
                    new User { Side = "-" },
                    new User { Side = "-" },
                    new User { Side = "-" },
                    new User { Side = "-" },
                    new User { Side = "-" },
                    new User { Side = "-" }
                }
            };
            gameSession.Players[0] = p;
            PendingGame.Add(gameSession);
        }

        // Finds pending game
        public static void FindGame(User p)
        {
            PendingGame[0].Players[1] = (p);
            ActiveGame.Game.Add(PendingGame[0]);
            PendingGame.Remove(PendingGame[0]);
            //GameIsFull();
        }

        // Finds GameSession object 
        public static GameSession GetSession(string cookieValue)
        {
            GameSession foundSession = null;
            for (int i = 0; i < 2; i++)
            {
                foundSession = PendingGame.Find(x => x.Players[i].PlayerID == cookieValue);
                if (foundSession.Players[i].PlayerID == cookieValue)
                {
                    break;
                }
            }
            return foundSession;
        }
    }
}
