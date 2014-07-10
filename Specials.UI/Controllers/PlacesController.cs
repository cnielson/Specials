using AutoMapper;
using Specials.DAL;
using Specials.DAL.Models;
using Specials.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Specials.UI.Controllers
{
    public class PlacesController : Controller
    {
        //
        // GET: /Place/
        public ActionResult Index()
        {
            return View("Places");
        }

        //
        // GET: /Place/Details/5
        public ActionResult Details(int id)
        {
            using (var context = new SpecialsContext())
            {
                var place = context.Places.FirstOrDefault(p => p.PlaceId == id);
                if (place == null)
                {
                    var error = string.Format("no place with id = {0}", id);
                    return RedirectToAction("Error", "Home", new { msg = error });
                }

                var placeVm = Mapper.Map<Place, PlaceVM>(place);
                return View("PlaceDetails", placeVm);
            }
        }

        //
        // GET: /Place/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Place/Create
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
        // GET: /Place/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Place/Edit/5
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
        // GET: /Place/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Place/Delete/5
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
