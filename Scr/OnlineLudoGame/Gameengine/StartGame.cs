using System;
using System.Collections.Generic;
using System.Text;
using System.Web;


namespace Gameengine
{
    public class CreateGame
    {
        public static List<GameSession> PendingGames = new List<GameSession>();        

        // Creates new game
        public static void MakeGame(int id, Player p)
        {
            GameSession gameSession = new GameSession
            {
                GameID = id,
                Players = new Player[2],
                //GameBoard = new GameBoard()
            };
            gameSession.Players[0] = p;
            PendingGames.Add(gameSession);
        }

        // Find pending game
        public static void FindGame(Player p)
        {
            PendingGames[0].Players[1] = (p);
            GameIsFull();
        }

        // If game is full, moves gamesession from PendingGame to GamesInPlay
        public static void GameIsFull()
        {
            foreach (GameSession session in PendingGames)
            {
                foreach (Player player in session.Players)
                {
                    if (player != null)
                    {
                        RunningGame.GamesInPlay.Add(session);
                        PendingGames.Remove(session);
                    }
                }
            }
        }
    }
}
