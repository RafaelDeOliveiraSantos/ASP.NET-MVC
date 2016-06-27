using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoBenner.Core.Context;

namespace TreinamentoBenner.Controllers
{
    public class ArtistaController : Controller
    {
        //private readonly LojaContext _db = new LojaContext();

        // GET: Artista
        //public ActionResult Index()
        //{
        //    return View(_db.Artistas);
        //}

        public ActionResult Index()
        {
            return View();
        }
    }
}