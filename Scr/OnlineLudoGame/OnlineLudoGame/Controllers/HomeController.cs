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
                Gameengine.CreateGame.MakeGame(PlayerID, player);
            }
           
            return View();
        }
        public ActionResult Game()
        {
            Gameengine.Player player1 = new Gameengine.Player
            {
                PlayerID = "test",
                Side = "O",
                Email = "test@test.se"
            };
            Gameengine.GameSession session1 = new Gameengine.GameSession
            {
                GameID = "1"
            };
            session1.Board[0] = player1;
            session1.Board[1] = player1;
            session1.Board[2] = player1;
            session1.Board[3] = player1;
            session1.Board[4] = player1;
            session1.Board[5] = player1;
            session1.Board[6] = player1;
            session1.Board[7] = player1;
            session1.Board[8] = player1;
            Gameengine.RunningGame.GamesInPlay.Add(session1);
            //int index = Gameengine.RunningGame.GamesInPlay.FindIndex(x => x.GameID == gameID);
            var board = new Board
            {
                Cell1 = Gameengine.RunningGame.GamesInPlay[0].Board[0].Side,
                Cell2 = Gameengine.RunningGame.GamesInPlay[0].Board[1].Side,
                Cell3 = Gameengine.RunningGame.GamesInPlay[0].Board[2].Side,
                Cell4 = Gameengine.RunningGame.GamesInPlay[0].Board[3].Side,
                Cell5 = Gameengine.RunningGame.GamesInPlay[0].Board[4].Side,
                Cell6 = Gameengine.RunningGame.GamesInPlay[0].Board[5].Side,
                Cell7 = Gameengine.RunningGame.GamesInPlay[0].Board[6].Side,
                Cell8 = Gameengine.RunningGame.GamesInPlay[0].Board[7].Side,
                Cell9 = Gameengine.RunningGame.GamesInPlay[0].Board[8].Side,
            };
            return View(board);
        }
               
       
    }
}