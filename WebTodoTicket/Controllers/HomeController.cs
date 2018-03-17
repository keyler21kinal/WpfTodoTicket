using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebTodoTicket.Models;

namespace WebTodoTicket.Controllers
{
    public class HomeController : Controller
    {
        private TodoTicket1Context1 db = new TodoTicket1Context1();

        // GET: Evento
        public ActionResult Index()
        {
            //var evento = db.Evento.Include(e => e.TipoEvento).Include(e => e.Usuario);
            return View();
        }
    }
}
