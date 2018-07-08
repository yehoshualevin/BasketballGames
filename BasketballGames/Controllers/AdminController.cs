using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BasketballGames.Data;
using BasketballGames.Models;

namespace BasketballGames.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGame(Game game)
        {
            var repo = new BasketballRepository();
            repo.AddGame(game);
            var members = repo.GetMembers();
            foreach(Member m in members)
            {
                SendEmail(m);
            }
            return View("Confirmation");
        }
        private void SendEmail(Member m)
        {
            var fromAddress = new MailAddress("yehoshualevin22@gmail.com", "Basketball App");
            var toAddress = new MailAddress(m.Email, m.Name);

            string fromPassword = "<divclassrow>";
            string subject = "New Game Posted!";
            string body = $"Hey {m.Name}, a new game has been posted, sign up now to secure a spot!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}