
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
                    if (this.Board[indexPressed] == null)
                    {
                        this.Board[indexPressed] = player1;
                        this.FirstPlayerTurn = false;
                    }
                    else
                    {
                        this.FirstPlayerTurn = true;
                    }
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
                    if (this.Board[indexPressed] == null)
                    {
                        this.Board[indexPressed] = player2;
                        this.FirstPlayerTurn = true;
                    }
                    else
                    {
                        this.FirstPlayerTurn = false;
                    }
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
            string test = "";
            try
            {
                if (this.Board[0] == this.Players[0])
                {
                    test = this.Players[0].Name;
                }
            }
            catch
            {
                test = "";
            }
            return test;
        }

        public static int GenerateRandomGameID()
        {
            Random random = new Random();
            int result = random.Next(10000, 50000);
            return result;
        }
    }

}
