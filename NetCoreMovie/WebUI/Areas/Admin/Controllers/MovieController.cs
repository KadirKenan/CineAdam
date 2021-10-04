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
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository _movieRepository)
        {
            movieRepository = _movieRepository;
        }


        public IActionResult Index()
        {
            return View(movieRepository.GetMovies());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            string result = movieRepository.PostMovie(movie);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            Movie movie = movieRepository.Find(id);
            return View(movie);
        }
        [HttpPost]
        public ActionResult Update(Movie movie)
        {
            string result = movieRepository.UpdateMovie(movie);
            TempData["result"] = result;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Movie movie)
        {
            return View(movie);        
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
        
                string result = movieRepository.DeleteMovie(id);
                TempData["result"] = result;
                return RedirectToAction("Index");          
        }

    }
}
