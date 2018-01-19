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
            var newPlayer = new Player();
            return View();
        }
        public ActionResult StartPage2()
        {
            return View();
        }
    }
}