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
    public class TicketController : Controller
    {
        private TodoTicket1Context1 db = new TodoTicket1Context1();

        // GET: Ticket
        //public ActionResult Index(string palabra)
        //{
        //    var ticket = from t in db.Ticket.Include(t => t.Evento) select t;
        //    if (!String.IsNullOrEmpty(palabra))
        //    {
        //        ticket = ticket.Where(l => l.Evento.Nombre.Contains(palabra));
        //    }
        //    return View(ticket);
        //    //var ticket = db.Ticket.Include(t => t.Evento);
        //    //return View(ticket.ToList());
        //}

        // GET: Ticket/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,Precio,EventoId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Ticket.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre", ticket.EventoId);
            return View(ticket);
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
