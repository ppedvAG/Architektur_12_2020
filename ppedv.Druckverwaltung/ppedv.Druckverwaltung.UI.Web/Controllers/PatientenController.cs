using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Druckverwaltung.Logic;
using ppedv.Druckverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ppedv.Druckverwaltung.UI.Web.Controllers
{
    public class PatientenController : Controller
    {
        Core core = new Core();

        // GET: PatientenController
        public ActionResult Index()
        {
            return View(core.Repository.GetAll<Patient>());
        }

        // GET: PatientenController/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Repository.GetById<Patient>(id));
        }

        // GET: PatientenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient p)
        {
            try
            {
                core.Repository.Add<Patient>(p);
                core.Repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.Repository.GetById<Patient>(id));
        }

        // POST: PatientenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Patient p)
        {
            try
            {
                core.Repository.Update<Patient>(p);
                core.Repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.Repository.GetById<Patient>(id));
        }

        // POST: PatientenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var p = core.Repository.GetById<Patient>(id);
                if(p!=null)
                {
                    core.Repository.Delete<Patient>(p);
                    core.Repository.Save();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
