using System;
using System.Collections.Generic;
using System.Text;

namespace Gameengine
{
    public class CurrentPlayer
    {
        public static string SetStartingPlayer()
        {
            return RunningGame.GamesInPlay[0].Players[0].PlayerID;
        }

        public static string SwapCurrentPlayer(GameSession gameSession, Player currentPlayer)
        {
            if (currentPlayer.PlayerID == gameSession.Players[0].PlayerID)
            {
                return currentPlayer.PlayerID = gameSession.Players[1].PlayerID;
            }
            else
               if (currentPlayer.PlayerID == gameSession.Players[1].PlayerID)
            {
                return currentPlayer.PlayerID = gameSession.Players[0].PlayerID;
            }

            return "Error! currentplayer is neither player 1 or 2";
        }
    }
}
