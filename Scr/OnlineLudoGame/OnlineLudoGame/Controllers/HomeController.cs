using OnlineLudoGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gameengine;

namespace OnlineLudoGame.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LudoBoard()
        {
            return View();
        }
        public ActionResult StartPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var newPlayer = new OnlineLudoGame.Models.Player();
            Temp.Players.Add(newPlayer);

            return View();
        }
        public ActionResult StartPage2()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult GetTheForm(FormCollection theForm)
        {
            string a = theForm["textBox1"];
            return View();
        }
        public ActionResult StartPage3()
        {

            return View();
        }

    }
}