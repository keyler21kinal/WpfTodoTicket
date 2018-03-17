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
    public class EventoController : Controller
    {
        private TodoTicket1Context1 db = new TodoTicket1Context1();

        // GET: Evento
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["idUsuario"]);
            List<Evento> lista = new List<Evento>();
            var evento = db.Evento.Include(e => e.TipoEvento).Include(e => e.Usuario);
            foreach (var item in evento)
            {
                if (id == item.UsuarioId)
                {
                    lista.Add(item);
                }
            }
            return View(lista);
        }

        public ActionResult Calendario()
        {
            var evento = db.Evento.Include(e => e.TipoEvento).Include(e => e.Usuario);
            return View(evento.ToList());
        }

        //Crear1
        public ActionResult Create()
        {
            ViewBag.TipoEventoId = new SelectList(db.TipoEvento, "TipoEventoId", "Descripcion");
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "EventoId,Nombre,Descripcion,Portada,Fecha,Lugar,TipoEventoId,UsuarioId")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["idUsuario"]);
                var usuario = db.Usuario.FirstOrDefault(u => u.UsuarioId == id);
                evento.Usuario = usuario;
                db.Evento.Add(evento);
                db.SaveChanges();
            }
            ViewBag.TipoEventoId = new SelectList(db.TipoEvento, "TipoEventoId", "Descripcion", evento.TipoEventoId);
            return RedirectToAction("Index", "Evento");
        }

        public ActionResult EventoTipo(int? id)
        {
            List<Evento> lista = new List<Evento>();
            var evento = db.Evento.Include(e => e.TipoEvento).Include(e => e.Usuario);
            foreach (var item in evento)
            {
                if (id == item.TipoEventoId)
                {
                    lista.Add(item);
                }
            }
            return View(lista);
        }

        public ActionResult Evento(string palabra)
        {
            var evento = from e in db.Evento.Include(e => e.TipoEvento).Include(e => e.Usuario) select e;
            if (!String.IsNullOrEmpty(palabra))
            {
                evento = evento.Where(l => l.Nombre.Contains(palabra));
            }
            return View(evento);
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
