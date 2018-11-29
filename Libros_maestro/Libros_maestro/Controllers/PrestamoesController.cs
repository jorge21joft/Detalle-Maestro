using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libros_maestro.Models;

namespace Libros_maestro.Controllers
{
    public class PrestamoesController : Controller
    {
        private Model1 db = new Model1();
        public static List<DetallePrestamo> aux = new List<DetallePrestamo>();

        // GET: Prestamoes
        public ActionResult Index()
        {
            return View(db.Prestamo.ToList());
        }

        public ActionResult detallesPrestamo(int? id)
        {
            var l = from lista in db.DetallePrestamo.ToList()
                    where lista.prestamo_id == id
                    select lista;

            return PartialView(l);
        }

        [HttpPost]
        public ActionResult DetallesVentaAgregar(int? cantidad, int? idLibro, string titulo, string genero)
        {
            Libros_maestro.Models.DetallePrestamo daux = new DetallePrestamo();
            daux.Libros = db.Libros.Find(idLibro);
            daux.libro_id = idLibro;

            daux.cantidad = cantidad;
     
            aux.Add(daux);

            ViewBag.listaDetalles = aux;
            return PartialView();
        }


        // GET: Prestamoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: Prestamoes/Create
        public ActionResult Create()
        {

            ViewBag.libros = db.Libros.ToList();
            ViewBag.detalles = aux;

            return View();
        }

        // POST: Prestamoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_prestamo,fecha_prestamo,fecha_devolucion")] Prestamo prestamo)
        {


            foreach (var item in aux)
            {
                // item.idVenta = ventas.id;

                prestamo.DetallePrestamo.Add(new Models.DetallePrestamo
                {
                    
                    cantidad = item.cantidad,
                    libro_id = item.Libros.id_libro,
                    prestamo_id = prestamo.id_prestamo,
                   
                });

              
            }

            if (ModelState.IsValid)
            {
                db.Prestamo.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prestamo);
        }

        // GET: Prestamoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_prestamo,fecha_prestamo,fecha_devolucion")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prestamo);
        }

        // GET: Prestamoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo prestamo = db.Prestamo.Find(id);
            db.Prestamo.Remove(prestamo);
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
