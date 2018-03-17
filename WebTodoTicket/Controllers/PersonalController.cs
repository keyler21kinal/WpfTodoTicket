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
    public class PersonalController : Controller
    {
        private TodoTicket1Context1 db = new TodoTicket1Context1();

        // GET: Personal
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["idUsuario"]);
            List<Personal> lista = new List<Personal>();
            var personal = db.Personal.Include(p => p.evento).Include(p => p.Usuario);
            foreach (var item in personal)
            {
                if (id == item.UsuarioId)
                {
                    lista.Add(item);
                }
            }
            return View(lista);
        }

        // GET: Personal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // GET: Personal/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Nombre");
            return View();
        }

        // POST: Personal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalId,NombrePersonal,Tipo,EventoId,UsuarioId")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["idUsuario"]);
                var usuario = db.Usuario.FirstOrDefault(u => u.UsuarioId == id);
                personal.Usuario = usuario;
                db.Personal.Add(personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre", personal.EventoId);
            return View(personal);
        }

        // GET: Personal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre", personal.EventoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Nombre", personal.UsuarioId);
            return View(personal);
        }

        // POST: Personal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalId,NombrePersonal,Tipo,EventoId,UsuarioId")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre", personal.EventoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Nombre", personal.UsuarioId);
            return View(personal);
        }

        // GET: Personal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: Personal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personal personal = db.Personal.Find(id);
            db.Personal.Remove(personal);
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
