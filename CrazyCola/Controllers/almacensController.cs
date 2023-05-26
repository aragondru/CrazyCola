using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrazyCola;

namespace CrazyCola.Controllers
{
    public class almacensController : Controller
    {
        private crazycolaEntities db = new crazycolaEntities();

        // GET: almacens
        public ActionResult Index()
        {
            var almacen = db.almacen.Include(a => a.ciudad);
            return View(almacen.ToList());
        }

        // GET: almacens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            almacen almacen = db.almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // GET: almacens/Create
        public ActionResult Create()
        {
            ViewBag.ciudad_id = new SelectList(db.ciudad, "ciudad_id", "nombre");
            return View();
        }

        // POST: almacens/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "almacen_id,nombre,direccion,ciudad_id")] almacen almacen)
        {
            if (ModelState.IsValid)
            {
                db.almacen.Add(almacen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ciudad_id = new SelectList(db.ciudad, "ciudad_id", "nombre", almacen.ciudad_id);
            return View(almacen);
        }

        // GET: almacens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            almacen almacen = db.almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            ViewBag.ciudad_id = new SelectList(db.ciudad, "ciudad_id", "nombre", almacen.ciudad_id);
            return View(almacen);
        }

        // POST: almacens/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "almacen_id,nombre,direccion,ciudad_id")] almacen almacen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ciudad_id = new SelectList(db.ciudad, "ciudad_id", "nombre", almacen.ciudad_id);
            return View(almacen);
        }

        // GET: almacens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            almacen almacen = db.almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // POST: almacens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            almacen almacen = db.almacen.Find(id);
            db.almacen.Remove(almacen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
