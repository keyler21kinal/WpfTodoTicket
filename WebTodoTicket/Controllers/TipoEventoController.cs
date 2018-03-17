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
    public class TipoEventoController : Controller
    {
        private TodoTicket1Context1 db = new TodoTicket1Context1();

        // GET: TipoEvento
        public ActionResult Index()
        {
            return View(db.TipoEvento.ToList());
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
