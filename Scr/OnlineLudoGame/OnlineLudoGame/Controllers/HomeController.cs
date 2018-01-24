using Gameengine;
using OnlineLudoGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineLudoGame.Controllers
{
    public class HomeController : Controller
    {
        public string PlayerID { get; private set; }
        public static int GameID { get; set; }

        // GET: Home        
        public ActionResult StartPage(string startgamebtn, string joingamebtn, string email, string name)
        {
            if (Request.Cookies["User"] == null)
            {
                HttpCookie cookie = new HttpCookie("User");
                Guid guid = Guid.NewGuid();
                cookie.Value = guid.ToString();
                cookie.Expires = DateTime.Now.AddDays(2);
                cookie.Path = "";
                Response.SetCookie(cookie);
            }
            if (startgamebtn == "Start a game")
            {
                Player player1 = new Player
                {
                    Name = name,
                    PlayerID = Request.Cookies["User"].Value,
                    Side = "O",
                    Email = email
                };
                GameID = Gameengine.GameSession.GenerateRandomGameID();
                Gameengine.StartGame.MakeGame(GameID, player1);
                //Html.ActionLink("Go to game", "Game/" + gameID);
            }
            if (joingamebtn == "Join a game")
            {
                Player player2 = new Player
                {
                    PlayerID = Request.Cookies["User"].Value,
                    Side = "X",
                    Email = email
                };
                Gameengine.StartGame.FindGame(player2);
            }
            return View();
        }

        public ActionResult Game(GameSession gamesession, string testname)
        {
            int gameID = gamesession.GameID;
            var testName = testname;

            int index = Gameengine.RunningGame.GamesInPlay.FindIndex(x => x.GameID == gameID);
            string[] side = new string[9];
            for (int i = 0; i < 9; i++)
            {
                try
                {
                    if (Gameengine.RunningGame.GamesInPlay[index].Board[i].Side != null)
                    {
                        side[i] = Gameengine.RunningGame.GamesInPlay[0].Board[i].Side;
                    }
                }
                catch
                {
                    side[i] = "";
                }
            }
            var board = new Board
            {
                // GameID = RunningGame.GamesInPlay[index].GameID,
                Cell1 = side[0],
                Cell2 = side[1],
                Cell3 = side[2],
                Cell4 = side[3],
                Cell5 = side[4],
                Cell6 = side[5],
                Cell7 = side[6],
                Cell8 = side[7],
                Cell9 = side[8]
            };
            return View(board);
        }
    }
}