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

        // GET: Home        
        //public ActionResult LudoBoard()
        //{
        //    return View();
        //}
        //public ActionResult Test(string testname)
        //{
        //    var currentPlayer = Session["player"];
        //    ViewBag.x = Gameengine.angelic.text(testname); //testname har värdet på vilken ruta som klickats.
        //    ViewBag.O = Gameengine.martin.cirkel();
        //    return View();
        //}
        public ActionResult StartPage(string startgamebtn, string joingamebtn, string email)
        {
            if (Request.Cookies["GameSession"] == null)
            {
                HttpCookie cookie = new HttpCookie("GameSession");
                Guid guid = Guid.NewGuid();
                cookie.Value = guid.ToString();
                cookie.Expires = DateTime.Now.AddDays(2);
                cookie.Path = "";
                Response.SetCookie(cookie);
             
            }
            if(startgamebtn == "Start a game")
            {
                Player player = new Player
                {
                    PlayerID = Request.Cookies["GameSession"].Value,
                    Side = "O",
                    Email = email
                };
                Gameengine.CreateGame.MakeGame(1, player);
            }
           
            return View();
        }
        public ActionResult Game(string testname, int gameID)
        {
            var testName = testname;
            Gameengine.Player player1 = new Gameengine.Player
            {
                PlayerID = "test",
                Side = "O",
                Email = "test@test.se"
            };
            Gameengine.Player player2 = new Gameengine.Player
            {
                PlayerID = "test2",
                Side = "X",
                Email = "test@test.se"
            };
            Gameengine.GameSession session1 = new Gameengine.GameSession
            {
                GameID = 1
            };
            session1.Board[0] = player2;
            session1.Board[1] = player1;
            session1.Board[2] = player1;
            session1.Board[3] = player1;
            session1.Board[4] = player2;
            session1.Board[5] = player1;
            session1.Board[6] = player1;
            session1.Board[7] = player1;
            session1.Board[8] = player2;
            Gameengine.RunningGame.GamesInPlay.Add(session1);
            int index = Gameengine.RunningGame.GamesInPlay.FindIndex(x => x.GameID == gameID);
            string[] side = new string[9];
            for (int i = 0; i < 9; i++)
            {
                try
                {
                if (Gameengine.RunningGame.GamesInPlay[0].Board[i].Side != null)
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