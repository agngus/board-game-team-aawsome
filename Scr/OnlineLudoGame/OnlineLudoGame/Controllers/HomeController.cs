﻿using Gameengine;
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
        public ActionResult StartPage()
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
            return View();
        }
        public ActionResult LoginUser(FormCollection collection, string startbtn, string joinbtn)
        {
            if (startbtn == "Start a game")
            {
                Gameengine.Player player1 = new Gameengine.Player
                {
                    Name = collection["nameInput"],
                    PlayerID = Request.Cookies["User"].Value,
                    Side = "O",
                    Email = collection["emailInput"]
                };
                GameID = Gameengine.GameSession.GenerateRandomGameID();
                Gameengine.StartGame.MakeGame(GameID, player1);
            }
            if (joinbtn == "Join an existing game")
            {
                Gameengine.Player player2 = new Gameengine.Player
                {
                    Name = collection["nameInput"],
                    PlayerID = Request.Cookies["User"].Value,
                    Side = "X",
                    Email = collection["emailInput"]
                };
                Gameengine.StartGame.FindGame(player2);
            }
            return RedirectToAction("Game");
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
                GameID = GameID,
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