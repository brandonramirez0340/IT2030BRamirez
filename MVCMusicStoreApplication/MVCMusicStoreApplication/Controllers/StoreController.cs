using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {
        MVCMusicStoreDB db = new MVCMusicStoreDB();

        public ActionResult Index(int? id)
        {
            var albumsByGenre = db.Albums.Where(a => a.GenreId == id);
            return View(albumsByGenre.ToList());
        }

        public ActionResult Browse()
        {
            return View(db.Genres.ToList());
        }

        public ActionResult Details(int? id)
        {
            Album album = db.Albums.Find(id);
            return View(album);
        }
    }
}