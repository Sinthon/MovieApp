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

        public ActionResult Details(int id)
        {
            var model = context.Movies.Find(id);
            return View(model);
        }

        public ActionResult Create()
        {
            var movie = new MovieModel();
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieModel movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Movies.Add(movie);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var model = context.Movies.Find(id);
            return RedirectToAction("Create",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
