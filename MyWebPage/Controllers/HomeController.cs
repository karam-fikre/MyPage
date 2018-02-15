using MyWebPage.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyWebPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SendEmail(ContactModel contactModel)
        {
            if (ModelState.IsValid) { 
            var client = new SendGridClient("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");
            var from = new EmailAddress(contactModel.Email, contactModel.UserName);
            var subject = contactModel.Subject;
            var to = new EmailAddress("shadow.walker@list.ru", "Shadow");
            var plainTextContent = contactModel.Message;
            var htmlContent = "<strong>"+contactModel.Message+"</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return View("Index");
            }
            return View("Index");
        
    }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}