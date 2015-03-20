using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Areas.Escuela1.Controllers
{
    public class AlumnosController : Controller
    {
        private EscuelaDBEntities2 db = new EscuelaDBEntities2();

        //
        // GET: /Escuela1/Alumnos/

        public ActionResult Index()
        {
            return View(db.tb_Alumno.ToList());
        }

        //
        // GET: /Escuela1/Alumnos/Details/5

        public ActionResult Details(int id = 0)
        {
            tb_Alumno tb_alumno = db.tb_Alumno.Find(id);
            if (tb_alumno == null)
            {
                return HttpNotFound();
            }
            return View(tb_alumno);
        }

        //
        // GET: /Escuela1/Alumnos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Escuela1/Alumnos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tb_Alumno tb_alumno)
        {
            if (ModelState.IsValid)
            {
                db.tb_Alumno.Add(tb_alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_alumno);
        }

        //
        // GET: /Escuela1/Alumnos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tb_Alumno tb_alumno = db.tb_Alumno.Find(id);
            if (tb_alumno == null)
            {
                return HttpNotFound();
            }
            return View(tb_alumno);
        }

        //
        // POST: /Escuela1/Alumnos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_Alumno tb_alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_alumno);
        }

        //
        // GET: /Escuela1/Alumnos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tb_Alumno tb_alumno = db.tb_Alumno.Find(id);
            if (tb_alumno == null)
            {
                return HttpNotFound();
            }
            return View(tb_alumno);
        }

        //
        // POST: /Escuela1/Alumnos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Alumno tb_alumno = db.tb_Alumno.Find(id);
            db.tb_Alumno.Remove(tb_alumno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}