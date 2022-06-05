using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieContext context;

        public MovieController(MovieContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = context.Movies.ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = context.Movies.Find(id);
            return View(model);
        }

        public IActionResult Create()
        {
            var movie = new MovieModel();
            return View("Form", movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieModel movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(movie.Id == 0)
                        context.Movies.Add(movie);
                    else
                        context.Movies.Update(movie);
                    
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction("Form", movie);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            MovieModel model = context.Movies.Find(id);
            return View("Form", model);
        }

        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var movie = context.Movies.Find(id);
                context.Movies.Remove(movie);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
