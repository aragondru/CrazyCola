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
    public class almacen_productoController : Controller
    {
        private crazycolaEntities db = new crazycolaEntities();

        // GET: almacen_producto
        public ActionResult Index()
        {
            var almacen_producto = db.almacen_producto.Include(a => a.almacen).Include(a => a.producto);
            return View(almacen_producto.ToList());
        }

        // GET: almacen_producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            almacen_producto almacen_producto = db.almacen_producto.Find(id);
            if (almacen_producto == null)
            {
                return HttpNotFound();
            }
            return View(almacen_producto);
        }

        // GET: almacen_producto/Create
        public ActionResult Create()
        {
            ViewBag.almacen_id = new SelectList(db.almacen, "almacen_id", "nombre");
            ViewBag.producto_id = new SelectList(db.producto, "producto_id", "nombre");
            return View();
        }

        // POST: almacen_producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "almacen_id,producto_id,cantidad")] almacen_producto almacen_producto)
        {
            if (ModelState.IsValid)
            {
                db.almacen_producto.Add(almacen_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.almacen_id = new SelectList(db.almacen, "almacen_id", "nombre", almacen_producto.almacen_id);
            ViewBag.producto_id = new SelectList(db.producto, "producto_id", "nombre", almacen_producto.producto_id);
            return View(almacen_producto);
        }

        // GET: almacen_producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            almacen_producto almacen_producto = db.almacen_producto.Find(id);
            if (almacen_producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.almacen_id = new SelectList(db.almacen, "almacen_id", "nombre", almacen_producto.almacen_id);
            ViewBag.producto_id = new SelectList(db.producto, "producto_id", "nombre", almacen_producto.producto_id);
            return View(almacen_producto);
        }

        // POST: almacen_producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "almacen_id,producto_id,cantidad")] almacen_producto almacen_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacen_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.almacen_id = new SelectList(db.almacen, "almacen_id", "nombre", almacen_producto.almacen_id);
            ViewBag.producto_id = new SelectList(db.producto, "producto_id", "nombre", almacen_producto.producto_id);
            return View(almacen_producto);
        }

        // GET: almacen_producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            almacen_producto almacen_producto = db.almacen_producto.Find(id);
            if (almacen_producto == null)
            {
                return HttpNotFound();
            }
            return View(almacen_producto);
        }

        // POST: almacen_producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            almacen_producto almacen_producto = db.almacen_producto.Find(id);
            db.almacen_producto.Remove(almacen_producto);
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
