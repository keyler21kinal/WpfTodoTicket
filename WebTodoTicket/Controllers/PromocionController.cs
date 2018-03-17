using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTodoTicket.Models;

namespace WebTodoTicket.Controllers
{
    public class PromocionController : Controller
    {
        private TodoTicket1Context1 db = new TodoTicket1Context1();

        // GET: Promocion
        public ActionResult Index()
        {
            var promocion = db.Promocion.Include(p => p.evento).Include(p => p.Usuario);
            return View(promocion.ToList());
        }

        // GET: Promocion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocion promocion = db.Promocion.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        // GET: Promocion/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre");
            return View();
        }

        // POST: Promocion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PromocionId,Descripcion,EventoId,UsuarioId")] Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["idUsuario"]);
                var usuario = db.Usuario.FirstOrDefault(u => u.UsuarioId == id);
                promocion.Usuario = usuario;
                db.Promocion.Add(promocion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre", promocion.EventoId);
            return View(promocion);
        }

        // GET: Promocion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocion promocion = db.Promocion.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre", promocion.EventoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Nombre", promocion.UsuarioId);
            return View(promocion);
        }

        // POST: Promocion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PromocionId,Descripcion,EventoId,UsuarioId")] Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promocion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre", promocion.EventoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Nombre", promocion.UsuarioId);
            return View(promocion);
        }

        // GET: Promocion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocion promocion = db.Promocion.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        // POST: Promocion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promocion promocion = db.Promocion.Find(id);
            db.Promocion.Remove(promocion);
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
