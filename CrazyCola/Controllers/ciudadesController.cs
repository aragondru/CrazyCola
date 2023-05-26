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
    public class ciudadesController : Controller
    {
        private crazycolaEntities db = new crazycolaEntities();

        // GET: ciudades
        public ActionResult Index()
        {
            var ciudad = db.ciudad.Include(c => c.pais);
            return View(ciudad.ToList());
        }

        // GET: ciudades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: ciudades/Create
        public ActionResult Create()
        {
            ViewBag.pais_id = new SelectList(db.pais, "pais_id", "nombre");
            return View();
        }

        // POST: ciudades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ciudad_id,nombre,pais_id")] ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.ciudad.Add(ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pais_id = new SelectList(db.pais, "pais_id", "nombre", ciudad.pais_id);
            return View(ciudad);
        }

        // GET: ciudades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.pais_id = new SelectList(db.pais, "pais_id", "nombre", ciudad.pais_id);
            return View(ciudad);
        }

        // POST: ciudades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ciudad_id,nombre,pais_id")] ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pais_id = new SelectList(db.pais, "pais_id", "nombre", ciudad.pais_id);
            return View(ciudad);
        }

        // GET: ciudades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ciudad ciudad = db.ciudad.Find(id);
            db.ciudad.Remove(ciudad);
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
