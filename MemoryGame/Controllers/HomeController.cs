using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemoryGame.Models;

namespace MemoryGame.Controllers
{
    public class HomeController : Controller
    {

        public Game game = new Game();

        public ActionResult Index()
        {
            game.InitGame();
            return View(game.Board);
        }
    }
}