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
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult StartPage()
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
            if (Request.Cookies["GameSession"] == null)
            {
                HttpCookie cookie = new HttpCookie("GameSession");
                Guid guid = Guid.NewGuid();
                cookie.Value = guid.ToString();
                cookie.Expires = DateTime.Now.AddDays(2);
                cookie.Path = "";
                Response.SetCookie(cookie);
            } return View();
        }
       
        public ActionResult StartPage3()
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
                return View();
        }
        [HttpPost]
        public ActionResult GetTheForm(FormCollection theForm)
        {
            string name = theForm["textBox1"];
           string email = theForm["email"];
            string color = theForm["preferred_color"];
            
            StartGame();
            return View();
        }
        [Route("LudoBoard /{id}")]
        public ActionResult StartGame()
        {
            string id = "sonny";

            return View();
        }

    }
}