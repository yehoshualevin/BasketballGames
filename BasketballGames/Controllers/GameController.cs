using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BasketballGames.Data;
using BasketballGames.Models;

namespace BasketballGames.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMember(Member member)
        {
            var repo = new BasketballRepository();
            repo.AddMember(member);
            return View("Confirmation", new Words { Word = "future emails" });
        }
        
        public ActionResult AddPlayer()
        {
            var repo = new BasketballRepository();
            var players = repo.GetPlayersByGame();
            IEnumerable<GamesAndPlayers>  gaps = players.Select(p => new GamesAndPlayers
            { 
                    Id = p.Id,
                    Date = p.Date,
                    MaxPlayers = p.MaxPeople,
                    Players = p.Players
             });            
            return View(gaps);
        }

        [HttpPost]
        public ActionResult AddPlayer(Player player)
        {
            var repo = new BasketballRepository();
            repo.AddPlayer(player);
            return View("Confirmation", new Words { Word = "this game" });
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string password)
        {
            if(password != "{9fqhv%mvjCV,Xk8")
            {
                return RedirectToAction("login");
            }
            FormsAuthentication.SetAuthCookie("hello",false);
            return RedirectToAction("addgame","admin");
        }
    }
}