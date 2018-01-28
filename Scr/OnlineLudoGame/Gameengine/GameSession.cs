
using System;
using System.Collections.Generic;
using System.Text;

namespace Gameengine
{
    public class GameSession
    {
        public int GameID { get; set; }
        public User[] Players { get; set; }
        public User[] Board = new User[9];
        public bool FirstPlayerTurn = true;

        public void Turn(string cookieValue, string buttonClick)
        {
            if (this.FirstPlayerTurn == true)
            {
                var session = Gameengine.ActiveGame.Game.FindIndex(x => x.Players[0].PlayerID == cookieValue);
                if (cookieValue == this.Players[0].PlayerID)
                {
                    var player1 = this.Players[0];
                    int indexPressed = int.Parse(buttonClick);
                    this.Board[indexPressed] = player1;
                    this.FirstPlayerTurn = false;
                    Gameengine.ActiveGame.Game[session] = this;
                }
            }
            else if (this.FirstPlayerTurn == false)
            {
                var session = Gameengine.ActiveGame.Game.FindIndex(x => x.Players[1].PlayerID == cookieValue);
                if (cookieValue == this.Players[1].PlayerID)
                {
                    var player2 = this.Players[1];
                    int indexPressed = int.Parse(buttonClick);
                    this.Board[indexPressed] = player2;
                    this.FirstPlayerTurn = true;
                    Gameengine.ActiveGame.Game[session] = this;
                }
            }
        }

        public string[] WriteBoard()
        {
            string[] cell = new string[9];
            for (int i = 0; i < 9; i++)
            {
                try
                {
                    if (this.Board[i].Side != null)
                    {
                        cell[i] = this.Board[i].Side;
                    }
                    else if (this == null)
                    {
                        cell[i] = "";
                    }
                }
                catch
                {
                    cell[i] = "";
                }
            }
            return cell;
        }

        public string WinConditions()
        {
            string winMessage = "";
            // condition 1
            for (int i = 0; i < 2; i++)
            {
                if (this.Board[0] == this.Players[i] && this.Board[1] == this.Players[i] && this.Board[2] == this.Players[i])
                {
                    winMessage = this.Players[i].Name + " has won!";
                }
                // condition 2
                else if
                  (this.Board[0] == this.Players[i] && this.Board[3] == this.Players[i] && this.Board[6] == this.Players[i])
                {
                    winMessage = this.Players[i].Name + " has won!";
                }
                // condition 3
                else if
                  (this.Board[6] == this.Players[i] && this.Board[7] == this.Players[i] && this.Board[8] == this.Players[i])
                {
                    winMessage = this.Players[i].Name + " has won!";
                }
                // condition 4
                else if
                  (this.Board[2] == this.Players[i] && this.Board[5] == this.Players[i] && this.Board[8] == this.Players[i])
                {
                    winMessage = this.Players[i].Name + " has won!";
                }
                // condition 5
                else if
                  (this.Board[0] == this.Players[i] && this.Board[4] == this.Players[i] && this.Board[8] == this.Players[i])
                {
                    winMessage = this.Players[i].Name + " has won!";
                }
                // condition 6
                else if
                  (this.Board[2] == this.Players[i] && this.Board[4] == this.Players[i] && this.Board[6] == this.Players[i])
                {
                    winMessage = this.Players[i].Name + " has won!";
                }
                // condition 7
                else if
                  (this.Board[1] == this.Players[i] && this.Board[4] == this.Players[i] && this.Board[7] == this.Players[i])
                {
                    winMessage = this.Players[i].Name + " has won!";
                }
                // condition 8
                else if
                  (this.Board[3] == this.Players[i] && this.Board[4] == this.Players[i] && this.Board[5] == this.Players[i])
                {
                    winMessage = this.Players[i].Name + " has won!";
                }
                // all boardspaces used but no win = Draw
                else if (this.Board[0] != null && this.Board[1] != null && this.Board[2] != null &&
                        this.Board[3] != null && this.Board[4] != null && this.Board[5] != null &&
                        this.Board[6] != null && this.Board[7] != null && this.Board[8] != null)
                {
                    winMessage = "Draw";
                }
            }
            return winMessage;
        }

        public static int GenerateRandomGameID()
        {
            Random random = new Random();
            int result = random.Next(10000, 50000);
            return result;
        }
    }

}
