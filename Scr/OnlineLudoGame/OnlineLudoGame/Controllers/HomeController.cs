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
        // GET: Home        
        public ActionResult LudoBoard()
        {
            return View();
        }
        public ActionResult StartPage()
        {
            if (Request.Cookies["GameSession"] == null ) 
            {
            HttpCookie cookie = new HttpCookie("GameSession");
            Guid guid = Guid.NewGuid();
            cookie.Value = guid.ToString();
            cookie.Expires = DateTime.Now.AddDays(2);
            cookie.Path = "";
            Response.SetCookie(cookie);
            }            
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var newPlayer = new Player();
            //Player player = new Player
            //{
            //    PlayerID = Request.Cookies["GameSession"].Value,
            //    Name = newPlayer.Name,
            //    Email = newPlayer.Email
            //};            
            return View();
        }
        public ActionResult StartPage2()
        {
            return View();
        }
    }
}