using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Specials.DAL.Models;
using Specials.DAL;
using AutoMapper;
using Specials.UI.Models;
using System.Collections.Generic;

namespace Specials.UI.Controllers
{
    public class SpecialsController : Controller
    {
        //
        // GET: /Specials/
        public ActionResult Index()
        {
            using (var context = new Specials.DAL.SpecialsContext())
            {
                
                var s = context.Specials.ToList(); //todo: convert this to VM
                var specialVms = Mapper.Map<List<Special>, List<SpecialVM>>(s);
                
                return View(specialVms);
            }
        }

        //
        // GET: /Specials/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Specials/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Specials/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Specials/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Specials/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Specials/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Specials/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
