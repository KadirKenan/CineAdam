using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreRepository genreRepository;

        public GenreController(IGenreRepository _genreRepository)
        {
            genreRepository = _genreRepository;
        }


        public IActionResult Index()
        {
            return View(genreRepository.GetGenres());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Genre genre)
        {
            string result = genreRepository.PostGenre(genre);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            Genre genre = genreRepository.Find(id);
            return View(genre);
        }
        [HttpPost]
        public ActionResult Update(Genre genre)
        {
            string result = genreRepository.UpdateGenre(genre);
            TempData["result"] = result;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Genre genre)
        {
            return View(genre);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            string result = genreRepository.DeleteGenre(id);
            TempData["result"] = result;
            return RedirectToAction("Index");
        }
    }
}
