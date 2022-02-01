using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission04.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission04.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext theContext { get; set; }

        public HomeController(MovieContext someName)
        {
            theContext = someName;
        }

        public IActionResult Baconsale()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = theContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                theContext.Add(mr);
                theContext.SaveChanges();
                return View("Confirmation", mr);
            }
            else
            {
                ViewBag.Categories = theContext.Categories.ToList();
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = theContext.Categories.ToList();
            var movie = theContext.Responses.Single(x => x.MovieId == movieid);
            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieResponse mr)
        {
            theContext.Responses.Update(mr);
            theContext.SaveChanges();
            return RedirectToAction("MyMovies");
        }
        
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = theContext.Responses.Single(x => x.MovieId == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            theContext.Responses.Remove(mr);
            theContext.SaveChanges();
            return RedirectToAction("MyMovies");
        }

        public IActionResult MyMovies()
        {
            //ViewBag.Categories = theContext.Categories.ToList();
            var movie = theContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.title)
                .ToList();
            return View(movie);

        }


    }
}
