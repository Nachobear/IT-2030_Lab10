
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab10.Models;
using Microsoft.AspNetCore.Http;

namespace Lab10.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            GameSession session = new GameSession(HttpContext.Session);
            Game game = session.GetGame();
            session.SetGame(game);
            return View(game);
        }

        [HttpPost]
        public RedirectToActionResult NewGame()
        {
            GameSession session = new GameSession(HttpContext.Session);
            Game game = session.GetGame();

            game.NewGame();
            session.SetGame(game);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult HandleClickOnSquare(int id)
        {
           
            GameSession session = new GameSession(HttpContext.Session);
            Game game = session.GetGame();
            if ((game.BoxValues[id] != "") || (game.IsGameOver))
            {
                return RedirectToAction("Index");
            }
            game.UpdateSquare(id);
            game.DetermineIfGameIsWon();
            if (!game.IsGameOver) { game.ChangePlayer(); }
            session.SetGame(game);

            return RedirectToAction("Index");
        }

    }
}
