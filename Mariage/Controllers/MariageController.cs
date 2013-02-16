using System.Collections.Generic;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Mariage.Models;

namespace Mariage.Controllers
{
    public class MariageController : Controller
    {
        public MariageController()
        {
            ViewBag.Private = Private;
            ViewBag.Menu = new Dictionary<string, string>
                {
                    {"Accueil", "Accueil"},
                    {"Media","Photos"},
                    {"Liste","Liste de mariage"},
                    {"Infos","Informations"},
                    {"Contact","Contact"}
                };
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Infos()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ConfirmMessage = "Votre message a bien été envoyé.";
                return View();
            }
            return View();
        }

        public ActionResult Invite()
        {
            return Private ? View() : View("Index");
        }

        [HttpPost]
        public ActionResult Invite(string password)
        {
            if (password.Trim().ToLower() == "gwenrann")
            {
                Session.Add("private", true);
                return RedirectToAction("Invite");
            }
            ModelState.AddModelError("password",
                "Le code d'accès invité saisi n'est pas correct, vous trouverez votre code d'accès sur votre faire-part d'invitation.");
            return View("Index");

        }

        public ActionResult Media()
        {
            return View();
        }

        public ActionResult Liste()
        {
            return View();
        }

        private bool Private
        {
            get
            {
                if (Session != null)
                    return (bool) (Session["private"] ?? false);
                return false;
            }
        }

    }
}
