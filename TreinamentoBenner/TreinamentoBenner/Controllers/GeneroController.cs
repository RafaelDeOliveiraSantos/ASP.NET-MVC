using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoBenner.Core.Context;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBenner.Controllers
{
    public class GeneroController : Controller
    {
        private LojaContext _db = new LojaContext();

        public ActionResult PartialView(int id)
        {
            return PartialView(_db.Generos.Find(id));
        }
    }
}