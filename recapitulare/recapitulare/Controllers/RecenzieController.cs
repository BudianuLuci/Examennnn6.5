using recapitulare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace recapitulare.Controllers
{
    public class RecenzieController : Controller
    {
        private RecenzieDBContext db = new RecenzieDBContext();
        // GET: Recenzie
        public ActionResult AfisareRecenzii()
        {
            var recenzii = from recenzie in db.Recenzii
                           orderby recenzie.Nota
                           select recenzie;
            ViewBag.Recenzii = recenzii;
            return View();
        }

        public ActionResult Show(int id)
        {
            Recenzie recenzie = db.Recenzii.Find(id);
            ViewBag.Recenzie = recenzie;
            ViewBag.Film = recenzie.Film;

            return View();

        }

        public ActionResult New()
        {
            var filme = from fil in db.Filme select fil;
            ViewBag.Filme = filme;
            return View();
        }

        [HttpPost]
        public ActionResult New(Recenzie recenzie)
        {
            try
            {
                db.Recenzii.Add(recenzie);
                db.SaveChanges();
                TempData["message"] = "Articolul a fost adaugat!";
                return RedirectToAction("AfisareRecenzii");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Recenzie recenzie = db.Recenzii.Find(id);
            db.Recenzii.Remove(recenzie);
            db.SaveChanges();
            TempData["message"] = "Articolul a fost sters!";
            return RedirectToAction("AfisareRecenzii");
        }

        public ActionResult Edit(int id)
        {
           Recenzie recenzie = db.Recenzii.Find(id);
            ViewBag.Recenzie = recenzie;
            ViewBag.Film = recenzie.Film;
            var filme = from fil in db.Filme select fil;
            ViewBag.Filme = filme;

            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Recenzie requestrec)
        {
            try
            {
                Recenzie recenzie = db.Recenzii.Find(id);
                if (TryUpdateModel(recenzie))
                {
                    recenzie.Titlu = requestrec.Titlu;
                    recenzie.Descriere = requestrec.Descriere;
                    recenzie.Nota = requestrec.Nota;
                    recenzie.NumeUtilizator = requestrec.NumeUtilizator;
                    recenzie.IDFilm = requestrec.IDFilm;
                    db.SaveChanges();
                }
                return RedirectToAction("AfisareRecenzii");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}