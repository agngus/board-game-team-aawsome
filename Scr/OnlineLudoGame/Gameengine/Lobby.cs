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
            };
            gameSession.Players[0] = p;
            PendingGame.Add(gameSession);
        }

        // Find pending game
        public static void FindGame(User p)
        {
            PendingGame[0].Players[1] = (p);
            ActiveGame.Game.Add(PendingGame[0]);
            PendingGame.Remove(PendingGame[0]);
            //GameIsFull();
        }

        //// If game is full, moves gamesession from PendingGame to GamesInPlay
        //public static void GameIsFull()
        //{

        //    if (PendingGames[0].Players[1] != null)
        //    {
        //        RunningGame.GamesInPlay.Add(PendingGames[0]);
        //        PendingGames.Remove(PendingGames[0]);
        //    }

        //}
    }
}
