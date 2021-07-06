using Ft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ft.Controllers
{
    public class FitnessController : Controller
    {

        // GET: Fitness
        
        FMSEntities context = new FMSEntities();

        [Authorize]
        public ActionResult Index()
        {



            var ft = context.Fitnesses.ToList();
            return View(ft);



        }


        [Authorize]
        public ActionResult Create()
        {
            return View();



        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(Fitness s)
        {
            if (ModelState.IsValid)
            {
                context.Fitnesses.Add(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize]
        public ActionResult Edit(int Id)
        {



            var s = context.Fitnesses.FirstOrDefault(e => e.Id == Id);
            return View(s);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Fitness s)
        {
            if (ModelState.IsValid)
            {
                var old_value = context.Fitnesses.FirstOrDefault(e => e.Id == s.Id);
                context.Entry(old_value).CurrentValues.SetValues(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize]
        public ActionResult Details(int Id)
        {
            var s = context.Fitnesses.FirstOrDefault(e => e.Id == Id);
            return View(s);
        }
        [Authorize]
        public ActionResult Delete(int Id)
        {
            var s = context.Fitnesses.FirstOrDefault(e => e.Id == Id);
            return View(s);
        }
        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteP(int Id)
        {
            var Fitness_remove = context.Fitnesses.FirstOrDefault(e => e.Id == Id);
            context.Fitnesses.Remove(Fitness_remove);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}