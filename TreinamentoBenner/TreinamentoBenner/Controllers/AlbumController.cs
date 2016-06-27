using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TreinamentoBenner.Core.Context;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBenner.Controllers
{
    [Authorize]
    public class AlbumController : BaseController
    {

        private LojaContext _db = new LojaContext();
        // GET: Album
        public ActionResult Index()
        {
            var albums = from album in _db.Albums
                orderby album.Titulo ascending
                select album;

            return View(albums);
        }

        public ActionResult Create(int id = 0)
        {
            var album = _db.Albums.Find(id) ?? new Album();

            Dropdown(album);
            return View(album);
        }

        private void Dropdown(Album album)
        {
            ViewBag.ArtistaId = new SelectList(_db.Artistas, "Id", "Nome", album?.ArtistaId);
            ViewBag.GeneroId = new SelectList(_db.Artistas, "Id", "Nome", album?.GeneroId);
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            //ModelState.AddModelError("Titulo", "Nome errado!!!");
            if (ModelState.IsValid)
            {
                _db.Albums.AddOrUpdate(album);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            Dropdown(album);

            return View(album);
        }

        public ActionResult Delete(int id)
        {
            var album = _db.Albums.Find(id);
            if (album == null)
                return HttpNotFound();

            _db.Albums.Remove(album);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}