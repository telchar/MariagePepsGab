using System.Web.Mvc;
using Mariage.Models;

namespace Mariage.Controllers
{
    public class MariageController : Controller
    {
        private readonly BaseModel _model;
        public MariageController()
        {
            _model = new BaseModel();
        }

        public ActionResult EnCoursDeDeveloppement()
        {
            return View(_model);
        }
        public ActionResult Index()
        {
            _model.Selected = "Accueil";
            return View(_model);
        }
        public ActionResult Infos()
        {
            _model.Selected = "Infos";
            return View(_model);
        }
        public ActionResult Contact()
        {
            var model = new ContactModel
                {
                    Selected = "Contact"
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contactModel)
        {
            contactModel.Selected = "Contact";
            if (contactModel.Files != null)
            {
                if (contactModel.Files.ContentLength > 20971520)
                    ModelState.AddModelError("Files",
                                             "La pièce jointe est trop volumineuse (20mo maximum), pour les gros fichiers prenez contact avec nous pour que nous vous convenions d'un autre mode de transfert.");
            }
            if (ModelState.IsValid)
            {
                Email.Send(contactModel.Email, contactModel.Sujet, contactModel.Message, contactModel.Files);
                contactModel.ConfirmMessage = "Votre message a bien été envoyé.";
                return View(contactModel);
            }
            return View(contactModel);
        }


        [HttpPost]
        public ActionResult PrivateForm(string password)
        {
            if (password.Trim().ToLower() == "gwenrann")
            {
                Session.Add("private", true);
                return RedirectToAction("Infos");
            }
            _model.Selected = "Accueil";
            ModelState.AddModelError("password",
                "Le code d'accès invité saisi n'est pas correct, vous trouverez votre code d'accès sur votre faire-part d'invitation.");
            return View("Index", _model);

        }

        public ActionResult Media()
        {
            _model.Selected = "Media";
            return View(_model);
        }

        public ActionResult Liste()
        {
            _model.Selected = "Liste";
            return View(_model);
        }

        public ActionResult Logements()
        {
            if (BaseModel.Private)
            {
                _model.Selected = "Logements";
                return View(_model);
            }
            return RedirectToAction("Index");
        }
    }

    }
