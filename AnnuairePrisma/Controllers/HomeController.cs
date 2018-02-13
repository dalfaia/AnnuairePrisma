using AnnuairePrisma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnnuairePrisma.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        public async Task<ActionResult> RechercherSocietesOuContacts(string recherche)
        {
            if (string.IsNullOrEmpty(recherche))
                return PartialView("_ResultatsView", null);

            List<ResultatRechercheSocieteContact> resultats = new List<ResultatRechercheSocieteContact>();

            List<ResultatRechercheSocieteContact> resultatsSocietes = db.Societe.Where(s => s.nom.Contains(recherche) || s.raisonSociale.Contains(recherche)).ToList().Select(s => new ResultatRechercheSocieteContact(s)).ToList();
            List<ResultatRechercheSocieteContact> resultatsContacts = db.Contact.Where(s => s.nom.Contains(recherche) || s.prenom.Contains(recherche)).ToList().Select(c => new ResultatRechercheSocieteContact(c)).ToList();
            
            resultats.AddRange(resultatsSocietes);
            resultats.AddRange(resultatsContacts);

            return PartialView("_ResultatsView", resultats);
        }

    }
}