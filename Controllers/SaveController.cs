using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SaveController : Controller
    {
        // GET: Save
        public ActionResult Index()
        {
            var strInput = HttpContext.Request.Cookies["Domain"];
            var items = strInput.Split(',');
            var depth = int.Parse(items[1]);
            var input = new Input(items[0], depth);
            var saveVC = new SaveVC(input, new List<Html>());
            saveVC.Parse();
            return View(saveVC);
        }

        // GET: Save/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Save/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Save/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Save/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Save/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Save/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Save/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}