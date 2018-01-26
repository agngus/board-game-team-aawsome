using System;
using System.Collections.Generic;
using System.Text;

namespace Gameengine
{
    public class CurrentPlayer
    {
        public static string SetStartingPlayer(int index)
        {
            return RunningGame.GamesInPlay[index].Players[0].PlayerID;
        }

        public static string SwapCurrentPlayer(GameSession gameSession, Player currentPlayer)
        {
            string cookieValue = "Error! currentplayer is neither player 1 or 2";
            if (currentPlayer.PlayerID == gameSession.Players[0].PlayerID)
            {
                cookieValue = currentPlayer.PlayerID = gameSession.Players[1].PlayerID;
            }
            else if (currentPlayer.PlayerID == gameSession.Players[1].PlayerID)
            {
                cookieValue = currentPlayer.PlayerID = gameSession.Players[0].PlayerID;
            }
            return cookieValue;
        }
    }
}
