
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
        public bool IsActive { get; set; }

        //Method for Switching active player.
        public void Turn(string cookieValue, string buttonClick)
        {
            if (this.FirstPlayerTurn == true)
            {
                var session = Gameengine.ActiveGame.Game.FindIndex(x => x.Players[0].PlayerID == cookieValue);
                if (cookieValue == this.Players[0].PlayerID)
                {
                    var player1 = this.Players[0];
                    int indexPressed = int.Parse(buttonClick);
                    if (this.Board[indexPressed].Side == "-")
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
                    if (this.Board[indexPressed].Side == "-")
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

        //Method that writes GameBoard state to view.
        public string[] WriteBoard()
        {
            string[] cell = new string[9];
            for (int i = 0; i < 9; i++)
            {
                try
                {
                    if (this.Board[i].Side != "-")
                    {
                        cell[i] = this.Board[i].Side;
                    }
                    else if (this.Board[i].Side == "-")
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

        //Method that checks if winning conditions are met.
        public string WinConditions()
        {
            string winner = "";
            winner = CheckPattern(0, 1, 2);
            winner = CheckPattern(3, 4, 5);
            winner = CheckPattern(6, 7, 8);
            winner = CheckPattern(0, 3, 6);
            winner = CheckPattern(1, 4, 7);
            winner = CheckPattern(2, 5, 8);
            winner = CheckPattern(0, 4, 8);
            winner = CheckPattern(2, 4, 6);
            return winner;
            
            //else if (!this.Board[0].Side.Equals("-") && !this.Board[1].Side.Equals("-") && !this.Board[2].Side.Equals("-") &&
            //    !this.Board[3].Side.Equals("-") && !this.Board[4].Side.Equals("-") && !this.Board[5].Side.Equals("-") &&
            //    !this.Board[6].Side.Equals("-") && !this.Board[7].Side.Equals("-"))
            //{
            //    test = "IT'S A DRAW";
            //    this.IsActive = false;
            //}
            //if (test == " WON THE GAME!")
            //{
            //    test = "";
            //}
            //else
            //{
            //    this.IsActive = false;
            //}
            //return test;
        }
        public string CheckPattern(int one, int two, int three)
        {
            string winnerSide = "";
            if (this.Board[one].Side.Equals(this.Board[two].Side) && this.Board[one].Side.Equals(this.Board[three].Side))
            {
                winnerSide = this.Board[one].Name;
                this.IsActive = false;
            }
            return winnerSide;
        }

        //Method that generates random GameID
        public static int GenerateRandomGameID()
        {
            Random random = new Random();
            int result = random.Next(10000, 50000);
            return result;
        }
    }
}
