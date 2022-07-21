using ProjeX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ProjeX.Controllers
{
    public class TicketController : Controller
    {
        
        public ActionResult Message(string filmid)
        {
            SinemaxEntities db = new SinemaxEntities();

            var customer = (Customer)Session["LoginInfo"];
            short FilmBiletId = short.Parse(filmid);
            string FilmPNR = db.BİLET.First(bilet => bilet.BiletId.Value.Equals(FilmBiletId)).Bilet;

            SmtpClient client = new SmtpClient("mail.sinemax.com");
            MailAddress fromAddress = new MailAddress("info@sinemax.com", "Sinemax");
            MailAddress toAddress = new MailAddress(customer.Email);
            MailMessage msg = new MailMessage(fromAddress, toAddress);
            msg.IsBodyHtml = true;
            msg.Subject = "Sinemax Biletiniz";
            msg.Body = "PNR Numaranız: " + "<strong>"+FilmPNR+ "</strong>";
            //client.Send(msg); //Mail sunucusu bulunmadığı için yorum satırı haline getirilmiştir.

            return View();
        }

    }
}