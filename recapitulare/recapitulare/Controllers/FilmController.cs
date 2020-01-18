using recapitulare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace recapitulare.Controllers
{
    public class FilmController : Controller
    {
        private RecenzieDBContext db = new RecenzieDBContext();

        // GET: Film
        public ActionResult Index()
        {
            var filme = from film in db.Filme
                        orderby film.Denumire
                        select film;
            ViewBag.Filme = filme;
            return View();
        }
    }
}